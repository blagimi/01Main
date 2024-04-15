using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Пусть у нас есть следующий класс Person, который описывает отдельного человека:
 */

namespace Наследование
{
    internal class Person(string name)
    {
        public string Name { get; set; } = name;

        public void PrintName()
        {
            Console.WriteLine(Name);
        }
    }
}
/*
 * Но вдруг нам потребовался класс, описывающий сотрудника предприятия - класс Employee.
 * Поскольку этот класс будет реализовывать тот же функционал, что и класс Person, 
 * так как сотрудник - это также и человек, то было бы рационально сделать класс Employee 
 * производным (или наследником, или подклассом) от класса Person, который, в свою очередь, 
 * называется базовым классом или родителем (или суперклассом):
 */
