using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Queries;

namespace HomeWork3.Services.Basket.Handlers.Queries
{
    internal interface IBasketQueriesHandler
    {
        Product[] Handel(GetBasketQuery command);

        decimal Handel(GetCostBasketQuery command);
    }
}