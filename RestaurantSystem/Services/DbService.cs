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
            db.OrderProducts.AddRange(order.Products);
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
        try
        {
            return db.Orders
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .First(o => o.TableNumber == tableNumber);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
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
            db.Tables.First(t => t.TableId == tableNumber)
                .IsOccupied = isOccupied;

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

    public IEnumerable<Table> GetAllTables()
    {
        try
        {
            return db.Tables;
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public IEnumerable<Table> GetAllTables(bool occupiedTables)
    {
        try
        {
            return db.Tables.Where(t => t.IsOccupied == occupiedTables);
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
            db.Tables.Remove(GetTable(tableNumber));
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
            db.Products.Remove(GetMenuItem(menuItemId));
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