using System;

namespace HomeWork3.Services.Orders.Contracts.Queries
{
    public class GetOrderByIdQuery
    {
        public int OrderId { get; }

        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
