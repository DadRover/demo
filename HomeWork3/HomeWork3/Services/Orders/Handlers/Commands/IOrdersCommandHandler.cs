using HomeWork3.Services.Orders.Contracts.Commands;

namespace HomeWork3.Services.Orders.Handlers.Commands
{
    internal interface IOrdersCommandHandler
    {
        int Handel(CreateOrderCommand command);

        void Handel(AddProductsToOrderCommand command);

        void Handel(CompleteOrderCommand command);
    }
}