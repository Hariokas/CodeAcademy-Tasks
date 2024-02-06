using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services;

internal class TableService(IDbService dbService) : ITableRepository
{
    public void MarkTableAsOccupied(int tableNumber)
    {
        try
        {
            dbService.UpdateTableOccupancy(tableNumber, true);
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
            dbService.UpdateTableOccupancy(tableNumber, false);
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
            return dbService.GetTable(tableNumber);
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
            return dbService.GetAllTables(occupiedTables);
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
            dbService.AddTable(table);
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
            dbService.UpdateTableOccupancy(tableNumber, isOccupied);
        }
        catch (Exception e)
        {
            StaticHelpers.PrintError(e);
            throw;
        }
    }

    public bool TableExists(int tableId) => dbService.GetAllTables().Any(t => t.TableId == tableId);

}