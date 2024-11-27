namespace StokTakipSistemiAPI.DataAccessLayer
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        Task<T?> GetCategoryWithProductsByIdAsync(int id);
    }
}
