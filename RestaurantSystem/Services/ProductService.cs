using RestaurantSystem.Models;
using RestaurantSystem.Services.Interfaces;

namespace RestaurantSystem.Services;

internal class ProductService(IDbRepository dbRepository) : IProductService
{
    public bool CheckIfProductExists(Product product)
    {
        return dbRepository.GetAllMenuItems().Any(p => p == product);
    }

    public void AddProduct(Product product)
    {
        dbRepository.AddMenuItem(product);
    }

    public void RemoveProduct(int productId)
    {
        dbRepository.RemoveMenuItem(productId);
    }

    public void UpdateProduct(Product product)
    {
        dbRepository.UpdateMenuItem(product);
    }

    public Product GetProduct(int productId)
    {
        return dbRepository.GetMenuItem(productId);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return dbRepository.GetAllMenuItems();
    }
}