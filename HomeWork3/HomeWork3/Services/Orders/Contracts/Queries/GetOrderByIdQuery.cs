using System;

namespace HomeWork3.Services.Orders.Contracts.Queries
{
    /// <summary>
    /// Запрос получения Заказа
    /// </summary>
    public class GetOrderByIdQuery
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int OrderId { get; }


        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
