namespace Notifications.Services
{
    public class OrchestratorService
    {
        static HttpClient client = new HttpClient();

        private static OrchestratorService instance;
        private static readonly object lockObj = new object();

        public OrchestratorService(string address)
        {
            client.BaseAddress = new Uri(address);

        }
        public static OrchestratorService GetInstance(string address)
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new OrchestratorService(address);
                    }
                }
            }
            return instance;
        }

        public async void UserIsOrder(int userId)
        {
            await client.PostAsJsonAsync("api/user-is-order", userId);
        }
    }
}
