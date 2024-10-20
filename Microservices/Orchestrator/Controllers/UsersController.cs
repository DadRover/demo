using Microsoft.AspNetCore.Mvc;
using Notifications.Services;
using Orchestrator.Contracts;

namespace Orchestrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private List<ProductQueue> _queue;
        private readonly NotificationService _notificationService;
        private readonly OrderService _orderServiceA;
        private readonly OrderService _orderServiceB;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _queue = new List<ProductQueue>();

            _notificationService = NotificationService.GetInstance("http://localhost:8081/"); // предположим на этом урле будет сервис нотификации
            _orderServiceA = OrderService.GetInstance("http://localhost:8082/");// предположим на этом урле будет сервис мониторинга A
            _orderServiceB = OrderService.GetInstance("http://localhost:8083/");// предположим на этом урле будет сервис мониторинга B

            _queue = new List<ProductQueue>();

        }

        /// <summary>
        /// Метод добавления нового пользователя в очередь на мониторин продукта
        /// </summary>
        /// <param name="userOrder"></param>
        [HttpGet(Name = "add-user")]
        public void AddUser(UserOrder userOrder)
        {
            var productQueue = _queue.Single(q => q.Product == userOrder.Product);

            if (productQueue == null)
            {
                _queue.Add(new ProductQueue
                {
                    Product = userOrder.Product,
                    UserIds = [userOrder.UserId]
                });
            }
            else
            {
                productQueue.UserIds.Add(userOrder.UserId);
            }
        }

        /// <summary>
        /// Метод обновления очереди от сервиса мониторига
        /// </summary>
        /// <param name="userOrder"></param>
        [HttpGet(Name = "user-is-order")]
        public void UserIsOrder(UserOrder userOrder)
        {
            var productQueue = _queue.Single(q => q.Product == userOrder.Product);

            if (productQueue == null)
            {
                _logger.LogInformation($"{DateTime.Now}: В очереди нет продукта {userOrder.Product}.");
            }
            else
            {
                var user = productQueue.UserIds.Single(u => u == userOrder.UserId);

                productQueue.UserIds.Remove(userOrder.UserId);
                productQueue.UserIds.Add(userOrder.UserId);

                _logger.LogInformation($"{DateTime.Now}: Пользователь {userOrder.UserId} отправлен в конец очереди на продукт {userOrder.Product}.");

                _orderServiceA.SendNewQueue(productQueue);
                _orderServiceB.SendNewQueue(productQueue);
                _notificationService.SendMessage(productQueue);
            }
        }
    }
}
