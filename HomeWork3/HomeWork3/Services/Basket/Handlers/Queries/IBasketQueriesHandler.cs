using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Queries;

namespace HomeWork3.Services.Basket.Handlers.Queries
{
    /// <summary>
    /// Обработчик запросов Корзины
    /// </summary>
    internal interface IBasketQueriesHandler
    {
        /// <summary>
        /// Получить корзину
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Product[] Handel(GetBasketQuery command);

        /// <summary>
        /// Получить стоимость корзины
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        decimal Handel(GetCostBasketQuery command);
    }
}