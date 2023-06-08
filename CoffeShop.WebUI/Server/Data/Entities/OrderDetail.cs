using System;
namespace CoffeShop.WebUI.Server.Data.Entities
{
	public class OrderDetail : BaseEntity
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }
	}
}

