using System;
namespace CoffeShop.WebUI.Shared.Common
{
	public class Response<T> : ResponseBase
    {
		public T Item { get; set; } = default!;
	}
}

