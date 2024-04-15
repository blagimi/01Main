using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * После двоеточия мы указываем базовый класс для данного класса. 
 * Для класса Employee базовым является Person, и поэтому класс Employee наследует все те же свойства, 
 * методы, поля, которые есть в классе Person. Единственное, что не передается при наследовании,
 * это конструкторы базового класса с параметрами.
 * Таким образом, наследование реализует отношение is-a (является), 
 * объект класса Employee также является объектом класса Person:
 */
namespace Наследование
{
    internal class Employee(string name, string company) : Person(name)
    {
        public string Company { get; set; } = company;
    }

}
/*
 * И поскольку объект Employee является также и объектом Person, то мы можем так определить 
 * переменную: Person p = new Employee().
 * По умолчанию все классы наследуются от базового класса Object, 
 * даже если мы явным образом не устанавливаем наследование. 
 * Поэтому выше определенные классы Person и Employee кроме своих собственных методов, 
 * также будут иметь и методы класса Object: ToString(), Equals(), GetHashCode() и GetType().
*/
