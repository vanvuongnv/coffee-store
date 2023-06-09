using System;
namespace CoffeShop.WebUI.Shared.Dtos
{
	public class Cart
	{
		public ICollection<CartLine> Lines { get; set; }
		public Cart()
		{
			Lines = new List<CartLine>();
		}

		public void AddToCart(int productId)
		{
			Console.WriteLine(productId);
			var line = Lines.FirstOrDefault(x => x.ProductId == productId);
			if(line is null)
			{
				Console.WriteLine("line is null");
				line = new CartLine()
				{
					ProductId = productId,
					Quantity = 1
				};
				Lines.Add(line);
			}
			else
			{
				line.Quantity += 1;
			}
			Console.WriteLine(line.Quantity);
		}
	}
}

