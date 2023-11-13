using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class Orders
{
    [Key]
    [Required]
    public int OrderId { get; set; }
    [Required]
    [ForeignKey("Carriers")]
    public int CarrierId { get; set; }
    [Required]
    public int OrderDesi { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,4)")]
    public decimal OrderCarrierCost { get; set; }
}