using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class CarrierConfigurations
{
    [Key]
    [Required]
    public int CarrierConfigurationId { get; set; }
    [ForeignKey("Carriers")]
    [Required]
    public int CarrierId { get; set; }
    public int CarrierMaxDesi { get; set; }
    public int CarrierMinDesi { get; set; }
    [Column(TypeName = "decimal(10,4)")]
    public decimal CarrierCost { get; set; }
    public Carriers? Carriers { get; set; }
}