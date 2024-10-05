namespace HomeWork3.Services.Orders.Contracts.Commands
{
    /// <summary>
    /// Команда завершения Заказа
    /// </summary>
    internal class CompleteOrderCommand
    {
        /// <summary>
        /// Идентификатор Заказа
        /// </summary>
        public int OrderId { get; }

        public CompleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}