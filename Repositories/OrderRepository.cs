using CargoCompany.Data;
using CargoCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Repositories
{
    public class OrderRepository<T> : IRepository<T> where T : Orders
    {
        private readonly CargoContext _context;
        public OrderRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task<T?> GetById(int id)
        {
            return await Entity.FirstOrDefaultAsync(p => p.OrderId == id);
        }

        public DbSet<T> Entity => _context.Set<T>();
        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
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