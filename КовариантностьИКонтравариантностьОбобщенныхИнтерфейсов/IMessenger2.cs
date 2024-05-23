using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов
{
    internal interface IMessenger2<in T>
    {
        void SendMessage(T message);
    }
}
