using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace События
{
    internal class Account2 (int sum)
    {
        AccountHandler? notify;
        public event AccountHandler Notify
        {
            add
            {
                notify += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                notify -= value;
                Console.WriteLine($"{value.Method.Name} удалён");
            }
        }
        public int Sum { get; private set; } = sum;
        public void Put(int sum)
        {
            Sum += sum;
            notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
                notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }

}
