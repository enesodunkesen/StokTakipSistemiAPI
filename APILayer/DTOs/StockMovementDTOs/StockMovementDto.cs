namespace StokTakipSistemiAPI.APILayer.DTOs.StockMovementDTOs
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
