using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ОграниченияОбобщений
{
    internal class Message
    {
        public string Text { get; } // Текст сообщения
        /// <summary>
        /// Метод принимает в качестве параметра объект класса Message для отправки
        /// </summary>
        /// <param name="message">объект класса Message</param>
        
        // public static void SendMessage(Message message) before
        public static void SendMessage<T>(T message) where T: Message  // after
        /* Поскольку message теперь представляет любой тип это помогает
         * избегать преобразований для классов наследников.
         * Для ограничения методов после списка параметров указывается оператор where
        */
        {
            /*
             * Однако теперь тип любой, но не любой тип имеет свойство Text
             * Более того по умолчанию доступны только методы типа object
             * Console.WriteLine($"Сообщение {message.Text} отправлено."); // before
             * поэтому вызов выдает ошибку.
             */
            Console.WriteLine($"Сообщение {message.Text} отправлено.");
        }
        public Message(string text) // Конструктор с одним параметром
        {
            Text = text;
        }
    }
}
