using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИнтерфейсыВОбобщениях
{
    internal class Messenger<T> where T : IMessage, IPrintable
    {
        public void Send (T message)
        {
            Console.WriteLine("Отправка сообщения: ");
            message.Print();
        }
    }
}
