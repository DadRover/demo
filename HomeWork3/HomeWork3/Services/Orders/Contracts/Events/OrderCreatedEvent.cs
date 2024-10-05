using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3.Services.Orders.Contracts.Events
{
    internal class OrderCreatedEvent : OrderEvent
    {
        public string CustomerName { get; }

        public OrderCreatedEvent(int orderId, string customerName)
            : base(orderId)
        {
            CustomerName = customerName;
        }
    }
}
