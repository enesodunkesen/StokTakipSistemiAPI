namespace StokTakipSistemiAPI.APILayer.DTOs.TransferDTOs
{
    public class TransferDto
    {
        public int TransferId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
