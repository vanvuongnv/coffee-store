using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CoffeShop.WebUI.Client;
using CoffeShop.WebUI.Client.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Http Interceptor 
builder.Services.AddTransient<HttpClientDelegatingHandler>();

builder.Services.AddHttpClient<IHttpService, HttpService>(options =>
{
    options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<HttpClientDelegatingHandler>();

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();

