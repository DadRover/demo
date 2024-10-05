using HomeWork3.Services.Basket.Repository;
using HomeWork3.Services.Orders.Services;
using System.Collections.Generic;
using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Commands;

namespace HomeWork3.Services.Basket.Handlers.Commands
{

    internal class BasketCommandsHandler : IBasketCommandsHandler
    {
        private static readonly Dictionary<string, decimal> Products = new()
        {
            { "Салат", 20.2m },
            { "Суп", 30.3m },
            { "Катлета", 25.5m },
            { "Компот", 5.1m }
        };

        private readonly IOrderService _orderService;
        private readonly IBasketRepository _repository;
        public BasketCommandsHandler(IOrderService orderService, IBasketRepository repository)
        {
            _orderService = orderService;
            _repository = repository;
        }
        public void Handel(AddProductCommand command)
        {
            _repository.Add(new Product(command.ProductName, Products[command.ProductName]));
        }

        public void Handel(RemoveProductCommand command)
        {
            _repository.Remove(command.ProductName);
        }

        public void Handel(SendOrderCommand command)
        {
            
            Product[] products = _repository.GetBasket();
            AddProductsToOrderCommand addProductToOrderCommand = new(){ OrderId = command.OrderId };
            foreach (Product product in products) {
                addProductToOrderCommand.Products.Add((product.ProductName, product.Quantity, product.Price));
            }

            _orderService.AddProductOrder(addProductToOrderCommand);
            
            _orderService.CompleteOrder(new CompleteOrderCommand(command.OrderId));
            _repository.Clear();
        }
    }
}
