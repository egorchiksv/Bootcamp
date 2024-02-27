using System.Net.Sockets; // Подключение библиотек для работы
using System.Text;

namespace Client // Пространство имен
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient();
        }
    }
}