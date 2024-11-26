using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DataAccessLayer;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses
                                 .Include(w => w.Stocks)  // İlişkili stokları yükler
                                 .ToListAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            var warehouse = await _context.Warehouses
                                          .Include(w => w.Stocks)  // İlişkili stokları yükler
                                          .FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse == null)
            {
                throw new InvalidOperationException($"Warehouse with ID {id} not found.");
            }

            return warehouse;
        }

        public async Task<Warehouse> GetByNameAsync(string name)
        {
            var warehouse = await _context.Warehouses
                                          .Include(w => w.Stocks)  // İlişkili stokları yükler
                                          .FirstOrDefaultAsync(w => w.Name == name);
            if (warehouse == null)
            {
                throw new InvalidOperationException($"Warehouse with name {name} not found.");
            }

            return warehouse;
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
