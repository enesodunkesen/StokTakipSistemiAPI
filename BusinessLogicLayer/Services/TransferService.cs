using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class TransferService
    {
        private readonly IRepository<Transfer> _transferRepository;
        private readonly StockService _stockService;

        public TransferService(IRepository<Transfer> repository, StockService stockService)
        {
            _transferRepository = repository;
            _stockService = stockService;
        }

        public async Task<IEnumerable<Transfer>> GetAllTransfersAsync()
        {
            return await _transferRepository.GetAllAsync();
        }

        public async Task<Transfer?> GetTransferByIdAsync(int id)
        {
            return await _transferRepository.GetByIdAsync(id);
        }

        public async Task<Transfer?> CreateTransferAsync(Transfer transfer)
        {
            Warehouse warehouse = await _transferRepository.GetDefaultWarehouse();
            var stocks = await _stockService.GetStockByProductIdAsync(transfer.ProductId);
            var stock = stocks.FirstOrDefault(x => x.Warehouse == warehouse);
            if (stock == null)
            {
                return null;
            }
            int fromWarehouseStock = warehouse.Stocks.FirstOrDefault(stock => stock.ProductId == transfer.ProductId).Quantity;
            TransferRules.ValidateTransfer(transfer, fromWarehouseStock);

            var newTransfer = await _transferRepository.CreateAsync(transfer);

            transfer.TransferDate = DateTime.Now;

            await _stockService.DecreaseStockAsync(stock.Id, transfer.Quantity);

            return newTransfer;
        }
    }
}
