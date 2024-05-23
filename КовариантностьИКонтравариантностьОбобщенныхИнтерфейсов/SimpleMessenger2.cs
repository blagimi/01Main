using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов
{
    internal class SimpleMessenger2 : IMessenger3<Message,EmailMessage>
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
        public EmailMessage WriteMessage (string text)
        {
            return new EmailMessage($"Email: {text}");
        }
    }
}
