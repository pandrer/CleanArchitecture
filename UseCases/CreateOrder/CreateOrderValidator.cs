using FluentValidation;
using System.Linq;

namespace UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty().WithMessage("Debe proporcionar el id del cliente");
            RuleFor(c => c.RequestData.ShipAddress).NotEmpty().WithMessage("Debe de proporcionar una direccion");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MinimumLength(3).WithMessage("Debe de proporcionar al menos 3 caracteres del nombre de la ciudad");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MinimumLength(3).WithMessage("Debe de proporcionar al menos 3 caracteres del nombre del pais");
            RuleFor(d => d.RequestData.OrderDetails).Must(d => d != null && d.Any()).WithMessage("Deben especificarse productos.");
        }
    }
}
