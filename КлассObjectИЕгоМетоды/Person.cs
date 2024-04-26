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
    }
}
