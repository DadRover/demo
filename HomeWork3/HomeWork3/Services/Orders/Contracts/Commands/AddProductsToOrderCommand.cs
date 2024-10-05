using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Contracts.Commands
{
    /// <summary>
    /// Команда добавления продуктак в заказ
    /// </summary>
    internal class AddProductsToOrderCommand
    {
        /// <summary>
        /// Идентификтор заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public List<(string ProductName, int Quantity, decimal Price)> Products { get; set; } = new();
    }
}
