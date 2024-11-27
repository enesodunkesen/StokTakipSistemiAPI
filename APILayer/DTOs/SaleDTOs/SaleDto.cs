namespace StokTakipSistemiAPI.APILayer.DTOs.SaleDTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}
