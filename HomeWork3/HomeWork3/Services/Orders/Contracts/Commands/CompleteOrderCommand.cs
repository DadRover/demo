namespace HomeWork3.Services.Orders.Contracts.Commands;

internal class CompleteOrderCommand
{
    public int OrderId { get; }

    public CompleteOrderCommand(int orderId)
    {
        OrderId = orderId;
    }
}