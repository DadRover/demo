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

            _notificationService = NotificationService.GetInstance("http://localhost:8081/"); // ����������� �� ���� ���� ����� ������ �����������
            _orderServiceA = OrderService.GetInstance("http://localhost:8082/");// ����������� �� ���� ���� ����� ������ ����������� A
            _orderServiceB = OrderService.GetInstance("http://localhost:8083/");// ����������� �� ���� ���� ����� ������ ����������� B

            _queue = new List<ProductQueue>();

        }

        /// <summary>
        /// ����� ���������� ������ ������������ � ������� �� ��������� ��������
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
        /// ����� ���������� ������� �� ������� ����������
        /// </summary>
        /// <param name="userOrder"></param>
        [HttpGet(Name = "user-is-order")]
        public void UserIsOrder(UserOrder userOrder)
        {
            var productQueue = _queue.Single(q => q.Product == userOrder.Product);

            if (productQueue == null)
            {
                _logger.LogInformation($"{DateTime.Now}: � ������� ��� �������� {userOrder.Product}.");
            }
            else
            {
                var user = productQueue.UserIds.Single(u => u == userOrder.UserId);

                productQueue.UserIds.Remove(userOrder.UserId);
                productQueue.UserIds.Add(userOrder.UserId);

                _logger.LogInformation($"{DateTime.Now}: ������������ {userOrder.UserId} ��������� � ����� ������� �� ������� {userOrder.Product}.");

                _orderServiceA.SendNewQueue(productQueue);
                _orderServiceB.SendNewQueue(productQueue);
                _notificationService.SendMessage(productQueue);
            }
        }
    }
}
