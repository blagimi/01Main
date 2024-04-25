using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КлассObjectИЕгоМетоды
{
    internal class Person2
    {
        public string Name { get; set; } = "";
        /// <summary>
        /// Переопределение базоваго метода object
        /// </summary>
        /// <returns>
        /// Возвращает инициализованное имя. Если его нет, выполняется базовый метод
        /// </returns>
        public override string? ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
    }
}
