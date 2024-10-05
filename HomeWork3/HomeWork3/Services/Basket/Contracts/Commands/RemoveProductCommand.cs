namespace HomeWork3.Services.Basket.Contracts.Commands
{
    internal class RemoveProductCommand
    {
        public string ProductName { get; set; }

        public RemoveProductCommand(string productName)
        {
            ProductName = productName;
        }
    }
}
