﻿using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services;

internal class OrderService(
    ITableRepository tableRepository,
    IEmailService emailService,
    IDbService dbService) : IOrderRepository
{
    public void SaveOrder(Order order)
    {
        dbService.SaveOrder(order);
    }

    public void SendOrderEmail(string to, string subject, Order order)
    {
        emailService.SendEmail(to, subject, order.ToString());
    }

    public Order GetOrder(int tableNumber)
    {
        return dbService.GetOrder(tableNumber);
    }

    public void PrintOrder(Order order)
    {
        var table = tableRepository.GetTable(order.TableNumber);
        Console.WriteLine($"Table {table.TableId} - {table.NumberOfSeats} seats");
        Console.WriteLine($"Order ID: {order.OrderId}");
        Console.WriteLine($"Order time: {order.OrderTime}");
        Console.WriteLine("Order items:");
        foreach (var orderItem in order.Products)
            Console.WriteLine($"\t{orderItem.Product.Name} - {orderItem.Product.Price}x");

        Console.WriteLine($"Total price: {order.TotalAmount}");
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return dbService.GetAllOrders();
    }

    public IEnumerable<Order> GetLastOrders(int count)
    {
        return dbService.GetLastOrders(count);
    }

    public void CreateOrder(Order order)
    {
        tableRepository.MarkTableAsOccupied(order.TableNumber);
        SaveOrder(order);
    }

    public void CloseOrder(int tableNumber, string email = "")
    {
        var order = GetOrder(tableNumber);
        tableRepository.MarkTableAsFree(tableNumber);

        if (!string.IsNullOrEmpty(email))
            SendOrderEmail(email,
                $"Your restaurant order {order.OrderId} at {order.OrderTime.ToShortDateString()}", order);
    }
}