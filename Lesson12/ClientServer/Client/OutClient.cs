using System.Net.Sockets; // Подключение библиотек для работы
using System.Text;        // с TCP

namespace Client
{
    class OurClient
    {
        private TcpClient client; // Переменная класс, которая позволяет работать с TCP. Позволяет отправлять данные по TCP от клента на сервер. Создаем клиент, который будет обращаться по IP и указанному порту
        private StreamWriter sWriter; // Класс поток, при помощи которого будем с клиента на сервер
         private StreamReader sReader; 
        public OurClient()
        {
            client = new TcpClient("127.0.0.1", 5555);
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            HandleCommunicatoin(); // Держить открытый мост соединения
        }

        void HandleCommunicatoin() // Фунция удержания соединения
        {
            while(true)
            {
                Console.Write("> ");
                string message = Console.ReadLine(); // Подготовка сообщения
                sWriter.WriteLine(message); // Подготовка сообщения
                sWriter.Flush(); // Срочная отправка сообщения

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Сервер ответил => {answerServer}");
            }
        }
    }
}