using System;
using System.Globalization;
using System.Text.Json;
using Core.Entities;

namespace Core.Helpers.OrderConverters
{
    /// <summary>
    /// divides all prices by quantity
    /// </summary>
    public class ZomatoConverter : IOrderConverter
    {
        public Order Convert(Order order)
        {
            //TODO: convert paid, unit or both? price type int/double, double format . or ,
            var sourceOrderJson = JsonSerializer.Deserialize<OrderJson>(order.SourceOrder);
            foreach (ProductJson product in sourceOrderJson.Products)
            {
                double paidPriceDouble = Double.Parse(product.PaidPrice);
                double unitPriceDouble = Double.Parse(product.PaidPrice);

                int quantity = int.Parse(product.Quantity);

                product.PaidPrice = (paidPriceDouble / quantity).ToString(CultureInfo.InvariantCulture);
            }
            
            order.ConvertedOrder = JsonSerializer.Serialize(sourceOrderJson);
            return order;
        }
    }
}