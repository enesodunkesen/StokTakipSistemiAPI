namespace StokTakipSistemiAPI.APILayer.DTOs.ProductDTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
