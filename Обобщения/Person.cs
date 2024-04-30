using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обобщения
{
    /*
     * Угловые скобки в описании class Person<T> указывают, что класс является 
     * обобщенным, а тип T, заключенный в угловые скобки, будет использоваться 
     * этим классом. Необязательно использовать именно букву T, это может быть и 
     * любая другая буква или набор символов. Причем сейчас на этапе написания 
     * кода нам неизвестно, что это будет за тип, это может быть любой тип.
     * Поэтому параметр T в угловых скобках еще называется универсальным
     * параметром, так как вместо него можно подставить любой тип.
     */
    internal class Person<T>
    {
        public static T? code;
        public T Id { get; set; }
        public string Name { get; set; }
        public Person(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
