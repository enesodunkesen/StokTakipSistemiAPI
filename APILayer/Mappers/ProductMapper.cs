using StokTakipSistemiAPI.APILayer.DTOs.ProductDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class ProductMapper
    {
        public static ProductDto MapProductToProductDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Size = product.Size,
                Color = product.Color
            };
        }

        public static Product MapProductCrateDtoToProduct(ProductCreateDto productDTO)
        {
            return new Product
            {
                Name = productDTO.Name,
                CategoryId = productDTO.CategoryId,
                Price = productDTO.Price,
                Size = productDTO.Size,
                Color = productDTO.Color
            };
        }

        public static Product MapProductUpdateDtoToProduct(ProductUpdateDto productDTO)
        {
            return new Product
            {
                Price = productDTO.Price,
            };
        }
    }
}
