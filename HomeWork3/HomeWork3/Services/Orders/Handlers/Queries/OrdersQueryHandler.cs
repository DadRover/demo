using System.Collections.Generic;
using System.Linq;
using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Queries;
using HomeWork3.Services.Orders.Repository;

namespace HomeWork3.Services.Orders.Handlers.Queries
{
    internal class OrdersQueryHandler : IOrdersQueryHandler
    {
        private readonly IEventOrdersRepository _eventRepository;

        public OrdersQueryHandler(IEventOrdersRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public OrderDto Handel(GetOrderByIdQuery command) =>
            GetOrderById(command.OrderId);

        public OrderDto[] Handel(GetOrdersQuery command)
        {
            var orderIds = _eventRepository.GetAllIds();
            List<OrderDto> orderDto = new List<OrderDto>();
            foreach (var orderId in orderIds)
            {
                orderDto.Add(GetOrderById(orderId));
            }

            return orderDto.ToArray();
        }

        private OrderDto GetOrderById(int id)
        {
            var events = _eventRepository.GetEvents(id);
            if (!events.Any()) return null;
            var order = new Order(events);
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Products = order.Products,
                IsCompleted = order.IsCompleted
            };
        }
    }
}
