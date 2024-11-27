using StokTakipSistemiAPI.DataAccessLayer;

namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules;
public static class ProductRules
{
    public static void ValidateProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Ürün nesnesi null olamaz.");
        }

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException("Ürün adı boş olamaz.");
        }

        if (product.CategoryId <= 0)
        {
            throw new ArgumentException("Geçerli bir kategori ID'si olmalıdır.");
        }

        if (product.Price <= 0)
        {
            throw new ArgumentException("Ürün fiyatı pozitif bir değer olmalıdır.");
        }

        if (!string.IsNullOrWhiteSpace(product.Size) && product.Size.Length > 10)
        {
            throw new ArgumentException("Ürün boyutu 10 karakterden uzun olamaz.");
        }

        if (!string.IsNullOrWhiteSpace(product.Color) && product.Color.Length > 20)
        {
            throw new ArgumentException("Ürün rengi 20 karakterden uzun olamaz.");
        }

        //if(!IsProductNameUnique(product.Name, dbContext ) )
        //{
        //    throw new ArgumentException("Bu ürün adı zaten mevcut.");
        //}
    }

    //public static bool IsProductNameUnique(string productName, ApplicationDbContext dbContext)
    //{
    //    return !dbContext.Categories.Any(c => c.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
    //}
}
