using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IAsyncRepository<Core.Entities.Order>  _orderRepository;

        public OrderController(ILogger<OrderController> logger, IAsyncRepository<Core.Entities.Order> orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }


        [HttpPost]
        [Route("{systemType}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get([FromRoute] string systemType, [FromBody] Order order)
        {
            _orderRepository.AddAsync(new Core.Entities.Order
            {
                ConvertedOrder = null,
                CreatedAt = order.CreatedAt,
                OrderNumber = order.OrderNumber,
                SystemType = systemType,
                SourceOrder = System.Text.Json.JsonSerializer.Serialize(order)
            });
            return NoContent();
        }
    }
}