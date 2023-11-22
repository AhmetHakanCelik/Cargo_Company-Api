using CargoCompany.Data;
using CargoCompany.Repositories;
using CargoCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CargoContext>(options =>
{
    var config = builder.Configuration;
    var ConnectionString = config.GetConnectionString("DefaultString");
    options.UseSqlServer(ConnectionString);
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CargoContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 10;
});

builder.Services.AddScoped<IRepository<Carriers>, CarrierRepository<Carriers>>();
builder.Services.AddScoped<IOrderRepository<Orders>, OrderRepository<Orders>>();
builder.Services.AddScoped<IConfigRepository<CarrierConfigurations>, ConfigurationRepository<CarrierConfigurations>>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
