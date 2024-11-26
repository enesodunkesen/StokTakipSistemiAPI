using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface ITransferRepository
    {
        Task<IEnumerable<Transfer>> GetAllAsync();
        Task<Transfer> GetByIdAsync(int transferId);
        Task<IEnumerable<Transfer>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Transfer>> GetByFromWarehouseIdAsync(int fromWarehouseId);
        Task<IEnumerable<Transfer>> GetByToWarehouseIdAsync(int toWarehouseId);
        Task<IEnumerable<Transfer>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task AddAsync(Transfer transfer);
        Task UpdateAsync(Transfer transfer);
        Task DeleteAsync(int transferId);
    }
}
