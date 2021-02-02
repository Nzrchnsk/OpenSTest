using Core.Entities;
using Core.Exceptions;

namespace Core.Helpers.OrderConverters
{
    public class UberConverter : IOrderConverter
    {
        public Order Convert(Order order)
        {
            throw new UberConverterException();
        }
    }
}