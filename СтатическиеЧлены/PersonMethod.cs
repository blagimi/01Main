using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СтатическиеЧлены
{
    internal class PersonMethod (int age)
    {
        public int Age { get; set; } = age;
        static readonly int retirementAge = 65;
        public static void CheckRetirementStatus (PersonMethod person)
        {
            if (person.Age >= retirementAge)
                Console.WriteLine("Уже на пенсии");
            else
                Console.WriteLine($"До пенсии осталось {retirementAge - person.Age} года/лет");
        }
    }
}
