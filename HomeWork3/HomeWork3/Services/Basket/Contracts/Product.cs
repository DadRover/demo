namespace HomeWork3.Services.Basket.Contracts
{
    /// <summary>
    /// Модель продукта
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        public Product(string productName, decimal price, int quantity = 1)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}