using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов
{
    internal class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }
}
