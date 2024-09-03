﻿namespace FinalApp_ECommerce_WebAPI.Infrastructure.DTOs
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
