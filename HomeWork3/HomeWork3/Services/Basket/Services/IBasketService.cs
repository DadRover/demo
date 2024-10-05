using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Basket.Contracts.Queries;

namespace HomeWork3.Services.Basket.Services
{
    internal interface IBasketService
    {
        void Add(AddProductCommand command);
        void Remove(RemoveProductCommand command);
        void SendOrder(SendOrderCommand command);
        Product[] GetBasket(GetBasketQuery command);
        decimal GetCostBasket(GetCostBasketQuery command);
    }
}