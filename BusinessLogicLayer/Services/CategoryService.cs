using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository<Category> _categoryRepository;

        public CategoryService(ICategoryRepository<Category> repository)
        {
            _categoryRepository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            CategoryRules.ValidateCategory(category);

            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<Category?> GetCategoryWithProductsByIdAsync(int id)
        {
           return await _categoryRepository.GetCategoryWithProductsByIdAsync(id);
        }
    }
}
