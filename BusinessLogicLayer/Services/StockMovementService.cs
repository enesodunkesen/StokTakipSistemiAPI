using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class StockMovementService
    {
        private readonly IRepository<StockMovement> _stockMovementRepository;
        private readonly StockService _stockService;

        public StockMovementService(IRepository<StockMovement> repository, StockService stockService)
        {
            _stockMovementRepository = repository;
            _stockService = stockService;
        }

        public async Task<IEnumerable<StockMovement>> GetAllStockMovementsAsync()
        {
            return await _stockMovementRepository.GetAllAsync();
        }

        public async Task<StockMovement?> GetStockMovementByIdAsync(int id)
        {
            return await _stockMovementRepository.GetByIdAsync(id);
        }

        public async Task<StockMovement?> CreateStockMovementAsync(StockMovement stockMovement, string movementType)
        {
            Warehouse warehouse = await _stockMovementRepository.GetDefaultWarehouse();
            var stocks = await _stockService.GetStockByProductIdAsync(stockMovement.ProductId);
            var stock = stocks.FirstOrDefault( x => x.Warehouse == warehouse);
            if (stock == null)
            {
                return null;
            }
            StockMovementRules.ValidateStockMovement(stockMovement);

            var newStockMovement = await _stockMovementRepository.CreateAsync(stockMovement);

            stockMovement.MovementDate = DateTime.Now;

            if (movementType == "Çıkarma")
            {
                await _stockService.DecreaseStockAsync(stock.Id, stockMovement.Quantity);
            }
            else
            {
                await _stockService.IncreaseStockAsync(stock.Id, stockMovement.Quantity);
            }
            return newStockMovement;
        }
    }
}
