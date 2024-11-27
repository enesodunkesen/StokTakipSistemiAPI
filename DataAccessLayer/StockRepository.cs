using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.DataAccessLayer.Entities;

namespace StokTakipSistemiAPI.DataAccessLayer
{
    public class StockRepository<T> : IStockRepository<T> where T : Stock
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            // Find the existing entity by its ID
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity == null)
            {
                // Return null if the entity with the given ID does not exist
                return null;
            }

            // Update the entity's properties
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            // Save changes to the database
            await SaveChangesAsync();

            // Return the updated entity
            return existingEntity;
        }

        public async Task<T?> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            _dbSet.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId)
        {
            // Ensure the DbSet for Stock is being used
            return await _dbSet.Where(stock => stock.ProductId == productId).ToListAsync();
        }
        public async Task<Warehouse?> GetDefaultWarehouse()
        {
            return await _context.Set<Warehouse>().FindAsync(1);
        }
    }
}
