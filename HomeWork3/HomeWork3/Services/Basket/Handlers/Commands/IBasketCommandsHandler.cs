using HomeWork3.Services.Basket.Contracts.Commands;

namespace HomeWork3.Services.Basket.Handlers.Commands
{
    internal interface IBasketCommandsHandler
    {
        void Handel(AddProductCommand command);

        void Handel(RemoveProductCommand command);

        void Handel(SendOrderCommand command);
    }
}