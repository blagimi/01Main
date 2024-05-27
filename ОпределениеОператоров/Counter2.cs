using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОпределениеОператоров
{
    internal class Counter2
    {
        public static int operator +(Counter2 counter2, int val)
        {
            return counter2 + val;
        }
    }
}
