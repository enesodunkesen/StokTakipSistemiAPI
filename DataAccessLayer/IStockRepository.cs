using StokTakipSistemiAPI.DataAccessLayer.Entities;

namespace StokTakipSistemiAPI.DataAccessLayer
{
    public interface IStockRepository<T> : IRepository<T> where T : Stock
    {
        Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId);
    }
}
