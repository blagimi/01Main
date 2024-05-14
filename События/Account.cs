using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace События
{
    delegate void AccountHandler(string message);
    internal class Account
    {
        internal event AccountHandler? NotifyEvent;      //  Определение события  
        // Сумма на счёте
        public int Sum { get; private set; }
        // Конструктор для указания начальной суммы на счёте
        public Account(int sum) => Sum = sum;
        // Добавление средств на счёт
        public void Put(int sum)
        {
            Sum += sum;
            NotifyEvent?.Invoke($"На счёт поступило: {sum}");   // Вызов события
        }
        // Снятие средств со счёта
        public void Take(int sum)
        {
            if (Sum >= sum)
            { 
                Sum -= sum;
                NotifyEvent?.Invoke($"Со счёта снято: {sum}");  // Вызов события
            }
            else
            {
                NotifyEvent?.Invoke($"Недостаточно средств на счёте. Баланс: {Sum}");
            }
        }
        public static void CheckBalance(Account acc)
        {
            Console.WriteLine($"Сумма на счёте: {acc.Sum}");
        }
    }
}
