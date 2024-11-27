namespace StokTakipSistemiAPI.APILayer.DTOs.StockMovementDTOs
{
    public class StockMovementCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
        public string MovementType { get; set; }
    }
}
