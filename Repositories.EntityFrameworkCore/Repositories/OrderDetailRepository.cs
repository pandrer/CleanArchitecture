using Entities.Interfaces;
using Entities.POCO;
using Repositories.EntityFrameworkCore.DataContext;
using System;

namespace Repositories.EntityFrameworkCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly DatabaseContext DatabaseContext;

        public OrderDetailRepository(DatabaseContext databaseContext)
            => DatabaseContext = databaseContext;

        public void Create(OrderDetail orderDetail)
        {
            DatabaseContext.Add(orderDetail);
        }
    }
}
