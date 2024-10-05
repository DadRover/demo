using System;

namespace HomeWork3.Services.Orders.Contracts.Events
{
    /// <summary>
    /// Базовое событие
    /// </summary>
    internal class OrderEvent
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int OrderId { get; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime OccurredOn { get; }

        protected OrderEvent(int orderId)
        {
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
