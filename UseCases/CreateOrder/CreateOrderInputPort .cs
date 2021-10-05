using UseCases.Commont.Ports;
using UseCases.DTO.CreateOrder;

namespace UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateOrderInputPort(CreateOrderParams requestData, IOutputPort<int> outputPort)
            => (RequestData, OutputPort) = (requestData, outputPort);
    }
}
