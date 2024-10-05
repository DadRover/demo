namespace HomeWork3.Services.Basket.Contracts
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string productName, decimal price, int quantity = 1)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}