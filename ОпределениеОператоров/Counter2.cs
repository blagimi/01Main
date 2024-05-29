using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОпределениеОператоров
{
    internal class Counter2
    {
        public int Value { get; set; }
        public static Counter2 operator ++ (Counter2 counter1)
        {
            /*           
            counter1.Value += 10;
            return counter1;
            */
            return new Counter2 {Value = counter1.Value + 10};
        }
        public static bool operator true(Counter2 counter2)
        {
            return counter2.Value != 0;
        }
        public static bool operator false(Counter2 counter3)
        {
            return counter3.Value == 0;
        }
        public static bool operator !(Counter2 counter4)
        {
            return counter4.Value == 0;
        }

        public static int operator + (Counter2 counter1, Counter2 counter2)
        {
            return counter1.Value * counter2.Value;
        }
    }
}
