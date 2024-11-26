using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<IEnumerable<Stock>> GetByProductIdAsync(int productId); //Belirli bir ürünle ilişkili stokları getirir.
        Task<IEnumerable<Stock>> GetByWarehouseIdAsync(int warehouseId); //Belirli bir depoya ait stokları getirir.
        Task<IEnumerable<Stock>> GetLowStockAsync(int minThreshold); //Belirtilen minimum eşik değerinin altında olan stokları döner.
        Task AddAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task DeleteAsync(int id);
    }
}
