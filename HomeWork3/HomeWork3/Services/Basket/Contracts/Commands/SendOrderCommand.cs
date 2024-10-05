namespace HomeWork3.Services.Basket.Contracts.Commands
{
    /// <summary>
    /// Команда Отправки корзины
    /// </summary>
    internal class SendOrderCommand
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }

        public SendOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
