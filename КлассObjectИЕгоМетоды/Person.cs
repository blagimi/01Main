using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КлассObjectИЕгоМетоды
{
    internal class Person
    {
        public string Name { get; set; } = "";
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            // Если параметр метода представляет тип Person
            // то возвращаем true, если имена совпадают.
            if (obj is Person person) return Name == person.Name;
            return false;
        }
    }
}
