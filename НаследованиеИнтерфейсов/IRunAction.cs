using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеИнтерфейсов
{
    internal interface IRunAction : IAction
    {
        new void Move() => Console.WriteLine("I am running");
    }
}
