using StokTakipSistemiAPI.DataAccessLayer.Entities;
using System;

public class StockMovement : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public string MovementType { get; set; }
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
}