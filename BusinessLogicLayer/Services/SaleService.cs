using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class SaleService
    {
        private readonly IRepository<Sale> _saleRepository;
        private readonly StockService _stockService;

        public SaleService(IRepository<Sale> repository, StockService stockService)
        {
            _saleRepository = repository;
            _stockService = stockService;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.GetAllAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        public async Task<Sale?> CreateSaleAsync(Sale sale, Warehouse warehouse)
        {
            var stocks = await _stockService.GetStockByProductIdAsync(sale.ProductId);

            var stock = stocks.FirstOrDefault(x => x.Warehouse == warehouse);

            if (stock == null)
            {
                return null;
            }
            SaleRules.ValidateSale(sale, stock.Quantity);

            var newSale = await _saleRepository.CreateAsync(sale);

            sale.SaleDate = DateTime.Now;

            await _stockService.DecreaseStockAsync(stock.Id, sale.Quantity);

            return newSale;
        }
    }
}
