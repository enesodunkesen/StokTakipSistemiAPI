using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DataAccessLayer;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales
                                 .Include(s => s.Product) // İlişkili ürünü yükler
                                 .ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            var sale = await _context.Sales
                                     .Include(s => s.Product) // İlişkili ürünü yükler
                                     .FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null)
            {
                throw new InvalidOperationException($"Sale with ID {id} not found.");
            }
            return sale;
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Sale>> GetSalesByProductIdAsync(int productId)
        {
            return await _context.Sales
                                 .Include(s => s.Product)
                                 .Where(s => s.ProductId == productId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                                 .Include(s => s.Product)
                                 .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                                 .ToListAsync();
        }
    }
}
