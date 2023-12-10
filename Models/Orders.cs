using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class Orders
{
    [Key]
    public int OrderId { get; set; }
    [ForeignKey("Carriers")]
    [Required]
    public int CarrierId { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    [Column(TypeName = "decimal(10,4)")]
    public decimal OrderCarrierCost { get; set; }
    public Carriers? Carriers { get; set; }
}