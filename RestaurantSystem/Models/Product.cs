using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.Models;

internal class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrderProduct> Orders { get; set; } = new List<OrderProduct>();

    public override string ToString()
    {
        return $"Product ID: {ProductId}\n\tProduct: {Name}\n\tPrice: {Price}";
    }

}