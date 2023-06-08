using System;
namespace CoffeShop.WebUI.Server.Data.Entities
{
	public class Product : BaseEntity
	{
		public string ProductName { get; set; } = default!;
		public double Price { get; set; }
		public int UnitsInStock { get; set; }
		public int CategoryId { get; set; }
		public string ImageUrl { get; set; } = default!;
	}
}

