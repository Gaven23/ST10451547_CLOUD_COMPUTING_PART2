using Microsoft.EntityFrameworkCore;
using Serilog;
using ST10451547_CLOUD_COMPUTING_PART2.Common;
using ST10451547_CLOUD_COMPUTING_PART2.Data.DataStore;
using ST10451547_CLOUD_COMPUTING_PART2.Data;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;

namespace ST10451547_CLOUD_COMPUTING_PART2;

public static class Program
{
    public static void Main(string[] args)
    {
        // use two-stage initialization for serilog
        // configure first in a try/catch block to ensure any configuration issues are appropriately logged
        // https://github.com/serilog/serilog-aspnetcore

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting application");

            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            var app = builder.Build();

            ConfigurePipeline(app);

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigurePipeline(WebApplication app)
    {

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
 

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void ConfigureData(IServiceCollection services, string? smartHubConnectionString)
    {
        if (smartHubConnectionString == null)
        {
            throw new ArgumentNullException(nameof(smartHubConnectionString));
        }

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(smartHubConnectionString);
        });

        services.AddScoped<IDataStore, DataStore>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<UserService>();
    }
}