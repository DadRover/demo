using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Basket.Contracts.Commands;
using HomeWork3.Services.Basket.Contracts.Queries;
using HomeWork3.Services.Basket.Services;
using HomeWork3.Services.Display;
using HomeWork3.Services.Orders.Contracts;
using HomeWork3.Services.Orders.Contracts.Commands;
using HomeWork3.Services.Orders.Contracts.Queries;
using HomeWork3.Services.Orders.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HomeWork3.Infrastructure
{
    internal class Runner
    {
        private static IBasketService _basketService;
        private static IOrderService _orderService;
        private static IServiceProvider _serviceProvider;
        private static DisplayService _displayService;
        public Runner(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _basketService = _serviceProvider.GetService<IBasketService>();
            _orderService = _serviceProvider.GetService<IOrderService>();
            _displayService = new DisplayService();
        }

        public void Run()
        {
            //Console.TreatControlCAsInput = true;
            _displayService.WriteWelcome();
            MainMenuWaiting();
        }

        private static void MainMenuWaiting(bool showMenu = true)
        {
            ConsoleKeyInfo cki;
            if (showMenu)
            {
                _displayService.WriteSeparator();
                _displayService.WriteMenu();
            }
            cki = Console.ReadKey();
            UserMainMenuChoice(cki.Key);
        }

        private static void BasketMenuWaiting()
        {
            ConsoleKeyInfo cki;

            _displayService.WriteSeparator();
            _displayService.WriteMenuBasket();
            cki = Console.ReadKey();
            UserBasketMenuChoice(cki.Key);

            MainMenuWaiting();
        }

        private static void BasketRemoveMenuWaiting()
        {
            ConsoleKeyInfo cki;

            _displayService.WriteSeparator();
            _displayService.WriteRemoveMenuBasket();
            cki = Console.ReadKey();
            UserBasketRemoveMenuChoice(cki.Key);
        }

        private static void UserMainMenuChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    ShowBasket();
                    break;
                case ConsoleKey.F2:
                    CostBasket();
                    break;
                case ConsoleKey.F3:
                    SendBasket();
                    break;
                case ConsoleKey.F5:
                    CheckOrder();
                    break;
                case ConsoleKey.F6:
                    ShowOrders();
                    break;
                case ConsoleKey.Escape:
                    break;
                default: MainMenuWaiting(false);
                    break;
            }
        }

        private static void UserBasketMenuChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    AddToBasket("Салат");
                    break;
                case ConsoleKey.F2:
                    AddToBasket("Суп");
                    break;
                case ConsoleKey.F3:
                    AddToBasket("Катлета");
                    break;
                case ConsoleKey.F4:
                    AddToBasket("Компот");
                    break;
                case ConsoleKey.F5:
                    BasketRemoveMenuWaiting();
                    break;
                case ConsoleKey.F6:
                    SendBasket();
                    break;
            }
        }
        private static void UserBasketRemoveMenuChoice(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F1:
                    RemoveFromBasket("Салат");
                    break;
                case ConsoleKey.F2:
                    RemoveFromBasket("Суп");
                    break;
                case ConsoleKey.F3:
                    RemoveFromBasket("Катлета");
                    break;
                case ConsoleKey.F4:
                    RemoveFromBasket("Компот");
                    break;
            }
        }

        private static void RemoveFromBasket(string productName)
        {
            _basketService.Remove(new RemoveProductCommand(productName));
            _displayService.WriteSeparator();
            Console.WriteLine($"Позиция \"{productName}\" - если была то убрали порцию...");

            MainMenuWaiting();
        }

        private static void AddToBasket(string productName)
        {
            _basketService.Add(new AddProductCommand(productName));
            _displayService.WriteSeparator();
            _displayService.AddProductMessage(productName);
            BasketMenuWaiting();
        }

        private static void ShowBasket()
        {
            Product[] products = _basketService.GetBasket(new GetBasketQuery());
            _displayService.WriteSeparator();
            Console.WriteLine("Ваша корзина:");
            if (products != null && products.LongCount() > 0)
            {
                foreach (var product in products)
                {
                    _displayService.WriteProductRow(product.ProductName, product.Price, product.Quantity);
                }
            }
            else
            {
                Console.WriteLine("--- пусто ---");
            }
            BasketMenuWaiting();
        }

        private static void CostBasket()
        {
            decimal cost = _basketService.GetCostBasket(new GetCostBasketQuery());
            _displayService.WriteSeparator();
            Console.WriteLine($"В вашей корзине товара на сумму:{cost}р.");
            MainMenuWaiting();
        }

        private static void SendBasket()
        {
            _displayService.WriteSeparator();
            Console.WriteLine("Ведите Имя на кого будет оформлен заказ:");
            string customerName = Console.ReadLine();
            var orderId = _orderService.CreateOrder(new CreateOrderCommand(customerName));
            _basketService.SendOrder(new SendOrderCommand(orderId));
            Console.WriteLine($"Заказ отправлен, номер заказа #{orderId}:");
            MainMenuWaiting();
        }

        private static void CheckOrder()
        {
            _displayService.WriteSeparator();
            _displayService.GetOrderMessage();
            var code = Console.ReadLine();
            var id = int.Parse(code); // Предположим что пользователь не будет включать дурака

            var order = _orderService.GetOrder(new GetOrderByIdQuery(id));
            if (order == null)
            {
                _displayService.OrderNotFoundMessage();
            }
            else
            {
                _displayService.OrderStatusPrint(order);
            }
            MainMenuWaiting();
        }

        private static void ShowOrders()
        {
            _displayService.WriteSeparator();
            var orderService = _serviceProvider.GetService<IOrderService>();
            OrderDto[] orders = orderService.GetOrders(new GetOrdersQuery());

            if (orders.LongCount() > 0)
            {
                foreach (OrderDto order in orders)
                {
                    _displayService.OrderDataPrint(order);
                }
            }
            else
            {
                Console.WriteLine("--- Заказов нет. ---");
            }
            MainMenuWaiting();
        }
    }
}
