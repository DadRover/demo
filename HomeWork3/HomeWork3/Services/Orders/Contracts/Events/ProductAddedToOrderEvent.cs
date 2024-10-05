namespace HomeWork3.Services.Orders.Contracts.Events
{
    internal class ProductAddedToOrderEvent : OrderEvent
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public ProductAddedToOrderEvent(int orderId, string productName, int quantity, decimal price)
            : base(orderId)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
