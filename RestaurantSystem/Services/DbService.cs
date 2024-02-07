using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Database;
using RestaurantSystem.Models;
using RestaurantSystem.Services.Interfaces;

namespace RestaurantSystem.Services;

internal class DbService(RestaurantDbContext db) : IDbRepository
{
    #region OrderManagement

    public void SaveOrder(Order order)
    {
        try
        {
            foreach (var product in order.Products)
                db.OrderProducts.Add(product);

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
        return db.Orders
            .Include(o => o.Products)
            .ThenInclude(op => op.Product)
            .First(o => o.TableNumber == tableNumber);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        try
        {
            return db.Orders
                .Include(o => o.Products)
                .ThenInclude(op => op.Product);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public IEnumerable<Order> GetLastOrders(int count)
    {
        try
        {
            return db.Orders
                .OrderByDescending(o => o.OrderTime)
                .Take(count)
                .Include(o => o.Products)
                .ThenInclude(op => op.Product);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public void RemoveOrderItem(int orderItemId)
    {
        try
        {
            var order = GetOrder(orderItemId);
            if (order is null) return;

            db.Orders.Remove(order);
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
            var item = GetOrder(orderItem.OrderId);
            if (item is null) return;
            db.Orders.Update(item);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
        }
    }

    public IEnumerable<Order> GetOpenOrders()
    {
        try
        {
            return db.Tables
                .Where(t => t.IsOccupied)
                .SelectMany(t => db.Orders
                    .Where(o => o.TableNumber == t.TableId)
                    .OrderByDescending(o => o.OrderTime)
                    .Take(1))
                .Include(o => o.Products)
                .ThenInclude(op => op.Product);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
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
            throw;
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
            throw;
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
            throw;
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
            throw;
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