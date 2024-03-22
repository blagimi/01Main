using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КонструкторыИнициализаторыДеконструкторы
{
    internal class Employee
    {
        public string name;
        public Company company;
        public Employee ()
        {
            name = "Undefined";
            company = new Company();
        }

        public void Print() => Console.WriteLine($"Имя: {name} Компания: {company.title}");
    }
}
