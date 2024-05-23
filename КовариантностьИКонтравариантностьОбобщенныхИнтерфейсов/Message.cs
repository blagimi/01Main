using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов
{
    internal class Message(string text)
    {
        public string Text { get; set; } = text;
    }
}
