using Microsoft.AspNetCore.Mvc;

namespace Notifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(ILogger<NotificationsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ����� �����������
        /// </summary>
        /// <param name="message"></param>
        [HttpPost(Name = "send-message")]
        public void SendMessage(Message message)
        {
            _logger.LogInformation($"{DateTime.Now}: ���������� ������������ {message.UserId} � ������ �������� {message.ProductName}.");
        }
    }
}
