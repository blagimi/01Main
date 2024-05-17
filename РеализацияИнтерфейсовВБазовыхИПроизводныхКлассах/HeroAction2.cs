using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal class HeroAction2 : BaseAction2
    {
        public override void Move()
        {
            Console.WriteLine("Move in HeroAction2");
        }
    }
}
