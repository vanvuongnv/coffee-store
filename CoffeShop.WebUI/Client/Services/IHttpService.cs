using System;
namespace CoffeShop.WebUI.Client.Services
{
	public interface IHttpService
	{
        Task<T?> GetAsync<T>(string url) where T : class;
        Task<T?> PostAsync<T>(string url, object data) where T : class;
        Task<bool> PutAsync(string url, object data);
        Task<bool> DeleteAsync(string url);
    }
}

