using StokTakipSistemiAPI.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task<T?> DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<Warehouse?> GetDefaultWarehouse();
    }

}