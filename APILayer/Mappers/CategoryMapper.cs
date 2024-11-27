using StokTakipSistemiAPI.APILayer.DTOs.CategoryDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto MapCategoryToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductIds = category.Products?.Select(p => p.Id).ToList() ?? new List<int>()
            };
        }

        public static Category MapCategoryCreateDtoToCategory(CategoryCreateDto categoryDTO)
        {

            return new Category
            {
                Name = categoryDTO.Name,
            };

        }
    }
}
