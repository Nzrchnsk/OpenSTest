using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.DTO
{
    [Serializable]
    public class Order
    {
        public Order()
        {
            
        }
        
        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }
        
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

    }
}