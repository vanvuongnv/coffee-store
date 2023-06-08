using System;
namespace CoffeShop.WebUI.Server.Data.Entities
{
	public class Customer : BaseEntity
	{
		public string CustomerName { get; set; } = default!;
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public string Email { get; set; } = default!;
	}
}

