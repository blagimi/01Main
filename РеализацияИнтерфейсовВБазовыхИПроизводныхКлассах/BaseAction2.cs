using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal class BaseAction2 : IAction
    {
        public virtual void Move() => Console.WriteLine("Move in BaseAction2");
    }
}
