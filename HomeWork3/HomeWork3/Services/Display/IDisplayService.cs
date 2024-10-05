using HomeWork3.Services.Orders.Contracts;

namespace HomeWork3.Services.Display
{
    /// <summary>
    /// Серыис отображения 
    /// </summary>
    internal interface IDisplayService
    {
        /// <summary>
        /// Приветствие
        /// </summary>
        void WriteWelcome();

        /// <summary>
        /// Осноное меню
        /// </summary>
        void WriteMenu();

        /// <summary>
        /// Меню Корзины
        /// </summary>
        void WriteMenuBasket();

        /// <summary>
        /// Сообщение заказ не найден
        /// </summary>
        void OrderNotFoundMessage();

        /// <summary>
        /// Сообщение получения Заказа
        /// </summary>
        void GetOrderMessage();

        /// <summary>
        /// Печать заказа
        /// </summary>
        /// <param name="order"></param>
        void OrderPrint(OrderDto order);
    }
}