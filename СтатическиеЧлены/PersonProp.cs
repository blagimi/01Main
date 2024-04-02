using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СтатическиеЧлены
{
    internal class PersonProp(int age)
    {
        readonly int age = age;
        static int retirementAge = 65;
        public static int RetirementAge
        {
            get { return retirementAge; }
            set { if (value > 1 && value < 100) retirementAge = value; }
        }
        public void CheckAge()
        {
            if (age>= retirementAge)
                Console.WriteLine("Уже на пенсии");
            else
                Console.WriteLine($"До пенсии осталось {retirementAge - age} года/лет");
        }
    }
}
