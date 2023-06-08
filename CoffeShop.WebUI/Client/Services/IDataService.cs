using System;
using CoffeShop.WebUI.Shared.Commands;
using CoffeShop.WebUI.Shared.Dtos;

namespace CoffeShop.WebUI.Client.Services
{
	public interface IDataService
	{
		Task<List<CategoryDto>?> GetCategoriesAsync();
		Task<CategoryDto?> GetCategoryAsync(int id);
		Task<CategoryDto?> CreateCategoryAsync(CategoryCommand command);
		Task<bool> UpdateCategoryAsync(int id, CategoryCommand command);
		Task<bool> DeleteCategoryAsync(int id);
	}
}

