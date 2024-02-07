using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services;

internal class ProductService(IDbService dbService) : IProductService
{
    public bool CheckIfProductExists(Product product)
    {
        return dbService.GetAllMenuItems().Any(p => p == product);
    }

    public void AddProduct(Product product)
    {
        dbService.AddMenuItem(product);
    }

    public void RemoveProduct(int productId)
    {
        dbService.RemoveMenuItem(productId);
    }

    public void UpdateProduct(Product product)
    {
        dbService.UpdateMenuItem(product);
    }

    public Product GetProduct(int productId)
    {
        return dbService.GetMenuItem(productId);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return dbService.GetAllMenuItems();
    }
}