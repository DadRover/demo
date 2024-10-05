using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Contracts.Commands
{
    internal class CreateOrderCommand
    {
        public string CustomerName { get; set; }

        public CreateOrderCommand(string customerName)
        {
            CustomerName = customerName;
        }
    }
}
