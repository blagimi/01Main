using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СортировкаОбъектовИнтерфейсIComparable
{
    internal class Person2 : IComparable<Person2>
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person2(string name, int age)
        {
            Name = name; Age = age;
        }
        public int CompareTo(Person2? person2)
        {
            if (person2 is null) throw new ArgumentException("Некорректное значение параметра");
            return Age - person2.Age;
        }
    }
}
