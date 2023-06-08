using System;
using System.Text;
using Newtonsoft.Json;

namespace CoffeShop.WebUI.Client.Services
{
	public class HttpService : IHttpService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _apiClient;
        public HttpService(ILogger<HttpService> logger,
            HttpClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _apiClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                _logger.LogDebug("HTTP DELETE: {0} FAIL. Detail {1}", url, responseString);
                return false;
            }
        }

        public async Task<T?> GetAsync<T>(string url) where T : class
        {
            var response = await _apiClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogDebug("HTTP GET: {0} FAIL. Detail {1}", url, responseString);
            }
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<T?> PostAsync<T>(string url, object data) where T : class
        {
            var response = await _apiClient.PostAsync(url, GetContent(data));
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            else
            {
                _logger.LogDebug("HTTP POST: {0} FAIL. Detail {1}", url, responseString);
                return default;
            }
        }

        public async Task<bool> PutAsync(string url, object data)
        {
            var response = await _apiClient.PutAsync(url, GetContent(data));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                _logger.LogDebug("HTTP PUT: {0} FAIL. Detail {1}", url, responseString);
                return false;
            }
        }

        private StringContent? GetContent(object? obj)
        {
            if (obj is null)
            {
                return null;
            }
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}

