using RestaurantSystem.Models;

namespace RestaurantSystem.Services.Interfaces;

internal interface IOrderRepository
{
    void SaveOrder(Order order);
    void SendOrderEmail(string to, Order order);
    Order GetOrder(int tableNumber);
    void PrintOrder(Order order);
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetLastOrders(int count);
    void CreateOrder(Order order);
    void CloseOrder(Order order);
    IEnumerable<Order> GetOpenOrders();
}