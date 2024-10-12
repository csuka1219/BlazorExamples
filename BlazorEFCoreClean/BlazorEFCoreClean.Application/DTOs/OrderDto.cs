﻿using BlazorEFCoreClean.Domain.Entities;

namespace BlazorEFCoreClean.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
