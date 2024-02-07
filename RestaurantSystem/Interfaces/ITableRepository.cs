using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces;

internal interface ITableRepository
{
    void MarkTableAsOccupied(int tableNumber);
    void MarkTableAsFree(int tableNumber);
    Table GetTable(int tableNumber);
    IEnumerable<Table> GetAllTables(bool? occupiedTables = null);
    void AddTable(Table table);
    void UpdateTableOccupancy(int tableNumber, bool isOccupied);
    bool TableExists(int tableNumber);
    void RemoveTable(int tableNumber);
}