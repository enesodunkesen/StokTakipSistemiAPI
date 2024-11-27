using StokTakipSistemiAPI.APILayer.DTOs.StockDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class StockMapper
    {
        public static StockDto MapStockToStockDTO(Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                WarehouseId = stock.WarehouseId,
                Quantity = stock.Quantity,
                MinThreshold = stock.MinThreshold,
                UpdatedAt = stock.UpdatedAt,
            };
        }
    }
}
