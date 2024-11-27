using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.APILayer.DTOs.WarehouseDTOs;

namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehousesController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();

            var warehouseDtos = warehouses.Select(x => WarehouseMapper.MapWarehouseToWarehouseDto(x)).ToList();

            return Ok(warehouseDtos);
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetById(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(WarehouseMapper.MapWarehouseToWarehouseDto(warehouse));
        }

        // POST: api/Warehouses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(WarehouseCreateDto warehouseDto)
        {
            var warehouse = WarehouseMapper.MapWarehouseCreateDtoToWareHouse(warehouseDto);
            
            await _warehouseService.CreateWarehouseAsync(warehouse);

            return CreatedAtAction("GetById", new { id = warehouse.Id }, WarehouseMapper.MapWarehouseToWarehouseDto(warehouse));
        }
    }
}
