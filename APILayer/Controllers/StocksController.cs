using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StokTakipSistemiAPI.APILayer.DTOs.StockDTOs;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;

namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StockService _stockService;

        public StocksController(StockService stockService)
        {
            _stockService = stockService;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAllStocksAsync()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            var stocksDtos = stocks.Select(x => StockMapper.MapStockToStockDTO(x)).ToList();

            return Ok(stocksDtos);
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockDto>> GetStockByIdAsync(int id)
        {
            
            var stock = await _stockService.GetStockByIdAsync(id);

            var stockDto = StockMapper.MapStockToStockDTO(stock);

            if (stockDto == null)
            {
                return NotFound();
            }

            return stockDto;
        }
}
}
