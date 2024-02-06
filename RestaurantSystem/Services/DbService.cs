using RestaurantSystem.Database;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services;

internal class DbService(RestaurantDbContext db) : IDbService
{
    #region OrderManagement

    public void SaveOrder(Order order)
    {
        try
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public Order GetOrder(int tableNumber)
    {
        return db.Orders.First(o => o.TableNumber == tableNumber);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        try
        {
            return db.Orders;
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public IEnumerable<Order> GetLastOrders(int count)
    {
        try
        {
            return db.Orders.OrderByDescending(o => o.OrderTime).Take(count);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public void RemoveOrderItem(int orderItemId)
    {
        try
        {
            var orderItem = db.Orders.First(o => o.OrderId == orderItemId);
            if (orderItem is null) return;

            db.Orders.Remove(orderItem);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public void UpdateOrderItem(Order orderItem)
    {
        try
        {
            var item = db.Orders.First(o => o.OrderId == orderItem.OrderId);
            item.Products = orderItem.Products;
            item.OrderTime = orderItem.OrderTime;
            item.TableNumber = orderItem.TableNumber;

            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    #endregion



    #region TableManagement

    public void UpdateTableOccupancy(int tableNumber, bool isOccupied)
    {
        try
        {
            var table = db.Tables.First(t => t.TableId == tableNumber);
            table.IsOccupied = isOccupied;
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public Table GetTable(int tableNumber)
    {
        try
        {
            return db.Tables.First(t => t.TableId == tableNumber);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public IEnumerable<Table> GetAllTables(bool? occupiedTables = null)
    {
        try
        {
            return occupiedTables switch
            {
                true => db.Tables.Where(t => t.IsOccupied),
                false => db.Tables.Where(t => !t.IsOccupied),
                _ => db.Tables
            };
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public void AddTable(Table table)
    {
        try
        {
            db.Tables.Add(table);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public void RemoveTable(int tableNumber)
    {
        try
        {
            var table = db.Tables.First(t => t.TableId == tableNumber);
            if (table is null) return;

            db.Tables.Remove(table);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    #endregion



    #region ProductManagement

    public void AddMenuItem(Product menuItem)
    {
        try
        {
            db.Products.Add(menuItem);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public void RemoveMenuItem(int menuItemId)
    {
        try
        {
            var menuItem = db.Products.First(p => p.ProductId == menuItemId);
            if (menuItem is null) return;

            db.Products.Remove(menuItem);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public IEnumerable<Product> GetAllMenuItems()
    {
        try
        {
            return db.Products;
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public Product GetMenuItem(int menuItemId)
    {
        try
        {
            return db.Products.First(p => p.ProductId == menuItemId);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            return null;
        }
    }

    public void UpdateMenuItem(Product menuItem)
    {
        try
        {
            var item = db.Products.First(p => p.ProductId == menuItem.ProductId);
            item.Name = menuItem.Name;
            item.Price = menuItem.Price;
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    #endregion
}