using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПреобразованиеОбъектовКлассов
{
    internal class Client (string name, string bank) : Person(name)
    {
        public string Bank { get; set; } = bank;
    }
}
