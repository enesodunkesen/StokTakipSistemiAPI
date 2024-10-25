namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules
{
    public class TransferRules
    {
        public static void ValidateTransfer(Transfer transfer, int fromWarehouseStock)
        {
            if (transfer.Quantity <= 0)
            {
                throw new ArgumentException("Transfer miktarı pozitif olmalıdır.");
            }

            if (transfer.FromWarehouseId == transfer.ToWarehouseId)
            {
                throw new ArgumentException("Gönderen ve alan depo aynı olamaz.");
            }

            if (transfer.TransferDate > DateTime.Now)
            {
                throw new ArgumentException("Transfer tarihi gelecekte olamaz.");
            }

            if (transfer.Quantity > fromWarehouseStock)
            {
                throw new InvalidOperationException("Gönderen depoda yeterli stok yok.");
            }
        }
    }
}
