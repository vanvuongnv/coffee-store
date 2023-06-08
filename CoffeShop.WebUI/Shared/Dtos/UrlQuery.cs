using System;
namespace CoffeShop.WebUI.Shared.Dtos
{
	public class UrlQuery
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string? Keyword { get; set; }
	}
}

