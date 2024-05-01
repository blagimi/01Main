using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОграниченияОбобщений
{
    internal class Messenger<T> where T : Message
    {
        public void SendMessage(T message)
        {
            Console.WriteLine($"Сообщение {message.Text} из месенджера");
        }
    }
}
