using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АбстрактныеКлассы
{
    /// <summary>
    /// Абстрактный класс фигуры
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Абстрактный метод для получения перементра
        /// </summary>
        /// <returns>
        /// Периметр фигуры типа double
        /// </returns>
        public abstract double GetPerimetr();
        /// <summary>
        /// Абстрактный метод для получения площади
        /// </summary>
        /// <returns>
        /// Площадь фигру типа double</returns>
        public abstract double GetArea();
    }
}
