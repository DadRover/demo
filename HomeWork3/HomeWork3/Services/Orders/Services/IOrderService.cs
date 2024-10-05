using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Queries;

namespace HomeWork3.Services.Orders.Services
{
    internal interface IOrderService
    {
        int CreateOrder(CreateOrderCommand command);

        void AddProductOrder(AddProductsToOrderCommand command);

        void CompleteOrder(CompleteOrderCommand command);

        OrderDto GetOrder(GetOrderByIdQuery command);

        OrderDto[] GetOrders(GetOrdersQuery command);
    }
}