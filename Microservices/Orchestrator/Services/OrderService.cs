using Orchestrator.Contracts;

namespace Notifications.Services
{
    /// <summary>
    /// Сервис мониторинга
    /// </summary>
    public class OrderService
    {
        static HttpClient client = new HttpClient();

        private static OrderService instance;
        private static readonly object lockObj = new object();

        public OrderService(string address)
        {
            client.BaseAddress = new Uri(address);

        }
        public static OrderService GetInstance(string address)
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new OrderService(address);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Отправить обновленную очередь
        /// </summary>
        /// <param name="productQueue"></param>
        public async void SendNewQueue(ProductQueue productQueue)
        {
            await client.PostAsJsonAsync("api/set-queue", productQueue);
        }
    }
}
