using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DataAccessLayer;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transfer>> GetAllAsync()
        {
            return await _context.Transfers
                                 .Include(t => t.Product)           // İlişkili ürünü yükler
                                 .Include(t => t.FromWarehouse)    // Gönderen depo bilgilerini yükler
                                 .Include(t => t.ToWarehouse)      // Alan depo bilgilerini yükler
                                 .ToListAsync();
        }

        public async Task<Transfer> GetByIdAsync(int transferId)
        {
            var transfer = await _context.Transfers
                                          .Include(t => t.Product)
                                          .Include(t => t.FromWarehouse)
                                          .Include(t => t.ToWarehouse)
                                          .FirstOrDefaultAsync(t => t.TransferId == transferId);

            if (transfer == null)
            {
                throw new InvalidOperationException($"Transfer with ID {transferId} not found.");
            }

            return transfer;
        }

        public async Task<IEnumerable<Transfer>> GetByProductIdAsync(int productId)
        {
            return await _context.Transfers
                                 .Include(t => t.Product)
                                 .Include(t => t.FromWarehouse)
                                 .Include(t => t.ToWarehouse)
                                 .Where(t => t.ProductId == productId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetByFromWarehouseIdAsync(int fromWarehouseId)
        {
            return await _context.Transfers
                                 .Include(t => t.Product)
                                 .Include(t => t.FromWarehouse)
                                 .Include(t => t.ToWarehouse)
                                 .Where(t => t.FromWarehouseId == fromWarehouseId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetByToWarehouseIdAsync(int toWarehouseId)
        {
            return await _context.Transfers
                                 .Include(t => t.Product)
                                 .Include(t => t.FromWarehouse)
                                 .Include(t => t.ToWarehouse)
                                 .Where(t => t.ToWarehouseId == toWarehouseId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Transfers
                                 .Include(t => t.Product)
                                 .Include(t => t.FromWarehouse)
                                 .Include(t => t.ToWarehouse)
                                 .Where(t => t.TransferDate >= startDate && t.TransferDate <= endDate)
                                 .ToListAsync();
        }

        public async Task AddAsync(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transfer transfer)
        {
            _context.Entry(transfer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int transferId)
        {
            var transfer = await _context.Transfers.FindAsync(transferId);
            if (transfer != null)
            {
                _context.Transfers.Remove(transfer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
