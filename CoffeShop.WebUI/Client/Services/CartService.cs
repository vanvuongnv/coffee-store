using System;
using Blazored.LocalStorage;
using CoffeShop.WebUI.Shared.Dtos;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace CoffeShop.WebUI.Client.Services
{
	public class CartService : ICartService
	{
        private Cart? _cart { get; set; }

        private readonly ILocalStorageService _localStorageService;

        public CartService(ILocalStorageService localStorageService)
		{
            _localStorageService = localStorageService;
		}

        public async Task AddToCart(int productId)
        {
            await Read();
            _cart?.AddToCart(productId);
            await Save();
        }

        public async Task Save()
        {
            await _localStorageService.SetItemAsync("cart", _cart);
        }

        public async Task Read()
        {
            _cart = await _localStorageService.GetItemAsync<Cart>("cart");
            Console.WriteLine(_cart is null);
            if(_cart is null)
            {
                _cart = new Cart();
            }
        }

    }
}

