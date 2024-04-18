using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВиртуальныеМетодыИСвойства
{
    internal class Employee : Person
    {
        public string Company { get; set; }
        public override int Age 
        {
            get => base.Age; 
            set { if (value > 17 && value < 110) base.Age = value; else Console.WriteLine("Недопустимый возраст"); } 
        }
        public Employee(string name, int age, string company) : base(name,age)
        {
            Company = company;
            Console.WriteLine("Возраст должен превышать 17 лет");
            base.Age = 18;
        }
        /// <summary>
        /// Переопределенный метод в классе наследнике из основного класса Person
        /// </summary>
        /// <remarks>Выводит имя человека и название компании в которой он работает</remarks>
        public override sealed void PersonPrint()
        {
            Console.WriteLine($"{Name}, {Age} работает в {Company}");
        }
    }
}
