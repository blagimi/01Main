using System;
using System.Collections.Generic;
using System.Text;

namespace XML
{
    internal class Person
    {
        public string Name { get;}
        public int Age { get; set; }
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
    }
}
