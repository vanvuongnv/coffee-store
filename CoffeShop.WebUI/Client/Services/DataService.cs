using System;
using CoffeShop.WebUI.Shared.Commands;
using CoffeShop.WebUI.Shared.Common;
using CoffeShop.WebUI.Shared.Dtos;

namespace CoffeShop.WebUI.Client.Services
{
	public class DataService : IDataService
    {
		private readonly IHttpService _httpService;

		public DataService(IHttpService httpService)
		{
			_httpService = httpService;
		}

        public async Task<CategoryDto?> CreateCategoryAsync(CategoryCommand command)
        {
            return await _httpService.PostAsync<CategoryDto>(ApiUrls.CategoryUrls.CreateCategory, command);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _httpService.DeleteAsync(ApiUrls.CategoryUrls.DeleteCategory(id));
        }

        public async Task<List<CategoryDto>?> GetCategoriesAsync()
        {
            return await _httpService.GetAsync<List<CategoryDto>>(ApiUrls.CategoryUrls.GetCategories);
        }

        public async Task<CategoryDto?> GetCategoryAsync(int id)
        {
            return await _httpService.GetAsync<CategoryDto>(ApiUrls.CategoryUrls.GetCategoryById(id));
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryCommand command)
        {
            return await _httpService.PutAsync(ApiUrls.CategoryUrls.UpdateCategory(id), command);
        }
    }
}

