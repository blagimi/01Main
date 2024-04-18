using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СкрытиеМетодовИСвойств
{
    internal class Person
    {
        public string Name { get; set; }
        public readonly static int minAge = 1;
        public const string TYPENAME = "Person";
        public Person (string name)
        {
            Name = name;
        }
        /// <summary>
        /// Метод Print из базового класса Person
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }
}
