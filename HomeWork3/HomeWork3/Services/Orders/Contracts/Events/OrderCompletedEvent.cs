namespace HomeWork3.Services.Orders.Contracts.Events
{
    /// <summary>
    /// Событие завершения заказа
    /// </summary>
    internal class OrderCompletedEvent : OrderEvent
    {
        public OrderCompletedEvent(int orderId)
            : base(orderId)
        {
        }
    }
}
