using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РазличияПереопределенияИСкрытия
{
    internal class HiddenPerson
    {
        public string Name { get; set; }
        public HiddenPerson (string name)
        {
            Name = name;
        }
        /// <summary>
        /// Метод базового класса
        /// </summary>
        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
