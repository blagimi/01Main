using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеИнтерфейсов
{
    internal class RunAction2 : IRunAction
    {
        public void Move() => Console.WriteLine("I am tired");
    }
}
