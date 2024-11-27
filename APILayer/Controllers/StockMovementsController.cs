using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.APILayer.DTOs.StockMovementDTOs;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;


namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementsController : ControllerBase
    {
        private readonly StockMovementService _stockMovementService;

        public StockMovementsController(StockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }

        // GET: api/StockMovements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMovementDto>>> GetAll()
        {

            var stockMovement = await _stockMovementService.GetAllStockMovementsAsync();

            var stockMovementDto = stockMovement.Select(x => StockMovementMapper.MapStockMovementToStockMovementDTO(x)).ToList();

            return Ok(stockMovementDto);
        }

        // GET: api/StockMovements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMovementDto>> GetById(int id)
        {
            var stockMovement = await _stockMovementService.GetStockMovementByIdAsync(id);

            var stockMovementDto = StockMovementMapper.MapStockMovementToStockMovementDTO(stockMovement);

            if (stockMovementDto == null)
            {
                return NotFound();
            }

            return Ok(stockMovementDto);
        }


        // POST: api/StockMovements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockMovement>> Create(StockMovementCreateDto stockMovementDto)
        {
            var stockMovement = StockMovementMapper.MapStockMovementCreateDtoToStockMovement(stockMovementDto);

            await _stockMovementService.CreateStockMovementAsync(stockMovement,stockMovement.MovementType);

            return CreatedAtAction("GetById", new { id = stockMovement.Id }, StockMovementMapper.MapStockMovementToStockMovementDTO(stockMovement));
        }
    }
}
