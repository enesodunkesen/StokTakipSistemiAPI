using StokTakipSistemiAPI.DataAccessLayer.Entities;
using System.Collections.Generic;

public class Warehouse : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Stock> Stocks { get; set; }
}