using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DataAccessLayer;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks
                                 .Include(s => s.Product)    // İlişkili ürün bilgilerini yükler
                                 .Include(s => s.Warehouse) // İlişkili depo bilgilerini yükler
                                 .ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks
                                       .Include(s => s.Product)
                                       .Include(s => s.Warehouse)
                                       .FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                throw new InvalidOperationException($"Stock with ID {id} not found.");
            }
            return stock;
        }

        public async Task<IEnumerable<Stock>> GetByProductIdAsync(int productId)
        {
            return await _context.Stocks
                                 .Include(s => s.Product)
                                 .Include(s => s.Warehouse)
                                 .Where(s => s.ProductId == productId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.Stocks
                                 .Include(s => s.Product)
                                 .Include(s => s.Warehouse)
                                 .Where(s => s.WarehouseId == warehouseId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetLowStockAsync(int minThreshold)
        {
            return await _context.Stocks
                                 .Include(s => s.Product)
                                 .Include(s => s.Warehouse)
                                 .Where(s => s.Quantity < minThreshold)
                                 .ToListAsync();
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
    }
}
