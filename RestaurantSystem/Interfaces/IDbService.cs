using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces;

internal interface IDbService
{
    // Table methods
    void AddTable(Table table);
    void RemoveTable(int tableNumber);
    void UpdateTableOccupancy(int tableNumber, bool isOccupied);
    Table GetTable(int tableNumber);
    IEnumerable<Table> GetAllTables(bool? occupiedTables = null);

    // Menu item methods
    void AddMenuItem(Product menuItem);
    void RemoveMenuItem(int menuItemId);
    void UpdateMenuItem(Product menuItem);
    Product GetMenuItem(int menuItemId);
    IEnumerable<Product> GetAllMenuItems();

    // Order item methods
    void SaveOrder(Order order);
    void RemoveOrderItem(int orderItemId);
    void UpdateOrderItem(Order orderItem);
    Order GetOrder(int tableNumber);
    IEnumerable<Order> GetLastOrders(int count);
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetOpenOrders();
}