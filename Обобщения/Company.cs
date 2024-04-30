using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обобщения
{
    internal class Company<P> (P ceo)
    {
        public P CEO { get; set; } = ceo;
    }
}
