using CargoCompany.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Data;

public class CargoContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DbSet<Carriers> Carriers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }
    public CargoContext(DbContextOptions<CargoContext> options) : base(options)
    {

    }
}