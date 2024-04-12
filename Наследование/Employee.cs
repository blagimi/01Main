using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Наследование
{
    internal class Employee(string name, string company) : Person(name)
    {
        public string Company { get; set; } = company;
    }

}
