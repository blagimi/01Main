using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АбстрактныеКлассы
{
    /*
     * Транспортное средство представляет некоторую абстракцию, которая не имеет 
     * конкретного воплощения. То есть есть легковые и грузовые машины, самолеты, 
     * морские судна но как такового транспортного средства нет. Тем не менее все 
     * транспортные средства имеют нечто общее - они могут перемещаться. 
     * И для этого в классе определен метод Move, который эмулирует перемещение.
     */
    internal abstract class Transport
    {
        public void Move()
        {
            Console.WriteLine("Транспортное средство движется");
        }
    }
}
