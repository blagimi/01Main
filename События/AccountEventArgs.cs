using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace События
{
    internal class AccountEventArgs (string message, int sum)
    {
        public string Message { get; } = message;
        public int Sum { get; } = sum;
    }
}
