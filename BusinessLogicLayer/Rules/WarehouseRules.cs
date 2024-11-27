namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules
{
    public class WarehouseRules
    {
        public static void ValidateWarehouse(Warehouse warehouse)
        {
            if (string.IsNullOrWhiteSpace(warehouse.Name))
            {
                throw new ArgumentException("Depo adı boş olamaz.");
            }
        }
    }
}
