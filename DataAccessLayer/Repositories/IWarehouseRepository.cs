using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
        Task<Warehouse> GetByNameAsync(string name);
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
