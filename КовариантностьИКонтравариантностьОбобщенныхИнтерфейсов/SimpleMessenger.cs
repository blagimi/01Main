using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов
{
    internal class SimpleMessenger : IMessenger2<Message>
    {
        public void SendMessage (Message message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }
}
