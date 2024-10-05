using HomeWork3.Services.Orders.Contracts.Events;
using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Repository
{
    internal interface IEventOrdersRepository
    {
        void SaveEvent(OrderEvent orderEvent);

        IEnumerable<OrderEvent> GetEvents(int orderId);

        int GetNextId();

        int[] GetAllIds();
    }
}
