namespace StokTakipSistemiAPI.DataAccessLayer.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(); //tüm ürünleri getirir.
        Task<Product> GetByIdAsync(int id); //Verilen id değerine sahip tek bir ürünü getirir. Eğer ürün bulunamazsa hata fırlatır.
        Task AddAsync(Product product); //Yeni bir ürün ekler ve değişiklikleri kaydeder.
        Task UpdateAsync(Product product); //Var olan bir ürünü günceller ve değişiklikleri kaydeder.
        Task DeleteAsync(int id); //Verilen id'ye sahip ürünü siler ve değişiklikleri kaydeder.
    }
}
