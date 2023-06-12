using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text.Json;
using WholeSaleApp.Client;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Server.Services;

namespace WholeSaleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<WsDbContext>();
            builder.Services.AddScoped<IMapperService, MapperService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            Zezancija(app);

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            var proba = app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }

        private static void Zezancija(WebApplication app)
        {

            app.Use(probatest());
            app.MapGet("/proba", () => "Hello World Proba!");
        }

        private static Func<HttpContext, RequestDelegate, Task> probatest()
        {
            return async (context, next) =>
            {
                var currentEndpoint = context.GetEndpoint();

                if (currentEndpoint is null)
                {
                    await next(context);
                    return;
                }

                Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

                if (currentEndpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern}");
                }

                foreach (var endpointMetadata in currentEndpoint.Metadata)
                {
                    Console.WriteLine($"  - Metadata: {endpointMetadata}");
                }

                await next(context);
            };
        }
    }
}