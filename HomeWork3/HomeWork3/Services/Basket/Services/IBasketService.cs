using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Basket.Contracts.Queries;

namespace HomeWork3.Services.Basket.Services
{
    /// <summary>
    /// Сервис Корзины
    /// </summary>
    internal interface IBasketService
    {
        /// <summary>
        /// Добавить продукт в Корзину
        /// </summary>
        /// <param name="command"></param>
        void Add(AddProductCommand command);

        /// <summary>
        /// Удплить продукт из Корзины
        /// </summary>
        /// <param name="command"></param>
        void Remove(RemoveProductCommand command);

        /// <summary>
        /// Отправить продукты из Коарзины в Заказ
        /// </summary>
        /// <param name="command"></param>
        void SendOrder(SendOrderCommand command);

        /// <summary>
        /// Получтьи содержимое Корзины
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Product[] GetBasket(GetBasketQuery command);

        /// <summary>
        /// Получить стоимость корзины
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        decimal GetCostBasket(GetCostBasketQuery command);
    }
}