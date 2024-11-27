using StokTakipSistemiAPI.APILayer.DTOs.StockMovementDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class StockMovementMapper
    {
        public static StockMovementDto MapStockMovementToStockMovementDTO(StockMovement stockMovement)
        {
            return new StockMovementDto
            {
                Id = stockMovement.Id,
                ProductId = stockMovement.ProductId,
                Quantity = stockMovement.Quantity,
                WarehouseId = stockMovement.WarehouseId,
                MovementType = stockMovement.MovementType,
                MovementDate = stockMovement.MovementDate,
            };
        }

        public static StockMovement MapStockMovementCreateDtoToStockMovement(StockMovementCreateDto stockMovementDto)
        {
            return new StockMovement
            {
                ProductId = stockMovementDto.ProductId,
                Quantity = stockMovementDto.Quantity,
                WarehouseId = stockMovementDto.WarehouseId,
                MovementType = stockMovementDto.MovementType,
            };
        }
    }
}
