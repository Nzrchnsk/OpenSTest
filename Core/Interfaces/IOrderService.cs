using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        public Order ConvertOrder(Order order, string systemType);
    }
}