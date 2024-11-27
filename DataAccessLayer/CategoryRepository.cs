
using Microsoft.EntityFrameworkCore;

namespace StokTakipSistemiAPI.DataAccessLayer
{
    public class CategoryRepository<T> : ICategoryRepository<T> where T : Category
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CategoryRepository(ApplicationDbContext context)
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
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity == null)
            {
                return null;
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            await SaveChangesAsync();

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

        public async Task<Warehouse?> GetDefaultWarehouse()
        {
            return await _context.Set<Warehouse>().FindAsync(1);
        }

        public async Task<T?> GetCategoryWithProductsByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
