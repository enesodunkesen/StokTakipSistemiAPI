using StokTakipSistemiAPI.DataAccessLayer;

public class CategoryRules
{

    public static void ValidateCategory(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Kategori nesnesi null olamaz.");
        }

        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException("Kategori adı boş olamaz.");
        }

        if (category.Name.Length < 3)
        {
            throw new ArgumentException("Kategori adı en az 3 karakter olmalıdır.");
        }
    }

}