using Core.Entities;

namespace Core.Helpers.OrderConverters
{
    public interface IOrderConverter
    {
        public Order Convert(Order order);
    }
}