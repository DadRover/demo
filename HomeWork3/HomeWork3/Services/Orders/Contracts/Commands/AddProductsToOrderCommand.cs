using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Contracts.Commands
{
    internal class AddProductsToOrderCommand
    {
        public int OrderId { get; set; }
        public List<(string ProductName, int Quantity, decimal Price)> Products { get; set; } = new();
    }
}
