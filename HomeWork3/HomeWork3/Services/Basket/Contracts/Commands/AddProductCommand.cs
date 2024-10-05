namespace HomeWork3.Services.Basket.Contracts.Commands
{
    internal class AddProductCommand
    {
        public string ProductName { get; set; }

        public AddProductCommand(string productName)
        {
            ProductName = productName;
        }
    }
}
