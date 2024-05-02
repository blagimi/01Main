using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеОбобщенныхТипов
{
    internal class UniversalPerson<T> :Person<T>
    {
        public UniversalPerson(T id) : base(id) { }
    }
}
