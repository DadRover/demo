using HomeWork3.Services.Orders.Contracts.Commands;

namespace HomeWork3.Services.Orders.Handlers.Commands
{
    /// <summary>
    /// Обработчик команда Заказов
    /// </summary>
    internal interface IOrdersCommandHandler
    {
        /// <summary>
        /// Создать Заказ
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        int Handel(CreateOrderCommand command);

        /// <summary>
        /// Добавить продукт в Заказ
        /// </summary>
        /// <param name="command"></param>
        void Handel(AddProductsToOrderCommand command);

        /// <summary>
        /// ЗАвершить Заказ
        /// </summary>
        /// <param name="command"></param>
        void Handel(CompleteOrderCommand command);
    }
}