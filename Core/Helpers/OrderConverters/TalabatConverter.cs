using System;
using System.Globalization;
using System.Text.Json;
using Core.Entities;

namespace Core.Helpers.OrderConverters
{
    /// <summary>
    /// convert all positive price to negative
    /// </summary>
    public class TalabatConverter : IOrderConverter
    {
        
        public Order Convert(Order order)
        {
            //TODO: price type int/double, double format . or ,
            var sourceOrderJson = JsonSerializer.Deserialize<OrderJson>(order.SourceOrder);
            foreach (ProductJson product in sourceOrderJson.Products)
            {
                double paidPriceDouble = Double.Parse(product.PaidPrice);

                if (paidPriceDouble > 0)
                {
                    product.PaidPrice = (paidPriceDouble * (-1)).ToString(CultureInfo.InvariantCulture);
                }
            }

            order.ConvertedOrder = JsonSerializer.Serialize(sourceOrderJson);
            return order;
        }
    }
}