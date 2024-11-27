using StokTakipSistemiAPI.DataAccessLayer.Entities;
using System;

public class Sale : IEntity
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}