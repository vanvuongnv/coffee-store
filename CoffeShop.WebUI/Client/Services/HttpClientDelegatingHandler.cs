using System;
namespace CoffeShop.WebUI.Client.Services
{
	public class HttpClientDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger _logger;
        public HttpClientDelegatingHandler(ILogger<HttpClientDelegatingHandler> logger)
        {
            _logger = logger;

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // custom request headers
            
            var response = await base.SendAsync(request, cancellationToken);

            // audit, log response
            
            return response;
        }
    }
}

