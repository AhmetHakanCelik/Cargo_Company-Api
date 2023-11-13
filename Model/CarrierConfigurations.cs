using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class CarrierConfigurations
{
    [Key]
    [Required]
    public int CarrierConfigurationId { get; set; }
    [Required]
    [ForeignKey("Carriers")]
    public int CarrierId { get; set; }
    [Required]
    public int CarrierMaxDesi { get; set; }
    [Required]
    public int CarrierMinDesi { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,4)")]
    public decimal CarrierCost { get; set; }
}