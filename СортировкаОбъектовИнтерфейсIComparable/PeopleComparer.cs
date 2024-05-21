using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СортировкаОбъектовИнтерфейсIComparable
{
    internal class PeopleComparer : IComparer<Person3>
    {
        public int Compare(Person3? p1, Person3? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.Name.Length - p2.Name.Length;
        }
    }
}
