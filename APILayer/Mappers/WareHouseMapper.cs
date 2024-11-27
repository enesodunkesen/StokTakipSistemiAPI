using StokTakipSistemiAPI.APILayer.DTOs.WarehouseDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class WarehouseMapper
    {
        public static WarehouseDto MapWarehouseToWarehouseDto(Warehouse wareHouse)
        {
            return new WarehouseDto
            {
                Id = wareHouse.Id,
                Name = wareHouse.Name,
                Stocks = wareHouse.Stocks.Select(x => x.Id).ToList() ?? new List<int>(),
            };
        }

        public static Warehouse MapWarehouseCreateDtoToWareHouse(WarehouseCreateDto warehouseDto)
        {
            return new Warehouse
            {
                Name = warehouseDto.Name,
            };
        }
    }
}