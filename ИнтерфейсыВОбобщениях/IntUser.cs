using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИнтерфейсыВОбобщениях
{
    internal class IntUser(int id) : IUser<int>
    {
        public int Id { get; } = id;
    }
}
