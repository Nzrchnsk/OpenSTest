using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }
        
        
        [HttpPost]
        [Route("{systemType}")]
        public IActionResult Get([FromRoute]string systemType)
        {
            return null;
        }
    }
}