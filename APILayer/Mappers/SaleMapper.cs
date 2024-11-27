using StokTakipSistemiAPI.APILayer.DTOs.SaleDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class SaleMapper
    {
        public static SaleDto MapSaleToSaleDTO(Sale sale)
        {
            return new SaleDto
            {
                Id = sale.Id,
                TotalAmount = sale.TotalAmount,
                SaleDate = sale.SaleDate,
                ProductId = sale.ProductId,
                Quantity = sale.Quantity,
                Price = sale.Price,
            };
        }

        public static Sale MapSaleUpdateDtoToSale(SaleUpdateDto saleDto)
        {
            return new Sale
            {
                TotalAmount = saleDto.TotalAmount,
                ProductId = saleDto.ProductId,
                Quantity = saleDto.Quantity,
                Price = saleDto.Price,
            };
        }

        public static Sale MapSaleCreateDtoToSale(SaleCreateDto saleDto)
        {
            return new Sale
            {
                TotalAmount = saleDto.TotalAmount,
                ProductId = saleDto.ProductId,
                Quantity = saleDto.Quantity,
                Price = saleDto.Price,
            };
        }
    }
}