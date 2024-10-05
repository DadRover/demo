using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Basket.Contracts.Queries;
using HomeWork3.Services.Basket.Handlers.Commands;
using HomeWork3.Services.Basket.Handlers.Queries;

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

        ///<inheritdoc/>
        public void Add(AddProductCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public void Remove(RemoveProductCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public void SendOrder(SendOrderCommand command) =>
            _commandHandler.Handel(command);

        ///<inheritdoc/>
        public Product[] GetBasket(GetBasketQuery command) =>
            _queryHandler.Handel(command);

        ///<inheritdoc/>
        public decimal GetCostBasket(GetCostBasketQuery command) =>
            _queryHandler.Handel(command);
    }
}
