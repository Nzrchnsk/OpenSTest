using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Constants;
using Core.Entities;
using Core.Events;
using Core.Helpers.OrderConverters;
using Core.Interfaces;
using Core.Services;
using Core.Specifications;
using Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderProcessingService
{
    public class Worker : BackgroundService
    {
        // private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly EventsFactory _eventsFactory;
        private IExceptionHandler _exceptionHandler;

        public Worker(IServiceScopeFactory serviceScopeFactory, EventsFactory eventsFactory, IAppLogger<ExceptionHandler> exeptionHandlerLogger)
        {
            _eventsFactory = eventsFactory;
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
            _exceptionHandler = new ExceptionHandler(eventsFactory, exeptionHandlerLogger);
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
                    var getOrder = await orderRepository.FirstAsync(new UnconvertedOrderSpecification());
                    IOrderConverter orderConverter = ApplicationConstants.OrderHandlers[getOrder.SystemType];
                    await orderRepository.UpdateAsync(orderConverter.Convert(getOrder));
                    // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                catch (Exception exception)
                {
                    _eventsFactory.ExceptionThrow.Raise(exception);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}