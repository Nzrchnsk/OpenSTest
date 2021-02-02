using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }
    }
}