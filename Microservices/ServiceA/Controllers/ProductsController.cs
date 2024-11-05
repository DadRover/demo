using Microsoft.AspNetCore.Mvc;
using Notifications.Services;
using ServiceOrder.Contracts;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private List<ProductQueue> _queue;
        private readonly ILogger<ProductsController> _logger;
        private readonly OrchestratorService _orchestratorService;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _queue = new List<ProductQueue>();
            _orchestratorService = OrchestratorService.GetInstance("http://localhost:8082/");
        }

        [HttpPost(Name = "set-queue")]
        public void SetQueue(ProductQueue request)
        {
            var productQueue = _queue.Single(q => q.Product == request.Product);

            if (productQueue == null)
            {
                _queue.Add(new ProductQueue
                {
                    Product = request.Product,
                    UserIds = request.UserIds
                });
            }
            else
            {
                productQueue.UserIds = request.UserIds;
            }
        }

        [HttpPost(Name = "set-product")]
        public void SetQueue(string product)
        {
            var productQueue = _queue.Single(q => q.Product == product);

            if (productQueue == null)
            {
                _logger.LogInformation($"{DateTime.Now}: На продукт {product} нет желающих.");
            }
            else
            {
                int userId = productQueue.UserIds.First();
                _orchestratorService.UserIsOrder(userId);
            }
        }
    }
}
