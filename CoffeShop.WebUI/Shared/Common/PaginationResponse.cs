using System;
namespace CoffeShop.WebUI.Shared.Common
{
	public class PaginationResponse<T> : ResponseBase
    {
        public List<T> Items { get; set; } = default!;
        public int Total { get; set; }

        public static PaginationResponse<T> Success(List<T> items, int total) => new PaginationResponse<T>()
        {
            Items = items,
            Message = "",
            State = true,
            Total = total
        };
    }
}

