using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    public delegate int MathOperation(int x, int y);
    public class Operation
    {     
        public static int Add(int x, int y) => x + y;
        public static int Multiply(int x, int y) => x * y;
        public static int Substract(int x, int y) => x - y;
        public static decimal Sqare(int x) => x * x;
        public static int Double(int x) => x + x;
    }
}
