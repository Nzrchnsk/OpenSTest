using System;
using System.IO;
using System.Reflection;
using Core.Events;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace OrderProcessingService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseNpgsql(connectionString: Configuration.GetConnectionString("PostgresConnection")
                )); 
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<EventsFactory>();
            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddHostedService<Worker>();
            services.AddTransient<IExceptionHandler, ExceptionHandler>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("../Logs/mylog-{Date}.txt");
        }
    }
}