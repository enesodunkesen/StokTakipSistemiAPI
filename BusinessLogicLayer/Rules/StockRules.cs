namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules
{
    public class StockRules
    {
        public static void ValidateStock(Stock stock)
        {
            if (stock.Quantity < 0)
            {
                throw new ArgumentException("Stok miktarı negatif olamaz.");
            }

            if (stock.MinThreshold < 0)
            {
                throw new ArgumentException("Stok minimum eşiği negatif olamaz.");
            }

            if (stock.Quantity < stock.MinThreshold)
            {
                throw new InvalidOperationException("Stok miktarı minimum eşik seviyesinin altına düşemez.");
            }

            if (stock.UpdatedAt > DateTime.Now)
            {
                throw new ArgumentException("Güncelleme tarihi gelecekte olamaz.");
            }
        }
    }
}
