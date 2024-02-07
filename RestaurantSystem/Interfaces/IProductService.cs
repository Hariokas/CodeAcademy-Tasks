using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces;

internal interface IProductService
{
    bool CheckIfProductExists(Product product);
    void AddProduct(Product product);
    void RemoveProduct(int productId);
    void UpdateProduct(Product product);
    Product GetProduct(int productId);
    IEnumerable<Product> GetAllProducts();

}