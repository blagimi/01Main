using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АбстрактныеКлассы
{
    internal class Rectangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public override double GetPerimetr()
        {
            return Width * 2 + Height * 2;
        }
        public override double GetArea()
        {
           return Width * Height;
        }
    }
}
