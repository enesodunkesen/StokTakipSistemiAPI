using StokTakipSistemiAPI.APILayer.DTOs.TransferDTOs;

namespace StokTakipSistemiAPI.APILayer.Mappers
{
    public class TransferMapper
    {
        public static TransferDto MapTransferToTransferDTO(Transfer transfer)
        {
            return new TransferDto
            {
                TransferId = transfer.TransferId,
                ProductId = transfer.ProductId,
                Quantity = transfer.Quantity,
                TransferDate = transfer.TransferDate,
                ToWarehouseId = transfer.ToWarehouseId,
                FromWarehouseId = transfer.FromWarehouseId,
            };
        }
        public static Transfer MapTransferCreateDtoToTransfer(TransferCreateDto transferDto)
        {
            return new Transfer
            {
                ProductId = transferDto.ProductId,
                Quantity = transferDto.Quantity,
                ToWarehouseId = transferDto.ToWarehouseId,
                FromWarehouseId = transferDto.FromWarehouseId,
            };
        }
    }
}
