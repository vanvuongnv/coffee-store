using System;
namespace CoffeShop.WebUI.Server.Data.Entities
{
	public class Order : BaseEntity
	{
		public DateTimeOffset OrderDate { get; set; }
		public int CustomerId { get; set; }
		public string? OrderNote { get; set; }
		public int OrderStateId { get; set; }
	}
}

