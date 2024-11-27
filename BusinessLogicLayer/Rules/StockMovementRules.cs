namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules
{
    public class StockMovementRules
    {
        private static readonly string[] ValidMovementTypes = { "Ekleme", "Çıkarma" };

        public static void ValidateStockMovement(StockMovement movement)
        {
            if (movement.Quantity <= 0)
            {
                throw new ArgumentException("Stok hareketi miktarı pozitif olmalıdır.");
            }

            if (!Array.Exists(ValidMovementTypes, type => type == movement.MovementType))
            {
                throw new ArgumentException("Geçersiz stok hareket türü.");
            }

            if (movement.MovementDate > DateTime.Now)
            {
                throw new ArgumentException("Stok hareket tarihi gelecekte olamaz.");
            }

        }
    }
}
