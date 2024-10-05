using System.Collections.Generic;
using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Queries;

namespace HomeWork3.Services.Orders.Handlers.Queries
{
    internal interface IOrdersQueryHandler
    {
        OrderDto Handel(GetOrderByIdQuery command);
        OrderDto[] Handel(GetOrdersQuery command);
    }
}