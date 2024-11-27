using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Core.Types;
using StokTakipSistemiAPI.BusinessLogicLayer.Rules;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;
using StokTakipSistemiAPI.DataAccessLayer;

public class ProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly StockService _stockService;
    private readonly CategoryService _categoryService;

    public ProductService(IRepository<Product> repository, StockService stockService, CategoryService categoryService)
    {
        _productRepository = repository;
        _stockService = stockService;
        _categoryService = categoryService;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product?> CreateProductAndStockAsync(Product product)
    {
        ProductRules.ValidateProduct(product);
        var category = await _categoryService.GetCategoryByIdAsync(product.CategoryId);
        await _stockService.CreateStockForProductAsync(product);
        product.UpdatedAt = DateTime.Now;

        product.UpdatedAt = DateTime.Now;
        return await _productRepository.CreateAsync(product);
    }

    public async Task<Product?> UpdateProductAsync(int id,Product newProduct)
    {
        ProductRules.ValidateProduct(newProduct);
        newProduct.UpdatedAt = DateTime.Now;
        return await _productRepository.UpdateAsync(id, newProduct);
    }

    public async Task<Product?> DeleteProductAsync(int id)
    {
        //todo
        throw new NotImplementedException();
    }
}