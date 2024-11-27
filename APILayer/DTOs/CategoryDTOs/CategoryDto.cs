namespace StokTakipSistemiAPI.APILayer.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
    }

}
