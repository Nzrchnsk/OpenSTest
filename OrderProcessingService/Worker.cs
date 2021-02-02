using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Constants;
using Core.Entities;
using Core.Helpers.OrderConverters;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderProcessingService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // We ultimately resolve the actual services we use from the scope we create below.
                    // This ensures that all services that were registered with services.AddScoped<T>()
                    // will be disposed at the end of the service scope (the current iteration).
                    using var scope = _serviceScopeFactory.CreateScope();
                    var orderRepository = scope.ServiceProvider.GetRequiredService<IAsyncRepository<Order>>();

                    var getOrderTask = orderRepository.FirstAsync(new UnconvertedOrderSpecification());
                    IOrderConverter orderConverter = ApplicationConstants.OrderHandlers[getOrderTask.Result.SystemType];
                    orderRepository.UpdateAsync(orderConverter.Convert(getOrderTask.Result));
                    // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(5000, stoppingToken);
                }
                catch (Exception exception)
                {
                    _logger.LogInformation(exception.Message);
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }
    }
}