using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.Models;

internal class Table
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TableId { get; set; }

    public int NumberOfSeats { get; set; }
    public bool IsOccupied { get; set; }

    public override string ToString()
    {
        return $"Table ID: {TableId}; Seats: {NumberOfSeats}; Table Occupancy: {(IsOccupied ? "Taken" : "Empty")}";
    }
}