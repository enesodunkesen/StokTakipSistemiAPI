using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemiAPI.APILayer.Mappers;
using StokTakipSistemiAPI.APILayer.DTOs;
using StokTakipSistemiAPI.BusinessLogicLayer.Services;
using StokTakipSistemiAPI.APILayer.DTOs.TransferDTOs;

namespace StokTakipSistemiAPI.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly TransferService _transferService;

        public TransfersController(TransferService transferService)
        {
            _transferService = transferService;
        }

        // GET: api/Transfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferDto>>> GetAll()
        {
            var transfers = await _transferService.GetAllTransfersAsync();

            var transferDtos = transfers.Select(x => TransferMapper.MapTransferToTransferDTO(x)).ToList();

            return Ok(transferDtos);
        }

        // GET: api/Transfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDto>> GetById(int id)
        {
            var transfer = await _transferService.GetTransferByIdAsync(id);

            var transferDto = TransferMapper.MapTransferToTransferDTO(transfer);

            if (transfer == null)
            {
                return NotFound();
            }

            return Ok(transferDto);
        }


        // POST: api/Transfers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transfer>> CrateTransfer(TransferCreateDto transferDto)
        {
            var transfer = TransferMapper.MapTransferCreateDtoToTransfer(transferDto);
            await _transferService.CreateTransferAsync(transfer);

            return CreatedAtAction("GetById", new { id = transfer.TransferId }, TransferMapper.MapTransferToTransferDTO(transfer));
        }
    }
}
