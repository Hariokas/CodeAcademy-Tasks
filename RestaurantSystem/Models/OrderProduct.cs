using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.Models;

internal class OrderProduct
{
    [Key]
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
}