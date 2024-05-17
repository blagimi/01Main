using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИнтерфейсыВОбобщениях
{
    internal class Message(string text) : IMessage, IPrintable
    {
        public string Text { get; } = text;
        public void Print() => Console.WriteLine(Text);
    }
}
