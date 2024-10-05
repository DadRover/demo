using HomeWork3.Services.Basket.Contracts.Commands;

namespace HomeWork3.Services.Basket.Handlers.Commands
{
    /// <summary>
    /// Обработчик команд корзины
    /// </summary>
    internal interface IBasketCommandsHandler
    {
        /// <summary>
        /// Добваить продукт
        /// </summary>
        /// <param name="command"></param>
        void Handel(AddProductCommand command);

        /// <summary>
        /// Удалить продукт
        /// </summary>
        /// <param name="command"></param>
        void Handel(RemoveProductCommand command);

        /// <summary>
        /// Отправить продукт
        /// </summary>
        /// <param name="command"></param>
        void Handel(SendOrderCommand command);
    }
}