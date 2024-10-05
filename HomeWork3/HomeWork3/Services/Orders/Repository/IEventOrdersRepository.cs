using HomeWork3.Services.Orders.Contracts.Events;
using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Repository
{
    /// <summary>
    /// Репозиторий событий
    /// </summary>
    internal interface IEventOrdersRepository
    {
        /// <summary>
        /// Сохранить событие
        /// </summary>
        /// <param name="orderEvent"></param>
        void SaveEvent(OrderEvent orderEvent);

        /// <summary>
        /// Получить события
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        IEnumerable<OrderEvent> GetEvents(int orderId);

        /// <summary>
        /// Получсить следующий идентификатор
        /// </summary>
        /// <returns></returns>
        int GetNextId();

        /// <summary>
        /// Полуить все идентификаторы заказов
        /// </summary>
        /// <returns></returns>
        int[] GetAllOrderIds();
    }
}
