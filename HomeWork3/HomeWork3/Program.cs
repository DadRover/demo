using HomeWork3.Infrastructure;

namespace HomeWork3
{
    internal class Program
    {
        private static void Main(string[] args) =>
            Startup.GetInstance.Start();

    }
}