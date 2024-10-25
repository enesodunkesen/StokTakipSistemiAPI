namespace StokTakipSistemiAPI.BusinessLogicLayer.Rules;
public class ProductRules
{
    public bool ValidateProductName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    public bool ValidateProductPrice(decimal price)
    {
        return price > 0;
    }

    // Diğer iş kuralları burada tanımlanabilir
}