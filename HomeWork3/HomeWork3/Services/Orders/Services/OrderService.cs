﻿using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Queries;
using HomeWork3.Services.Orders.Handlers.Commands;
using HomeWork3.Services.Orders.Handlers.Queries;

namespace HomeWork3.Services.Orders.Services
{
    /// <summary>
    /// Сервис заказов.
    /// </summary>
    internal class OrderService : IOrderService
    {
        private readonly IOrdersCommandHandler _commandHandler;
        private readonly IOrdersQueryHandler _queryHandler;

        public OrderService(IOrdersCommandHandler ordersCommandHandler, IOrdersQueryHandler ordersQueryHandler)
        {
            _commandHandler = ordersCommandHandler;
            _queryHandler = ordersQueryHandler;
        }

        ///<inheritdoc/>
        public int CreateOrder(CreateOrderCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public void AddProductOrder(AddProductsToOrderCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public void CompleteOrder(CompleteOrderCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public OrderDto GetOrder(GetOrderByIdQuery command) =>
            _queryHandler.Handel(command);

        ///<inheritdoc/>
        public OrderDto[] GetOrders(GetOrdersQuery command) =>
            _queryHandler.Handel(command);
    }
}
