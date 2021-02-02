using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.DTO
{
    [Serializable]
    public class Order
    {
        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }
        
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

    }
}