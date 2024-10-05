using HomeWork3.Infrastructure;

namespace HomeWork3
{
    internal class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) =>
            Startup.GetInstance.Start();

    }
}