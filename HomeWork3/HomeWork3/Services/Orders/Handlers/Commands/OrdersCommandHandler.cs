using HomeWork3.Services.Orders.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Events;
using HomeWork3.Services.Orders.Repository;

namespace HomeWork3.Services.Orders.Handlers.Commands
{
    internal class OrdersCommandHandler : IOrdersCommandHandler
    {
        private readonly IEventOrdersRepository _eventRepository;

        public OrdersCommandHandler(IEventOrdersRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        ///<inheritdoc/>
        public int Handel(CreateOrderCommand command)
        {
            var orderId = _eventRepository.GetNextId();
            var orderCreatedEvent = new OrderCreatedEvent(orderId, command.CustomerName);
            _eventRepository.SaveEvent(orderCreatedEvent);
            return orderId;
        }

        ///<inheritdoc/>
        public void Handel(AddProductsToOrderCommand command)
        {
            foreach (var product in command.Products)
            {
                var productAddedEvent = new ProductAddedToOrderEvent(command.OrderId, product.ProductName, product.Quantity, product.Price);
                _eventRepository.SaveEvent(productAddedEvent);

            }
        }

        ///<inheritdoc/>
        public void Handel(CompleteOrderCommand command)
        {
            var orderCompletedEvent = new OrderCompletedEvent(command.OrderId);
            _eventRepository.SaveEvent(orderCompletedEvent);
        }
    }
}
