using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal class HeroAction3 : BaseAction2
    {
        public new void Move() => Console.WriteLine("Move in HeroAction3");
    }
}
