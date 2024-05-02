using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace НаследованиеОбобщенныхТипов
{
    internal class StringPerson : Person<string>
    {
        public StringPerson(string id) : base(id) { }
    }
}
