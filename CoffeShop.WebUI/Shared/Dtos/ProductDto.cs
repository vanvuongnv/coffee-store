using System;
namespace CoffeShop.WebUI.Shared.Dtos
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public string? CategoryName { get; set; }
    }
}

