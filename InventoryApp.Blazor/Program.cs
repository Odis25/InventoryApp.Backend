using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InventoryApp.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddAuthorizationCore();
            builder.Services.AddOidcAuthentication(options =>
            {
                //builder.Configuration.Bind("Local", options.ProviderOptions);
                options.ProviderOptions.Authority = "https://localhost:10001/";
                options.ProviderOptions.ClientId = "inventory-web-api";
                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("inventoryapp_role");
                options.ProviderOptions.DefaultScopes.Add("InventoryAPI");
                options.ProviderOptions.ResponseType = "code";

                options.UserOptions.RoleClaim = "inventoryapp_role";
            });

            await builder.Build().RunAsync();
        }
    }
}
