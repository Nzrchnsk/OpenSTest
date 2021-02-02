using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public class UnconvertedOrderSpecification : Specification<Order>
    {
        public UnconvertedOrderSpecification()
        {
            Query
                .Where(o => o.ConvertedOrder == null);
        }
    }
}