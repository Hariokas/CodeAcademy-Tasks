using Microsoft.Extensions.Configuration;
using RestaurantSystem.Database;
using RestaurantSystem.Models;
using RestaurantSystem.Services;
using static RestaurantSystem.StaticHelpers;

namespace RestaurantSystem;

internal class RestaurantProject
{
    private readonly RestaurantDbContext _dbContext;
    private readonly DbService _dbService;
    private readonly EmailService _emailService;
    private readonly OrderService _orderService;
    private readonly TableService _tableService;

    public RestaurantProject(IConfiguration configuration)
    {
        _dbContext = new RestaurantDbContext();
        _dbContext.Database.EnsureCreated();

        _dbService = new DbService(_dbContext);
        _emailService = new EmailService(configuration["Restaurant:EmailPass"]);
        _tableService = new TableService(_dbService);
        _orderService = new OrderService(_tableService, _emailService, _dbService);
    }

    public void Run()
    {
        var showMenu = true;
        while (showMenu) showMenu = MainMenu();

        PrintBanner();
        PrintInGreen("Thank you for using our system!");
        Thread.Sleep(2000);
    }

    #region MainMenu

    private void PrintMenuOptions()
    {
        PrintInYellow("1. Table Management");
        PrintInYellow("2. Order Management");
        PrintInYellow("3. Product Management");
        PrintInYellow("0. Exit");
    }

    private bool MainMenu()
    {
        PrintBanner();
        PrintMenuOptions();
        var input = GetIntInput("Select an option: ");
        switch (input)
        {
            case -1:
            case 0:
                return false;
            case 1:
                TableManagementMenu();
                break;
            case 2:
                OrderManagementMenu();
                break;
            case 3:
                ProductManagementMenu();
                break;
            default:
                PrintInRed("Invalid input.");
                Thread.Sleep(1000);
                break;
        }

        return true;
    }

    private void TableManagementMenu()
    {
        var showMenu = true;
        while (showMenu) showMenu = TableManagementSubMenu();
    }

    private void OrderManagementMenu()
    {
        var showMenu = true;
        while (showMenu) showMenu = OrderManagementSubMenu();
    }

    private void ProductManagementMenu()
    {
        var showMenu = true;
        while (showMenu) showMenu = ProductManagementSubMenu();
    }

    #endregion

    #region TableManagement

    private void PrintTableManagementOptions()
    {
        PrintInYellow("1. View Tables");
        PrintInYellow("2. Mark Table as Occupied");
        PrintInYellow("3. Mark Table as Vacant");
        PrintInYellow("4. Add Table");
        PrintInYellow("5. Remove Table");
        PrintInYellow("0. Back");
    }

    private bool TableManagementSubMenu()
    {
        PrintBanner();
        PrintTableManagementOptions();
        var input = GetIntInput("Select an option: ");
        switch (input)
        {
            case -1:
            case 0:
                return false;
            case 1:
                ViewTables();
                break;
            case 2:
                UpdateTableOccupancy(true);
                break;
            case 3:
                UpdateTableOccupancy(false);
                break;
            case 4:
                AddTable();
                break;
            case 5:
                RemoveTable();
                break;
            default:
                PrintInRed("Invalid input.");
                Thread.Sleep(1000);
                break;
        }

        return true;
    }

    private void ViewTables()
    {
        PrintBanner();

        var listOfTables = _tableService.GetAllTables().ToList();
        foreach (var table in listOfTables)
            if (table.IsOccupied)
                PrintInRed(table.ToString());
            else
                PrintInGreen(table.ToString());

        WaitForClickAnyButton();
    }

    private void UpdateTableOccupancy(bool isOccupied)
    {
        var tableList = _tableService.GetAllTables(!isOccupied).ToList();
        if (tableList.Count < 1)
        {
            PrintInRed("No tables found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var table in tableList)
            if (table.IsOccupied)
                PrintInRed(table.ToString());
            else
                PrintInGreen(table.ToString());

        var tableNumber = GetIntInput("Enter table number:");
        if (tableNumber == -1) return;

        if (!_tableService.TableExists(tableNumber))
        {
            PrintInRed("Invalid table number.");
            Thread.Sleep(1000);
            return;
        }

        _tableService.UpdateTableOccupancy(tableNumber, isOccupied);
        var updatedTable = _tableService.GetTable(tableNumber);
        PrintInGreen($"Updated!\n{updatedTable}");
        Thread.Sleep(2000);
    }

    private void AddTable()
    {
        var numberOfSeats = GetIntInput("Enter number of seats:");
        if (numberOfSeats == -1) return;

        var table = new Table { IsOccupied = false, NumberOfSeats = numberOfSeats };
        _tableService.AddTable(table);
        PrintInGreen($"Table added!\n{table}");
        WaitForClickAnyButton();
    }

    private void RemoveTable()
    {
        var tableList = _tableService.GetAllTables().ToList();
        if (tableList.Count < 1)
        {
            PrintInRed("No tables found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var table in tableList)
            if (table.IsOccupied)
                PrintInRed(table.ToString());
            else
                PrintInGreen(table.ToString());

        var tableNumber = GetIntInput("Enter table number:");
        if (tableNumber == -1) return;

        if (!_tableService.TableExists(tableNumber))
        {
            PrintInRed("Invalid table number.");
            Thread.Sleep(1000);
            return;
        }

        _dbService.RemoveTable(tableNumber);
        PrintInGreen($"Table removed!");
        WaitForClickAnyButton();
    }

    #endregion

    #region OrderManagement

    private void PrintOrderManagementOptions()
    {
        PrintInYellow("1. Create Order");
        PrintInYellow("2. Send Receipt");
        PrintInYellow("3. Get Last 10 Orders");
        PrintInYellow("4. Get All Orders");
        PrintInYellow("0. Back");
    }

    private bool OrderManagementSubMenu()
    {
        PrintBanner();
        PrintOrderManagementOptions();
        var input = GetIntInput("Select an option: ");
        switch (input)
        {
            case -1:
            case 0:
                return false;
            case 1:
                CreateOrder();
                break;
            case 2:
                SendReceipt();
                break;
            case 3:
                GetOrders(10);
                break;
            case 4:
                GetOrders();
                break;
            default:
                PrintInRed("Invalid input.");
                Thread.Sleep(1000);
                break;
        }
        return false;
    }

    private void GetOrders(int count = 0)
    {
        var orders = count == 0 ? _orderService.GetAllOrders() : _orderService.GetLastOrders(count);

        var ordersList = orders.ToList();

        if (ordersList.Count < 1)
        {
            PrintInRed("No orders found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var order in ordersList)
            PrintInGreen(order.ToString());

        WaitForClickAnyButton();
    }

    private void CreateOrder()
    {
        var emptyTables = _tableService.GetAllTables(false).ToList();
        if (emptyTables.Count < 1)
        {
            PrintInRed("No empty tables found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var emptyTable in emptyTables)
            PrintInGreen(emptyTable.ToString());

        var tableNumber = GetIntInput("Enter table number:");
        if (tableNumber == -1) return;
        if (emptyTables.All(t => t.TableId != tableNumber))
        {
            PrintInRed("Invalid table number.");
            Thread.Sleep(1000);
            return;
        }

        var selectedProducts = SelectProducts();
        if (selectedProducts == null) return;

        var order = new Order { TableNumber = tableNumber, OrderTime = DateTime.Now, Products = new List<OrderProduct>() };
        foreach (var product in selectedProducts)
        {
            order.Products.Add(new OrderProduct { Product = product, Order = order});
            //order.Products.Add(new OrderProduct { Product = product });
        }
        
        PrintInYellow("Created order:");
        _orderService.PrintOrder(order);
        var createOrder = GetUserInput("Create order? (y/n):");
        if (!createOrder.Equals("y", StringComparison.CurrentCultureIgnoreCase)) return;

        _orderService.CreateOrder(order);
        PrintInGreen("Order created!");

        WaitForClickAnyButton();
    }

    //private void CreateOrder()
    //{
    //    var emptyTables = _tableService.GetAllTables(false).ToList();
    //    if (emptyTables.Count < 1)
    //    {
    //        PrintInRed("No empty tables found.");
    //        Thread.Sleep(1000);
    //        return;
    //    }

    //    foreach (var emptyTable in emptyTables)
    //        PrintInGreen(emptyTable.ToString());

    //    var tableNumber = GetIntInput("Enter table number:");
    //    if (tableNumber == -1) return;
    //    if (emptyTables.All(t => t.TableId != tableNumber))
    //    {
    //        PrintInRed("Invalid table number.");
    //        Thread.Sleep(1000);
    //        return;
    //    }

    //    var selectedProducts = SelectProducts();
    //    if (selectedProducts == null) return;

    //    var order = new Order { TableNumber = tableNumber, OrderTime = DateTime.Now, Products = new List<OrderProduct>() };

    //    foreach (var product in selectedProducts)
    //    {
    //        var orderProduct = new OrderProduct { Order = order, Product = product, ProductId = product.ProductId, OrderId = order.OrderId };
    //        order.Products.Add(orderProduct);
    //    }

    //    PrintInYellow("Created order:");
    //    _orderService.PrintOrder(order);
    //    var createOrder = GetUserInput("Create order? (y/n):");
    //    if (!createOrder.Equals("y", StringComparison.CurrentCultureIgnoreCase)) return;

    //    _orderService.CreateOrder(order);
    //    PrintInGreen("Order created!");

    //    WaitForClickAnyButton();
    //}

    private List<Product>? SelectProducts()
    {
        var menu = _dbService.GetAllMenuItems().ToList();
        if (menu.Count < 1)
        {
            PrintInRed("No products found.");
            Thread.Sleep(1000);
            return null;
        }

        var selectedProducts = new List<Product>();
        while (true)
        {
            Console.Clear();
            foreach (var products in _dbService.GetAllMenuItems())
                PrintInYellow(products.ToString());

            var productId = GetIntInput("Enter product id:");
            if (productId == -1) return null;

            if (menu.All(p => p.ProductId != productId))
            {
                PrintInRed("Invalid product id.");
                Thread.Sleep(1000);
                continue;
            }

            var product = _dbService.GetMenuItem(productId);
            selectedProducts.Add(product);
            PrintInGreen($"{product.Name} added to order.");
            var addMore = GetUserInput("Add more products? (y/n):");
            if (!addMore.Equals("y", StringComparison.CurrentCultureIgnoreCase)) break;
        }

        return selectedProducts;
    }

    private void SendReceipt()
    {

    }

    #endregion

    #region ProductManagement

    private void PrintProductManagementOptions()
    {
        PrintInYellow("1. View Menu");
        PrintInYellow("2. Add Product");
        PrintInYellow("3. Remove Product");
        PrintInYellow("4. Update Product");
        PrintInYellow("0. Back");
    }

    private bool ProductManagementSubMenu()
    {
        PrintBanner();
        PrintProductManagementOptions();
        var input = GetIntInput("Select an option: ");
        switch (input)
        {
            case -1:
            case 0:
                return false;
            case 1:
                ViewMenu();
                break;
            case 2:
                AddProduct();
                break;
            case 3:
                RemoveProduct();
                break;
            case 4:
                UpdateProduct();
                break;
            default:
                PrintInRed("Invalid input.");
                Thread.Sleep(1000);
                break;
        }
        return true;
    }

    private void ViewMenu()
    {
        var menu = _dbService.GetAllMenuItems().ToList();
        if (menu.Count < 1)
        {
            PrintInRed("No products found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var product in menu)
            PrintInGreen(product.ToString());

        WaitForClickAnyButton();
    }

    private void AddProduct()
    {
        var name = GetUserInput("Enter product name:");
        if (name == "-1") return;

        if (name.Equals("import products", StringComparison.OrdinalIgnoreCase))
        {
            ImportProducts();
            return;
        }

        var price = GetDecimalInput("Enter product price:");
        if (price == -1) return;

        var product = new Product { Name = name, Price = price };
        var productExists = _dbService.GetAllMenuItems().Any(p => p.Name == product.Name);
        if (productExists)
        {
            PrintInRed($"Product {product.Name} already exists. You should consider updating it.");
            Thread.Sleep(1000);
            return;
        }

        _dbService.AddMenuItem(product);
        PrintInGreen($"Product added!\n{product}");
        WaitForClickAnyButton();
    }

    private void RemoveProduct()
    {
        var menu = _dbService.GetAllMenuItems().ToList();
        if (menu.Count < 1)
        {
            PrintInRed("No products found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var product in menu)
            PrintInGreen(product.ToString());

        var productId = GetIntInput("Enter product id:");
        if (productId == -1) return;

        if (menu.All(p => p.ProductId != productId))
        {
            PrintInRed("Invalid product id.");
            Thread.Sleep(1000);
            return;
        }

        _dbService.RemoveMenuItem(productId);
        PrintInGreen($"Product removed!");
        WaitForClickAnyButton();
    }

    private void UpdateProduct()
    {
        var menu = _dbService.GetAllMenuItems().ToList();
        if (menu.Count < 1)
        {
            PrintInRed("No products found.");
            Thread.Sleep(1000);
            return;
        }

        foreach (var product in menu)
            PrintInGreen(product.ToString());

        var productId = GetIntInput("Enter product id:");
        if (productId == -1) return;

        if (menu.All(p => p.ProductId != productId))
        {
            PrintInRed("Invalid product id.");
            Thread.Sleep(1000);
            return;
        }

        var name = GetUserInput("Enter product name:");
        if (name == "-1") return;

        var price = GetDecimalInput("Enter product price:");
        if (price == -1) return;

        var newProduct = new Product { ProductId = productId, Name = name, Price = price };
        _dbService.UpdateMenuItem(newProduct);
        PrintInGreen($"Product updated!\n{newProduct}");
        WaitForClickAnyButton();
    }

    private void ImportProducts()
    {
        if (_dbService.GetAllMenuItems().Any())
        {
            PrintInRed("Products already exist.");
            Thread.Sleep(1000);
            return;
        }

        PrintInYellow("Importing products...");
        var products = new List<Product>
        {
            new() { Name = "BigDoc Sandwich", Price = (decimal)5.99 },
            new() { Name = "DocBurger Deluxe", Price = (decimal)6.49 },
            new() { Name = "DocFish Filet", Price = (decimal)4.29 },
            new() { Name = "DocMuffin Breakfast", Price = (decimal)3.49 },
            new() { Name = "Grilled DocWrap", Price = (decimal)5.19 },
            new() { Name = "Sad Meal", Price = (decimal)8.99 },

            new() { Name = "Chicken DocNuggets", Price = (decimal)4.99 },
            new() { Name = "Crispy DocTenders", Price = (decimal)5.49 },

            new() { Name = "DocSalad Bowl", Price = (decimal)5.79 },
            new() { Name = "DocFries", Price = (decimal)1.89 },

            new() { Name = "DocBerry Smoothie", Price = (decimal)3.89 },
            new() { Name = "DocSundae", Price = (decimal)2.49 },
            new() { Name = "DocShake ", Price = (decimal)3.59 },

            new() { Name = "DocLatte ", Price = (decimal)2.99 },
            new() { Name = "DocCafe Espresso", Price = (decimal)2.59 },
        };

        foreach (var product in products)
        {
            PrintInYellow($"Importing {product}");
            _dbService.AddMenuItem(product);
        }

        PrintInGreen("Done!");
        Thread.Sleep(2000);
    }

    #endregion
}