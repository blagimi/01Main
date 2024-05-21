using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КопированиеОбъектовИнтерфейсICloneable
{
    internal class Person3: ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public Person3 (string name, int age, Company company)
        {
            Name = name;
            Age = age;
            Work = company;
        }
        public object Clone() => MemberwiseClone();
    }
}
