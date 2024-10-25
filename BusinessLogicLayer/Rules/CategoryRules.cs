public class CategoryRules
{
    public static void ValidateCategory(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException("Kategori adı boş olamaz.");
        }

        if (category.Name.Length < 3)
        {
            throw new ArgumentException("Kategori adı en az 3 karakter olmalıdır.");
        }

        if (category.Products == null || category.Products.Count == 0)
        {
            throw new ArgumentException("Kategori en az bir ürün içermelidir.");
        }

        // Aynı isimde kategori olup olmadığını kontrol et (örnek):
        // if (IsCategoryNameExists(category.Name)) throw new ArgumentException("Bu kategori adı zaten mevcut.");
    }
}