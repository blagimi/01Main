using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеОбобщенныхТипов
{
    internal class IntPerson<T> : Person<int>
    {
        public T Code { get; set; }
        public IntPerson(int id, T code) : base(id) { Code = code; }
    }
}
