using System.Collections.Generic;

public class Warehouse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Stock>? Stocks { get; set; }
}