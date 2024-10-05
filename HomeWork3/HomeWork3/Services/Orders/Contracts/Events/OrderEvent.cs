using System;

namespace HomeWork3.Services.Orders.Contracts.Events
{
    internal class OrderEvent
    {
        public int OrderId { get; }
        public DateTime OccurredOn { get; }

        protected OrderEvent(int orderId)
        {
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
