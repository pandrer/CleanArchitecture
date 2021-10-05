using Entities.Interfaces;
using Entities.POCO;
using Entities.Specifications;
using Repositories.EntityFrameworkCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityFrameworkCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly DatabaseContext DatabaseContext;

        public OrderRepository(DatabaseContext databaseContext)
            => DatabaseContext = databaseContext;

        public void Create(Order order)
        {
            DatabaseContext.Add(order);
        }

        public IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return DatabaseContext.Orders.Where(expressionDelegate);
        }
    }
}
