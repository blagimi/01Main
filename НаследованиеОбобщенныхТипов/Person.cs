using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеОбобщенныхТипов
{
    internal class Person<T>
    {
        public T Id { get; }
        public Person (T id)
        {
            Id = id;
        }
    }
}
