using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TSKApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // For SeedData (to run)
            //var host = CreateHostBuilder(args).Build();
            //using var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            //SeedData.EnsureSeedData(scope.ServiceProvider);
            //host.Run();
            CreateHostBuilder(args).Build().Run(); //To comment
        }
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    Log.Logger = new LoggerConfiguration()
        //        .ReadFrom.Configuration(configuration)
        //        .CreateLogger();
        //    try
        //    {
        //        Log.Information("App starting up");
        //        CreateHostBuilder(args).Build().Run();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Fatal(ex, "Application failed to start");
        //    }
        //    finally
        //    {
        //        Log.CloseAndFlush();
        //    }
        // }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}