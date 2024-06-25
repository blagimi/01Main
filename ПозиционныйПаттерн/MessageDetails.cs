using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПозиционныйПаттерн
{
    internal class MessageDetails
    {
        public string Language { get; set; } = "";
        public string DateTime { get; set; } = "";
        public string Status { get; set; } = "";

        public void Deconstruct(out string lang, out string dateTime, out string status)
        {
            lang = Language;
            dateTime = DateTime;
            status = Status;
        }
    }
}
