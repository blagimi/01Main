using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СтатическиеЧлены
{
    internal class PersonConstructor
    {
        static readonly int retiremntAge;
        public static int RetirementAge => retiremntAge;
        static PersonConstructor()
        {
            if (DateTime.Now.Year == 2024)
                retiremntAge = 65;
            else
                retiremntAge = 67;
        }
    }
}
