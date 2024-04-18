using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace ВиртуальныеМетодыИСвойства
{
    internal class Person 
    {
        int age = 1;
        public string Name { get; set; }
        public virtual int Age
        {
            get => age;
            set 
            {
                if (value > 0 && value < 110) age = value; 
                else Console.WriteLine("Недопустимый возраст");
            }
        } 
        public Person (string name)
        {
            Name = name;
        }
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
        /// <summary>
        /// Метод основного класса Person с возможностью для переопределения в классах наследниках
        /// </summary>
        /// <remarks>
        /// Выводит имя человека
        /// </remarks>
        public virtual void PersonPrint()
        {
            Console.WriteLine($"{Name},{Age}");
        }
    }
}
