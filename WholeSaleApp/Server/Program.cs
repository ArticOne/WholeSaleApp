using WholeSaleApp.Server.Data;
using WholeSaleApp.Shared.Model;

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
            builder.Services.AddAutoMapper(typeof(BaseModel).Assembly);
            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                // Do work that can write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });


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
            app.MapControllers();
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