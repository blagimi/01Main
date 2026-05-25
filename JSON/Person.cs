using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    internal class Person
    {
        byte age = 0;
        public string Name { get; }
        public byte Age
        {
            set
            {
                if (value < 0 || value > 120)
                    Console.WriteLine("Ошибка обработки возраста. \nВозраст должен быть в диапазоне от 0 до 120");
                else
                    age = value;
            }
            get { return age; }
        }
        public Person (string name, byte age)
        {
            Name = name;
            Age = age;
        }
    }
}
