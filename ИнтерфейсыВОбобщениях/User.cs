using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ИнтерфейсыВОбобщениях
{
    internal class User<T>(T id) : IUser<T>
    {
        public T Id { get; } = id;
    }
}
