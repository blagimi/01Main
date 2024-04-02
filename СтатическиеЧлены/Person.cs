using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace СтатическиеЧлены
{
    internal class Person(int age)
    {
        readonly int age = age;
        internal protected static int retirementAge = 65;
        public void CheckAge()
        {
            if (age >= retirementAge)
             Console.WriteLine("Уже на пенсии");
            else
             Console.WriteLine($"До пенсии осталось {retirementAge - age} года/лет");
        }
    }
}
