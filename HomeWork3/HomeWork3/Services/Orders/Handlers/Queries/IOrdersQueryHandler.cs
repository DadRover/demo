using System.Collections.Generic;
using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Queries;

namespace HomeWork3.Services.Orders.Handlers.Queries
{
    /// <summary>
    /// Обработчиик запросов Заказов
    /// </summary>
    internal interface IOrdersQueryHandler
    {
        /// <summary>
        /// Получить заказ по идентификатору
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        OrderDto Handel(GetOrderByIdQuery command);

        /// <summary>
        /// Получить заказы
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        OrderDto[] Handel(GetOrdersQuery command);
    }
}