using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СортировкаОбъектовИнтерфейсIComparable
{
    internal interface IComparer<in T>
    {
        int Compare(Person3? x, Person3? y);
    }
}
