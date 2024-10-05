using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Contracts
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public List<(string ProductName, int Quantity, decimal Price)> Products { get; set; } = new List<(string, int, decimal)>();
        public bool IsCompleted { get; set; }
    }
}