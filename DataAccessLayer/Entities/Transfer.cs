using StokTakipSistemiAPI.DataAccessLayer.Entities;
using System;

public class Transfer : IEntity
{
    public int TransferId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int FromWarehouseId { get; set; }
    public Warehouse FromWarehouse { get; set; }
    public int ToWarehouseId { get; set; }
    public Warehouse ToWarehouse { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
}