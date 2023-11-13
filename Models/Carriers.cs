using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class Carriers
{
    [Key]
    [Required]
    public int CarrierId { get; set; }
    [Required]
    public string? CarrierName { get; set; }
    [Required]
    public bool CarrierIsActive { get; set; }
    [Required]
    public int CarrierPlusDesiCost { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,4)")]
    public int CarrierConfigurationId { get; set; }
}