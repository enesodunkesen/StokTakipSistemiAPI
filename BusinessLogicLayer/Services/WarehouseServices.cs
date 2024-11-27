using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Services
{
    public class WarehouseService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        public WarehouseService(IRepository<Warehouse> repository)
        {
            _warehouseRepository = repository; }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Warehouse?> GetWarehouseByIdAsync(int id)
        {
            return await _warehouseRepository.GetByIdAsync(id);
        }

        public async Task<Warehouse?> CreateWarehouseAsync(Warehouse warehouse)
        {
            WarehouseRules.ValidateWarehouse(warehouse);

            return await _warehouseRepository.CreateAsync(warehouse);
        }
    }
}
