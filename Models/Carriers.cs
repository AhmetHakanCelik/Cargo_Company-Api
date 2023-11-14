using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoCompany.Models;

public class Carriers
{
    [Key]
    public int CarrierId { get; set; }
    public string? CarrierName { get; set; }
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
    [Column(TypeName = "decimal(10,4)")]
    public int CarrierConfigurationId { get; set; }
}