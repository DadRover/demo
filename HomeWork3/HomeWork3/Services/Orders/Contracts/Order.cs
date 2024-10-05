using System.Collections.Generic;
using HomeWork3.Services.Orders.Contracts.Events;

namespace HomeWork3.Services.Orders.Contracts
{
    /// <summary>
    /// Сущность Заказа
    /// </summary>
    internal class Order
    {
        /// <summary>
        /// Идентификато
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заказчик
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public List<(string ProductName, int Quantity, decimal Price)>
            Products { get; set; } = new List<(string, int, decimal)>();

        /// <summary>
        /// Признак исполнения
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Заполним поля заказа
        /// </summary>
        /// <param name="events"></param>
        public Order(IEnumerable<OrderEvent> events)
        {
            foreach (var orderEvent in events)
            {
                Apply(orderEvent);
            }
        }

        private void Apply(OrderEvent orderEvent)
        {
            switch (orderEvent)
            {
                case OrderCreatedEvent createdEvent:
                    Id = createdEvent.OrderId;
                    CustomerName = createdEvent.CustomerName;
                    break;
                case ProductAddedToOrderEvent productAddedEvent:
                    Products.Add((productAddedEvent.ProductName, productAddedEvent.Quantity,
                        productAddedEvent.Price));
                    break;
                case OrderCompletedEvent _:
                    IsCompleted = true;
                    break;
            }
        }
    }
}