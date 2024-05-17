using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеИнтерфейсов
{
    internal interface IAction
    {
        void Move() => Console.WriteLine("I am moving");
    }
}
