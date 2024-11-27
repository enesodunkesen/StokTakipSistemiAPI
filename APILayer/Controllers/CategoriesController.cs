using Microsoft.AspNetCore.Mvc;
using StokTakipSistemiAPI.APILayer.DTOs.CategoryDTOs;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;


namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories =  await _categoryService.GetAllCategoriesAsync();

            var categoryDTOs = categories.Select(category => CategoryMapper.MapCategoryToCategoryDto(category)).ToList();

            return Ok(categoryDTOs);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryWithProductsByIdAsync(id);

            var categoryDTO = CategoryMapper.MapCategoryToCategoryDto(category);

            if (categoryDTO == null)
            {
                return NotFound();
            }

            return Ok(categoryDTO);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryCreateDto categoryDTO)
        {
            var category = CategoryMapper.MapCategoryCreateDtoToCategory(categoryDTO);

            await _categoryService.CreateCategoryAsync(category);

            return CreatedAtAction("GetById", new { id = category.Id }, CategoryMapper.MapCategoryToCategoryDto(category));
        }
    }
}
