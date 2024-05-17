using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal class HeroAction5 : BaseAction3,IAction
    {
        public new void Move() => Console.WriteLine("Move in HeroAction5");
        // Явная реализация интерфейса
        void IAction.Move() => Console.WriteLine("Move in IAction");
    }
}
