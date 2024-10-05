using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Queries;
using HomeWork3.Services.Basket.Repository;

namespace HomeWork3.Services.Basket.Handlers.Queries
{
    internal class BasketQueriesHandler : IBasketQueriesHandler
    {
        private readonly IBasketRepository _basketRepository;

        public BasketQueriesHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Product[] Handel(GetBasketQuery command) =>
            _basketRepository.GetBasket();

        public decimal Handel(GetCostBasketQuery command) =>
            _basketRepository.GetCostBasket();
    }
}
