namespace StokTakipSistemiAPI.APILayer.DTOs.TransferDTOs
{
    public class TransferCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
    }
}
