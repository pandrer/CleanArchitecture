using Entities.POCO;
using Entities.Specifications;
using System.Collections.Generic;

namespace Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification);
    }
}
