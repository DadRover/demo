using System.Collections.Generic;

namespace HomeWork3.Services.Orders.Contracts
{
    /// <summary>
    /// Модель Заказа
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заказчик
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public List<(string ProductName, int Quantity, decimal Price)> Products { get; set; } = new List<(string, int, decimal)>();

        /// <summary>
        /// Признак завершения
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}