using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РазличияПереопределенияИСкрытия
{
    internal class Person
    {
        public string Name { get; set; }
        public Person (string name)
        {
            Name = name;
        }
        public virtual void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
