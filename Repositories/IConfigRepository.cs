using CargoCompany.Dto;
using Microsoft.EntityFrameworkCore;

namespace CargoCompany.Repositories
{
    public interface IConfigRepository<T> where T : class
    {
        DbSet<T> Entity { get; }
        Task<bool> AddAsync(T entity);
        Task<T?> GetById(int id);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<ConfigurationDto<T>> GetAll();
    }

}