using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using System.Threading.Tasks;
using UseCases.CreateOrder;
using UseCases.DTO.CreateOrder;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator Mediator;

        public OrderController(IMediator mediator) =>
            Mediator = mediator;

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams createOrderParams)
        {
            CreateOrderPresenter presenter = new CreateOrderPresenter();
            await Mediator.Send(new CreateOrderInputPort(createOrderParams, presenter));
            return presenter.Content;
        }
    }
}
