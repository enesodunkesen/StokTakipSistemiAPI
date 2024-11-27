using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.APILayer.DTOs.SaleDTOs;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;

namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetAll()
        {
            var sales = await _saleService.GetAllSalesAsync();

            var saleDtos = sales.Select(x => SaleMapper.MapSaleToSaleDTO(x)).ToList();

            return Ok(saleDtos);
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetById(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);

            var saleDto = SaleMapper.MapSaleToSaleDTO(sale);

            if (saleDto == null)
            {
                return NotFound();
            }

            return saleDto;
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> CreateSale(SaleCreateDto saleDto)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
