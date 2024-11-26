using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface IStockMovementRepository
    {
        Task<IEnumerable<StockMovement>> GetAllAsync();
        Task<StockMovement> GetByIdAsync(int id);
        Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId); //Belirli bir ürüne ait stok hareketlerini getirir.
        Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId); //Belirli bir depoya ait stok hareketlerini getirir.
        Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType); //Belirli bir hareket türüne göre hareketleri döner (ör. "Giriş" veya "Çıkış").
        Task<IEnumerable<StockMovement>> GetByDateRangeAsync(DateTime startDate, DateTime endDate); //Belirtilen tarih aralığındaki stok hareketlerini döner.
        Task AddAsync(StockMovement stockMovement);
        Task UpdateAsync(StockMovement stockMovement);
        Task DeleteAsync(int id);
    }
}
