using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОграниченияОбобщений
{
    internal class Person(string name)
    {
        public string Name { get; set; } = name;
    }
}
