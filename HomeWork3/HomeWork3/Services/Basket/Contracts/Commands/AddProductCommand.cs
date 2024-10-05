namespace HomeWork3.Services.Basket.Contracts.Commands
{
    /// <summary>
    /// Команда добавление продукта
    /// </summary>
    internal class AddProductCommand
    {
        /// <summary>
        /// Наименвание
        /// </summary>
        public string ProductName { get; set; }

        public AddProductCommand(string productName)
        {
            ProductName = productName;
        }
    }
}
