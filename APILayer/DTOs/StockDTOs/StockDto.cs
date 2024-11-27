namespace StokTakipSistemiAPI.APILayer.DTOs.StockDTOs
{
    public class StockDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public int MinThreshold { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
