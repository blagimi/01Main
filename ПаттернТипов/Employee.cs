using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ПаттернТипов
{
    internal class Employee
    {
        public virtual void Work() => Console.WriteLine("Employee works");
    }
}
