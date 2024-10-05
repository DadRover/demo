namespace HomeWork3.Services.Orders.Contracts.Events
{
    /// <summary>
    /// Событие создания Заказа
    /// </summary>
    internal class OrderCreatedEvent : OrderEvent
    {
        /// <summary>
        /// Заказчик
        /// </summary>
        public string CustomerName { get; }

        public OrderCreatedEvent(int orderId, string customerName)
            : base(orderId)
        {
            CustomerName = customerName;
        }
    }
}
