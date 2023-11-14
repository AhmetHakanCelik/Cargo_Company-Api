using CargoCompany.Data;
using CargoCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Repositories
{
    public class ConfigurationRepository<T> : IRepository<T> where T : CarrierConfigurations
    {
        protected readonly CargoContext _context;
        public ConfigurationRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task<T?> GetById(int id)
        {
            return await Entity.FirstOrDefaultAsync(p => p.CarrierConfigurationId == id);
        }

        public DbSet<T> Entity => _context.Set<T>();
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
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
}