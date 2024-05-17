using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal class Driver : Person
    {
        public override void Move()
        {
            Console.WriteLine("Шофер ведет машину");
        }
    }
}
