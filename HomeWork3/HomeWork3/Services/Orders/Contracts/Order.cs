using System.Collections.Generic;
using HomeWork3.Services.Orders.Contracts.Events;

namespace HomeWork3.Services.Orders.Contracts
{
    internal class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public List<(string ProductName, int Quantity, decimal Price)>
            Products { get; set; } = new List<(string, int, decimal)>();
        public bool IsCompleted { get; set; }

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