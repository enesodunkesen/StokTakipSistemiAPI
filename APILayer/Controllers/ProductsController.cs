using Microsoft.AspNetCore.Mvc;
using StokTakipSistemiAPI.APILayer.DTOs.ProductDTOs;
using StokTakipSistemiAPI.APILayer.Mappers;

namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            var productDTOs = products.Select(p => ProductMapper.MapProductToProductDto(p)).ToList();

            return productDTOs;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            var productDTO = ProductMapper.MapProductToProductDto(product);

            if (productDTO == null)
            {
                return NotFound();
            }

            return productDTO;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productDTO)
        {
            var product = ProductMapper.MapProductUpdateDtoToProduct(productDTO);

            if (id != product.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProductAsync(id,product);

            if (updatedProduct != null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductCreateDto productDTO)
        {
            var product = ProductMapper.MapProductCrateDtoToProduct(productDTO);
            await _productService.CreateProductAndStockAsync(product);

            return CreatedAtAction("GetById", new { id = product.Id }, ProductMapper.MapProductToProductDto(product));
        }
    }
}
