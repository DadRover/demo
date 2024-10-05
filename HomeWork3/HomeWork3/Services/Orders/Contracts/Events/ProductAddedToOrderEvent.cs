namespace HomeWork3.Services.Orders.Contracts.Events
{
    /// <summary>
    /// Событие добавление товара в заказ
    /// </summary>
    internal class ProductAddedToOrderEvent : OrderEvent
    {
        /// <summary>
        /// Продукт
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Цена
        /// </summary>
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
