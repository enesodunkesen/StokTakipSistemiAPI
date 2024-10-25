namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules
{
    public class SaleRules
    {
        public static void ValidateSale(Sale sale, int availableStock)
        {
            if (sale.Quantity <= 0)
            {
                throw new ArgumentException("Satış miktarı pozitif olmalıdır.");
            }

            if (sale.Quantity > availableStock)
            {
                throw new InvalidOperationException("Yeterli stok yok.");
            }

            if (sale.TotalAmount <= 0)
            {
                throw new ArgumentException("Satış toplam tutarı pozitif olmalıdır.");
            }

            if (sale.Price < 0)
            {
                throw new ArgumentException("Satış fiyatı negatif olamaz.");
            }

            if (sale.SaleDate > DateTime.Now)
            {
                throw new ArgumentException("Satış tarihi gelecekte olamaz.");
            }
        }
    }
}
