using Orchestrator.Contracts;

namespace Notifications.Services
{

    public class NotificationService
    {
        static HttpClient client = new HttpClient();

        private static NotificationService instance;
        private static readonly object lockObj = new object();

        private NotificationService(string address)
        {
            client.BaseAddress = new Uri(address);
        }

        public static NotificationService GetInstance(string address)
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new NotificationService(address);
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Отпарвить уведомление
        /// </summary>
        /// <param name="productQueue"></param>
        public async void SendMessage(ProductQueue productQueue)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/send-message", productQueue);
        }
    }
}
