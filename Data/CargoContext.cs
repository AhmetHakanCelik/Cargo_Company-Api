using System.ComponentModel.DataAnnotations.Schema;
using CargoCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Data;

public class CargoContext : DbContext
{
    public DbSet<Carriers> Carriers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }
    public CargoContext(DbContextOptions<CargoContext> options) : base(options)
    {

    }
}