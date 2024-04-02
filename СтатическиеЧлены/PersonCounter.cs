using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СтатическиеЧлены
{
    internal class PersonCounter
    {
        static int counter = 0;
        public static int Counter => counter;
        public PersonCounter()
        {
            counter++;
        }
    }
}
