using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.DataAccessLayer;

namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public StockMovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _context.StockMovements
                                 .Include(sm => sm.Product)    // İlişkili ürünü yükler
                                 .Include(sm => sm.Warehouse) // İlişkili depoyu yükler
                                 .ToListAsync();
        }

        public async Task<StockMovement> GetByIdAsync(int id)
        {
            var stockMovement = await _context.StockMovements
                                              .Include(sm => sm.Product)
                                              .Include(sm => sm.Warehouse)
                                              .FirstOrDefaultAsync(sm => sm.Id == id);
            if (stockMovement == null)
            {
                throw new InvalidOperationException($"StockMovement with ID {id} not found.");
            }
            return stockMovement;
        }

        public async Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId)
        {
            return await _context.StockMovements
                                 .Include(sm => sm.Product)
                                 .Include(sm => sm.Warehouse)
                                 .Where(sm => sm.ProductId == productId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.StockMovements
                                 .Include(sm => sm.Product)
                                 .Include(sm => sm.Warehouse)
                                 .Where(sm => sm.WarehouseId == warehouseId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType)
        {
            return await _context.StockMovements
                                 .Include(sm => sm.Product)
                                 .Include(sm => sm.Warehouse)
                                 .Where(sm => sm.MovementType == movementType)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.StockMovements
                                 .Include(sm => sm.Product)
                                 .Include(sm => sm.Warehouse)
                                 .Where(sm => sm.MovementDate >= startDate && sm.MovementDate <= endDate)
                                 .ToListAsync();
        }

        public async Task AddAsync(StockMovement stockMovement)
        {
            await _context.StockMovements.AddAsync(stockMovement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockMovement stockMovement)
        {
            _context.Entry(stockMovement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockMovement = await _context.StockMovements.FindAsync(id);
            if (stockMovement != null)
            {
                _context.StockMovements.Remove(stockMovement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
