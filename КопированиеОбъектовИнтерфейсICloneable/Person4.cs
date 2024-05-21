using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КопированиеОбъектовИнтерфейсICloneable
{
    internal class Person4(string name, int age, Company company) : ICloneable
    {
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
        public Company Work { get; set; } = company;
        public object Clone()
        {
            return new Person4(Name, Age, new Company (Work.Name));
        }
    }
}
