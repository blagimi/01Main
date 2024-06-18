using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПаттернТипов
{
    internal class Manager : Employee
    {
        public override void Work() => Console.WriteLine("Manager works");
        public bool IsOnVacation { get; set; }
    }
}
