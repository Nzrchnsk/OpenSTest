using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class OrderJson
    {
        public OrderJson()
        {
        }
        public OrderJson(List<ProductJson> products)
        {
            Products = products;
        }

        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }
        
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("products")]
        public List<ProductJson> Products { get; set; }

    }
}