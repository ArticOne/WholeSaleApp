using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Client.Services.Repositories;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient();
            builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            builder.Services.AddScoped<IMenuItemsRepository, MenuItemsRepository>();
            builder.Services.AddAutoMapper(typeof(BaseDto).Assembly);
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}