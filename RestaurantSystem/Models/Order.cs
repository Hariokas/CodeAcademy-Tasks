using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        return
            $"Order ID: {OrderId}\n\tTable ID:\t{TableNumber}\n\tOrder time:\t{OrderTime}\n\tProducts:\t{string.Join("\n\t\t\t", Products)}\n\tTotal amount:\t{TotalAmount}";
    }
}