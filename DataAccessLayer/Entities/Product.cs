﻿using System;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public decimal Price { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
}
