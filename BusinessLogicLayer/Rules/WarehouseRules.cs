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

            if (warehouse.Stocks == null || warehouse.Stocks.Count == 0)
            {
                throw new ArgumentException("Depo en az bir stok içermelidir.");
            }

            // Aynı isimde depo olup olmadığını kontrol et (örnek):
            // if (IsWarehouseNameExists(warehouse.Name)) throw new ArgumentException("Bu depo adı zaten mevcut.");
        }
    }
}
