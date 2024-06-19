using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПаттернСвойств
{
    internal class Employee
    {
        public string Name { get; }
        public Company Company { get; set; }
        public Employee(string name, Company company )
        {
            Name = name;
            Company = company;
        }
    }
}
