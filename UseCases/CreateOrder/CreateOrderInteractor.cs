using Entities.Exceptions;
using Entities.Interfaces;
using Entities.POCO;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Commont.Ports;

namespace UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        => (OrderRepository, OrderDetailRepository, UnitOfWork) = (orderRepository, orderDetailRepository, unitOfWork);

        protected async override Task Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAddress,
                ShipCity = request.RequestData.ShipCity,
                ShipCountry = request.RequestData.ShipCountry,
                ShipPostalCode = request.RequestData.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(order);
            foreach (var item in request.RequestData.OrderDetails)
            {
                OrderDetailRepository.Create(new OrderDetail
                {
                    ProductId = item.ProductId,
                    Order = order,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice = item.UnitPrice
                });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden", ex.Message);
            }
            request.OutputPort.Handle(order.Id);
        }
    }
}
