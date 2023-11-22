using CargoCompany.Data;
using CargoCompany.Dto;
using CargoCompany.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Repositories;

public class CarrierRepository<T> : IRepository<T> where T : Carriers
{
    protected readonly CargoContext _context;

    public CarrierRepository(CargoContext context)
    {
        _context = context;
    }

    public DbSet<T> Entity => _context.Set<T>();
    public IEnumerable<CarrierDto<T>> GetAll()
    {
        return Entity.Select(p => new CarrierDto<T>
        {
            CarrierName = p.CarrierName,
            CarrierPlusDesiCost = p.CarrierPlusDesiCost,
            CarrierConfigurationId = p.CarrierConfigurationId
        }).ToList();
    }

    public async Task<T?> GetById(int id)
    {
        return await Entity.FirstOrDefaultAsync(p => p.CarrierId == id);
    }

    public async Task<bool> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public bool Update(T entity)
    {
        _context.Update(entity);
        return _context.SaveChanges() > 0;
    }

    public bool Delete(T entity)
    {
        _context.Remove(entity);
        return _context.SaveChanges() > 0;
    }
}