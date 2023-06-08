using System;
namespace CoffeShop.WebUI.Shared.Common
{
	public class CollectionResponse<T> : ResponseBase
    {
        public List<T> Items { get; set; } = default!;
    }
}

