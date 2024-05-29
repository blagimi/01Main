using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПерегрузкаОперацийПреобразованияТипов
{
    internal class Counter
    {
        public int Seconds { get; set; }
        /// <summary>
        /// Неявное преобразование типа
        /// </summary>
        /// <param name="x">Объект для преобразования</param>
        public static implicit operator Counter(int x)
        {
            return new Counter { Seconds = x };
        }
        /// <summary>
        /// Явное преборазование типа
        /// </summary>
        /// <param name="counter">Содержимое счётчика</param>
        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }
    }
}
