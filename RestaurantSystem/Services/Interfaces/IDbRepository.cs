using RestaurantSystem.Models;

namespace RestaurantSystem.Services.Interfaces;

internal interface IDbRepository
{
    // Table methods
    void AddTable(Table table);
    void RemoveTable(int tableNumber);
    void UpdateTableOccupancy(int tableNumber, bool isOccupied);
    Table GetTable(int tableNumber);
    IEnumerable<Table> GetAllTables();
    IEnumerable<Table> GetAllTables(bool occupiedTables);

    // Menu item methods
    void AddMenuItem(Product menuItem);
    void RemoveMenuItem(int menuItemId);
    void UpdateMenuItem(Product menuItem);
    Product GetMenuItem(int menuItemId);
    IEnumerable<Product> GetAllMenuItems();

    // Order item methods
    void SaveOrder(Order order);
    Order GetOrder(int tableNumber);
    IEnumerable<Order> GetLastOrders(int count);
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetOpenOrders();
}