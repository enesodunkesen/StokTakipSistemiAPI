using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;


namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class StockService
    {
        private readonly IStockRepository<Stock> _stockRepository;

        public StockService(IStockRepository<Stock> repository)
        {
            _stockRepository = repository;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await _stockRepository.GetAllAsync();
        }

        public async Task<Stock?> CreateStockForProductAsync(Product product)
        {
            Warehouse warehouse = await _stockRepository.GetDefaultWarehouse();
            var stock = new Stock
            {
                Product = product,
                ProductId = product.Id,
                Warehouse = warehouse,
                WarehouseId = warehouse.Id,
                Quantity = 0,
                MinThreshold = 10,
                UpdatedAt = DateTime.Now,
            };
            return await _stockRepository.CreateAsync(stock);
        }
        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            return await _stockRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId)
        {
            // Validate input
            if (productId <= 0)
                throw new ArgumentException("ProductId must be greater than zero.", nameof(productId));

            // Call repository method
            var stocks = await _stockRepository.GetStockByProductIdAsync(productId);

            // Check if no stock entries found
            if (stocks == null || !stocks.Any())
                throw new Exception($"No stock found for ProductId: {productId}");

            return stocks;
        }


        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stock = await GetStockByIdAsync(id);
            if (stock == null) { throw new ArgumentException("Stok bulunamadı!"); }
            if (stock.Quantity > 0) { throw new ArgumentException("Stokta ürün varken silinemez!"); }
            return await _stockRepository.DeleteAsync(id);
        }

        public async Task IncreaseStockAsync(int stockId, int quantity)
        {
            var stock = await _stockRepository.GetByIdAsync(stockId);

            if (stock == null) throw new Exception("Stok bulunamadı.");


            stock.Quantity += quantity;
            stock.UpdatedAt = DateTime.Now;

            await _stockRepository.UpdateAsync(stockId, stock);
        }

        public async Task DecreaseStockAsync(int stockId, int quantity)
        {
            // Fetch stock from the repository
            var stock = await _stockRepository.GetByIdAsync(stockId);
            if (stock == null)
                throw new Exception("Stok bulunamadı");

            // Ensure there is sufficient stock to decrease
            if (stock.Quantity < quantity)
                throw new Exception("Yetersiz stok");

            // Update stock quantity
            stock.Quantity -= quantity;
            stock.UpdatedAt = DateTime.Now;
            await _stockRepository.UpdateAsync(stock.Id, stock);
        }
    }

}
