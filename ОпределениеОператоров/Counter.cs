using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОпределениеОператоров
{
    internal class Counter
    {
        public int Value { get; set; }

        public static Counter operator +(Counter counter1, Counter counter2)
        {
            return new Counter { Value = counter1.Value + counter2.Value };
        }
        public static bool operator >(Counter counter1, Counter counter2)
        {
            return counter1.Value > counter2.Value;
        }
        public static bool operator <(Counter counter1, Counter counter2)
        {
            return counter1.Value < counter2.Value;
        }
    }
}
