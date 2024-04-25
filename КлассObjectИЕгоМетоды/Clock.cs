using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КлассObjectИЕгоМетоды
{
    internal class Clock
    {
        public byte Hours { get; set; }
        public byte Minutes { get; set; }
        public byte Seconds { get; set; }
        /// <summary>
        /// Переопределение метода из базового класса object
        /// </summary>
        /// <returns>
        /// Выводит указанное время на консоль в виде строки
        /// </returns>
        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }
}
