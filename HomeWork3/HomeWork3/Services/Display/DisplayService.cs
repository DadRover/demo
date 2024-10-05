using System;
using System.Linq;
using HomeWork3.Services.Basket.Contracts;
using HomeWork3.Services.Orders.Contracts;

namespace HomeWork3.Services.Display
{
    internal class DisplayService: IDisplayService
    {
        public DisplayService() { }

        ///<inheritdoc/>
        public void WriteWelcome() =>
            Console.WriteLine("Сервис управления задачами запущен!");

        public void WriteMenu()
        {
            Console.WriteLine("Меню:");

            Console.WriteLine("F1 - Поосмотреть корзину;");
            Console.WriteLine("F2 - Стоимость корзины;");
            Console.WriteLine("F3 - Отправить заказ;");

            Console.WriteLine("F5 - Проверить заказ;");
            Console.WriteLine("F6 - Список заказов;");

            Console.WriteLine("Esc - Выход;");
        }

        public void WriteMenuBasket()
        {
            Console.WriteLine("\n\rМеню корзины:");

            Console.WriteLine("F1 - Добавить салат;");
            Console.WriteLine("F2 - Добавить суп;");
            Console.WriteLine("F3 - Добавить катлету;");
            Console.WriteLine("F4 - Добавить компот;");

            Console.WriteLine("F5 - Удалить;");
            Console.WriteLine("F6 - Отправить в заказ;");

            Console.WriteLine("Esc - Выход;");
        }

        public void GetOrderMessage()
        {
            Console.WriteLine("Введите идентификатор заказа :");
        }

        public void OrderPrint(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public void OrderNotFoundMessage()
        {
            Console.WriteLine("Заказ не найден.");
        }

        public void OrderStatusPrint(OrderDto order)
        {
            string pref = !order.IsCompleted ? " еще не":"";
            Console.WriteLine($"Заказ {order.Id}" + pref + " выполнен.");
        }

        public void AddProductMessage(string productName)
        {
            Console.WriteLine($"В корзину добавлен \"{productName}\".");
        }

        public void OrderDataPrint(OrderDto order)
        {
            Console.WriteLine("\n\r***************************");
            string prefStatus = order.IsCompleted ? "В" : "Не в";
            Console.WriteLine($"Заказ на имя {order.CustomerName} в статусе {prefStatus}ыполнен.");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Заказ на {order.Products.Count} позиций:");
            Console.WriteLine("------------------------");
            foreach (var product in order.Products)
            {
                WriteProductRow(product.ProductName, product.Price, product.Quantity);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine($"На общую сумму: {order.Products.Sum(p => p.Price * p.Quantity)}Р.");

            Console.WriteLine("Оплачено");

            Console.WriteLine("***************************");
        }

        public void WriteSeparator()
        {
            Console.WriteLine("\n\r***************************");
        }

        public void WriteRemoveMenuBasket()
        {
            Console.WriteLine("\n\rМеню удаления из корзины:");

            Console.WriteLine("F1 - Удалить салат;");
            Console.WriteLine("F2 - Удалить суп;");
            Console.WriteLine("F3 - Удалить катлету;");
            Console.WriteLine("F4 - Удалить компот;");

            Console.WriteLine("Esc - Выход;");
        }

        public void WriteProductRow(string productName, decimal price, int quantity)
        {
            Console.WriteLine($"- {productName} x{quantity}, по {price}р./порция;");
        }
    }
}
