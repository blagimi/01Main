using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КонструкторыИнициализаторыДеконструкторы
{
    internal class DePerson (string name, int age)
    {
        readonly string name = name;
        readonly int age = age;
        public void DecPerson(out string personName, out int personAge)
        {
            personName = name;
            personAge = age;
        }
    }
}
