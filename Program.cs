using CargoCompany.Data;
using CargoCompany.Repositories;
using CargoCompany.Models;
using CargoCompany.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CargoContext>(options =>
{
    var config = builder.Configuration;
    var ConnectionString = config.GetConnectionString("DefaultString");
    options.UseSqlServer(ConnectionString);
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
