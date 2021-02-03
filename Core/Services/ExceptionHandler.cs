using System;
using System.Threading.Tasks;
using Core.Events;
using Core.Interfaces;

namespace Core.Services
{
    public class ExceptionHandler :  BaseHandler, IExceptionHandler
    {
        private readonly IAppLogger<ExceptionHandler> _logger;
        public ExceptionHandler(EventsFactory eventsFactory, IAppLogger<ExceptionHandler> logger) : base(eventsFactory)
        {
            EventsFactory.ExceptionThrow.ExceptionThrowEvent += LogException;
            _logger = logger;
        }

        public async Task LogException(Exception exceptions)
        {
            _logger.LogInformation("DateTime: {time}\nException: {exceptionMessage}", DateTimeOffset.Now, exceptions.Message);
            await Task.Delay(10000);
        }
    }
}