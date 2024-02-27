using System.Net.Sockets; // Подключение библиотек для работы
using System.Net;
using System.Text;        // с TCP

namespace Server
{
    class OurServer
    {
        TcpListener server; // Слушает клиентов, как только они подключаются

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555); // Parse делает из строки IP адрес (тип данных). Тоже самое, что int.Parse("123") = 123
            server.Start();

            LoopClients();
        }

        void LoopClients()
        {
            while(true) // Для бесконечного ожидания клиента. Бесконечное ожидание нового подключения. 
            {
                TcpClient client = server.AcceptTcpClient(); // Когда подключается клиент, создается TcpClient и обрабатывается на сервере. Как только подключается новый клиент, мы его кладем в client с помощью AcceptTcpClient()
                Thread thread = new Thread(() => HandleClient(client)); // => - ананимная функция. Как только подключается новый клиент, мы его кладем в новый поток и с помощью HandleClient(client) уедрживаем его
                thread.Start(); // Запускаем поток
            }
        }
        void HandleClient(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8); // Созадем отдельный поток для каждого клиента
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);

            while(true) // Для бескоченой работы с одним клиентом
            {
                string message = sReader.ReadLine(); // Считываем строку от клиента
                Console.WriteLine($"Клиент написал - {message}");

                Console.WriteLine($"Дайте сообщение клиенту: ");
                string amswer = Console.ReadLine();
                sWriter.WriteLine(amswer);
                sWriter.Flush();
            }
        }
    }
}