using RestaurantSystem.Models;

namespace RestaurantSystem.Services.Interfaces;

internal interface ITableService
{
    void MarkTableAsOccupied(int tableNumber);
    void MarkTableAsFree(int tableNumber);
    Table GetTable(int tableNumber);
    IEnumerable<Table> GetAllTables();
    IEnumerable<Table> GetAllTables(bool occupiedTables);
    void AddTable(Table table);
    void UpdateTableOccupancy(int tableNumber, bool isOccupied);
    bool TableExists(int tableNumber);
    void RemoveTable(int tableNumber);
}