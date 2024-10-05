using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;

namespace HomeWork3.Services.Basket.Repository
{
    internal interface IBasketRepository
    {
        void Add(Product product);
        void Remove(string productName);
        Product[] GetBasket();
        decimal GetCostBasket();
        void Clear();
    }
}
