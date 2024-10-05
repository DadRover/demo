using HomeWork3.Services.Orders.Contracts.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HomeWork3.Services.Orders.Repository
{
    internal class EventOrdersRepository : IEventOrdersRepository
    {
        private readonly List<OrderEvent> _events = new();

        ///<inheritdoc/>
        public void SaveEvent(OrderEvent orderEvent)
        {
            _events.Add(orderEvent);
        }
        ///<inheritdoc/>
        public IEnumerable<OrderEvent> GetEvents(int orderId) =>
            _events.Where(e => e.OrderId == orderId);

        ///<inheritdoc/>
        public int[] GetAllOrderIds() =>
            _events.OfType<OrderCreatedEvent>().Select(e => e.OrderId).ToArray();

        ///<inheritdoc/>
        public int GetNextId() =>
            _events.Capacity > 0 ? _events.Max(e => e.OrderId) + 1 : 1;
    }
}
