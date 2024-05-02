using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеОбобщенныхТипов
{
    internal class MixedPerson<T,K>: Person<T> 
        where K: struct
    {
        public K Code { get; set; }
        public MixedPerson(T id, K code) : base(id) { Code = code; }

    }
}
