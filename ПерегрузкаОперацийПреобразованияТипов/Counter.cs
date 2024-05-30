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
        public static explicit operator Counter (Timer timer)
        {
            int counterHours = timer.Hours*3600;
            int counterMinutes = timer.Minutes*60;
            return new Counter {Seconds = counterHours + counterMinutes + timer.Seconds};
        }
        public static implicit operator Timer (Counter counter)
        {
            int timerHours = counter.Seconds / 3600;
            int timerMinutes = (counter.Seconds % 3600)/60;
            int timerSeconds = counter.Seconds % 60;
            return new Timer {Hours = timerHours, Minutes = timerMinutes, Seconds = timerSeconds};
        }
    }
}
