using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(int id);
        Task<IEnumerable<Sale>> GetSalesByProductIdAsync(int productId); //Belirli bir ürüne ait satışları getirir.
        Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate); //Belirtilen tarih aralığındaki satışları getirir.
    }
}
