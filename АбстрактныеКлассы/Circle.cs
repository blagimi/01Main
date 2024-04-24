using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АбстрактныеКлассы
{
    internal class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetPerimetr() => Radius * 2 * 3.14;
        public override double GetArea() => Radius * Radius * 3.14;
    }
}
                                                                                