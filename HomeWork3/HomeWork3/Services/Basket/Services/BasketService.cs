using HomeWork3.Services.Basket.Handlers.Commands;
using HomeWork3.Services.Basket.Handlers.Queries;
using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Basket.Contracts.Queries;

namespace HomeWork3.Services.Basket.Services
{
    internal class BasketService : IBasketService
    {

        private readonly IBasketCommandsHandler _commandHandler;
        private readonly IBasketQueriesHandler _queryHandler;

        public BasketService(IBasketCommandsHandler basketCommandsHandler, IBasketQueriesHandler basketQueriesHandler)
        {
            _commandHandler = basketCommandsHandler;
            _queryHandler = basketQueriesHandler;
        }
        public void Add(AddProductCommand command) =>
            _commandHandler.Handel(command);

        public void Remove(RemoveProductCommand command) =>
            _commandHandler.Handel(command);

        public void SendOrder(SendOrderCommand command) =>
            _commandHandler.Handel(command);

        public Product[] GetBasket(GetBasketQuery command) =>
            _queryHandler.Handel(command);

        public decimal GetCostBasket(GetCostBasketQuery command) =>
            _queryHandler.Handel(command);
    }
}
