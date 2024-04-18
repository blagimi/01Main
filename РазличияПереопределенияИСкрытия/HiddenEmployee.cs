using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РазличияПереопределенияИСкрытия
{
    internal class HiddenEmployee : HiddenPerson
    {
        public string Company { get; set; }
        public HiddenEmployee (string name, string company) :base(name)
        {
            Company = company;
        }
        /// <summary>
        /// Метод класса наследника
        /// </summary>
        public new void Print()
        {
            Console.WriteLine($"{Name} работает в {Company}");
        }
    }
}
