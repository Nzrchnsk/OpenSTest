using System.Configuration;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrderProcessingService
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
        
        // public static void Main(string[] args)
        // {
        //     CreateHostBuilder(args).Build().Run();
        // }
        //
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureServices((hostContext, services) =>
        //         {
        //             services.AddHostedService<Worker>();
        //         });
    }
    
    // public class Program
    // {
    //     public Program(IConfiguration configuration)
    //     {
    //         Configuration = configuration;
    //     }
    //     
    //     private static IConfiguration Configuration { get; set; }
    //     
    //     public static void Main(string[] args)
    //     {
    //         CreateHostBuilder(args).Build().Run();
    //     }
    //     
    //     public static IHostBuilder CreateHostBuilder(string[] args) =>
    //         Host.CreateDefaultBuilder(args)
    //             .ConfigureServices((hostContext, services) =>
    //             {
    //                 services.AddDbContext<OrderContext>(options =>
    //                     options.UseNpgsql(connectionString: Configuration.GetConnectionString("PostgresConnection")
    //                     )); 
    //                 services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
    //                 services.AddHostedService<Worker>();
    //
    //             });
    // }
}