namespace HomeWork3.Services.Basket.Contracts.Commands
{
    internal class SendOrderCommand
    {
        public int OrderId { get; set; }

        public SendOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
