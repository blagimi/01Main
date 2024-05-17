using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах
{
    internal abstract class Person : IMovable
    {
        public abstract void Move();
    }
}
