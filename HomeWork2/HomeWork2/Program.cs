using HomeWork2.Services;

namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args) => 
            CoreService.GetInstance.Run();
    }
}
