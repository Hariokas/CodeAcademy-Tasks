using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces;

internal interface IOrderRepository
{
    void SaveOrder(Order order);
    void SendOrderEmail(string to, string subject, Order order);
    Order GetOrder(int tableNumber);
}