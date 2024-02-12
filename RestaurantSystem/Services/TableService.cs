using RestaurantSystem.Models;
using RestaurantSystem.Services.Interfaces;

namespace RestaurantSystem.Services;

internal class TableService(IDbRepository dbRepository) : ITableService
{
    public void MarkTableAsOccupied(int tableNumber)
    {
        try
        {
            dbRepository.UpdateTableOccupancy(tableNumber, true);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public void MarkTableAsFree(int tableNumber)
    {
        try
        {
            dbRepository.UpdateTableOccupancy(tableNumber, false);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public Table GetTable(int tableNumber)
    {
        try
        {
            return dbRepository.GetTable(tableNumber);
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
            return dbRepository.GetAllTables();
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
            return dbRepository.GetAllTables(occupiedTables);
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
            dbRepository.AddTable(table);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public void UpdateTableOccupancy(int tableNumber, bool isOccupied)
    {
        try
        {
            dbRepository.UpdateTableOccupancy(tableNumber, isOccupied);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public bool TableExists(int tableId)
    {
        return dbRepository.GetAllTables().Any(t => t.TableId == tableId);
    }

    public void RemoveTable(int tableNumber)
    {
        dbRepository.RemoveTable(tableNumber);
    }
}