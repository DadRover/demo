namespace HomeWork3.Services.Orders.Contracts.Commands
{
    /// <summary>
    /// Команда создания закза
    /// </summary>
    internal class CreateOrderCommand
    {
        /// <summary>
        /// Заказчик
        /// </summary>
        public string CustomerName { get; set; }

        public CreateOrderCommand(string customerName)
        {
            CustomerName = customerName;
        }
    }
}
