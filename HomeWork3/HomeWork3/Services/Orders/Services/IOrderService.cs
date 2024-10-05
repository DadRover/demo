using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Queries;

namespace HomeWork3.Services.Orders.Services
{
    internal interface IOrderService
    {
        /// <summary>
        /// Создать Заказ
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        int CreateOrder(CreateOrderCommand command);

        /// <summary>
        /// Добаваить продукт в заказ
        /// </summary>
        /// <param name="command"></param>
        void AddProductOrder(AddProductsToOrderCommand command);
        
        /// <summary>
        /// Завершить заказ
        /// </summary>
        /// <param name="command"></param>
        void CompleteOrder(CompleteOrderCommand command);

        /// <summary>
        /// Получить информацию по заказу
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        OrderDto GetOrder(GetOrderByIdQuery command);

        /// <summary>
        /// Получить информацию по заказам
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        OrderDto[] GetOrders(GetOrdersQuery command);
    }
}