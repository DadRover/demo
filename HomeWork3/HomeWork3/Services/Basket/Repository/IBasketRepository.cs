using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;

namespace HomeWork3.Services.Basket.Repository
{
    /// <summary>
    /// Репозиторий корзины
    /// </summary>
    internal interface IBasketRepository
    {
        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);

        /// <summary>
        /// Удалить продукт
        /// </summary>
        /// <param name="productName"></param>
        void Remove(string productName);

        /// <summary>
        /// Получить содержимое корзины
        /// </summary>
        /// <returns></returns>
        Product[] GetBasket();

        /// <summary>
        /// Получить стоимость корзины
        /// </summary>
        /// <returns></returns>
        decimal GetCostBasket();

        /// <summary>
        /// Очистить корзину
        /// </summary>
        void Clear();
    }
}
