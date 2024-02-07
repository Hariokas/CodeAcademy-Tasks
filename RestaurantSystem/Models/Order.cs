using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.Models;

internal class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public int TableNumber { get; set; }
    public ICollection<OrderProduct> Products { get; set; }
    public DateTime OrderTime { get; set; } = DateTime.MinValue;
    public decimal TotalAmount => Products.Sum(op => op.Product.Price);

    public override string ToString()
    {
        return $"Order ID: {OrderId}\n\tTable ID: {TableNumber}\n\tOrder time: {OrderTime}\n\tProducts: {string.Join("\n\t\t", Products)}\n\tTotal amount: {TotalAmount}";
    }
}