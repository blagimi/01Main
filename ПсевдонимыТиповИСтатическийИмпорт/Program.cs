/*
 * Псевдонимы.
 * Для различных классов и структур мы можем использовать псевдонимы. 
 * Затем в программе вместо названия типа используется его псевдоним. 
 * Например, для вывода строки на экран применяется метод Console.WriteLine(). 
 * Но теперь зададим для класса Console псевдоним:
 */

using printer2 = System.Console;
using User = Person;
using static Operation;
using static System.Console;
printer2.WriteLine("Привет мир");
printer2.WriteLine("Добрый день");

/*
 * С помощью выражения using printer = System.Console указываем, что псевдонимом для класса System.Console 
 * будет имя printer. Это выражение не имеет ничего общего с подключением пространств имен в начале файла, 
 * хотя и использует оператор using.
 */

/*  Определим класс и для него псевдоним: */
User tom = new("Tom");
printer2.WriteLine(tom.Name);


/*
 * Статический импорт
 * Также в C# имеется возможность импорта статической функциональности классов. 
 * Выражение using static подключает в программу все статические методы и свойства, а также константы.
 * Например, импортируем возможности класса Console:
 * И после этого мы можем не указывать название класса при вызове метода.
 * Подобным образом можно определять свои классы и импортировать их:
 */
WriteLine(Sum(5, 4));       //  9
WriteLine(Subtract(5, 4));  //  1
WriteLine(Multiply(5, 4));  //  20
static class Operation
{
    public static int Sum(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
}
class Person(string name)
{
    public string Name { get; set; } = name;
}

