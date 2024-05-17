using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИнтерфейсыВОбобщениях
{
    internal interface IMessage
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        string  Text { get; }
    }
}
