namespace HomeWork3.Services.Orders.Contracts.Events
{
    internal class OrderCompletedEvent : OrderEvent
    {
        public OrderCompletedEvent(int orderId)
            : base(orderId)
        {
        }
    }
}
