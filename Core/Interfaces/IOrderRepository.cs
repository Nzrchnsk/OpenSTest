using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order> ,IAggregateRoot
    {
        
    }
}