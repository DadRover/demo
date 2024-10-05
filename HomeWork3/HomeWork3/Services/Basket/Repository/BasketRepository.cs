using System.Collections.Generic;
using System.Linq;
using HomeWork3.Services.Basket.Contracts;

namespace HomeWork3.Services.Basket.Repository
{
    internal class BasketRepository : IBasketRepository
    {
        private readonly List<Product> _basket = new List<Product>();

        ///<inheritdoc/>
        public void Add(Product product)
        {
            Product productInBasket = _basket.SingleOrDefault(t => t.ProductName == product.ProductName);
            if (productInBasket != null)
            {
                productInBasket.Quantity++;
            }
            else
            {
                _basket.Add(product);
            }
        }

        ///<inheritdoc/>
        public void Remove(string productName)
        {
            Product product =  _basket.SingleOrDefault(t => t.ProductName == productName);
            
            if (product != null)
            {
                _basket.Remove(product);
            }
        }

        ///<inheritdoc/>
        public Product[] GetBasket() =>
            _basket.ToArray();

        ///<inheritdoc/>
        public decimal GetCostBasket() =>
            _basket.Sum(p => p.Price * p.Quantity);

        ///<inheritdoc/>
        public void Clear()
        {
            _basket.Clear();
        }
    }
}
