using System;
namespace CoffeShop.WebUI.Client.Services
{
	public interface ICartService
	{
		Task AddToCart(int productId);
	}
}

