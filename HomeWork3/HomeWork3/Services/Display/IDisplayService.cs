using HomeWork3.Services.Orders.Contracts;

namespace HomeWork3.Services.Display
{
    internal interface IDisplayService
    {
        void WriteWelcome();

        void WriteMenu();
        void WriteMenuBasket();

        void OrderNotFoundMessage();

        void GetOrderMessage();

        void OrderPrint(OrderDto order);
    }
}