namespace StokTakipSistemiAPI.APILayer.DTOs.WarehouseDTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Stocks { get; set; }
    }
}
