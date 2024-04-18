using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СкрытиеМетодовИСвойств
{
    internal class Employee : Person
    {
        public new string Name
        {
            get => $"Mr./Ms. {base.Name}";
            set => base.Name = value;
        }
        public string Company { get; set; }
        public new readonly static int minAge = 18;
        public new const string TYPENAME = "Employee";
        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
        /// <summary>
        /// Скрытие метода Print из базового класса и переопределение его в Employee
        /// </summary>
        public new void Print()
        {
            Console.WriteLine($"Name: {Name} Company: {Company}");
        }
    }
}
