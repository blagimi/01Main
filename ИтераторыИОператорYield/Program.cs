﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using ИтераторыИОператорYield;

/*
Итератор по сути представляет блок кода, который использует оператор yield для перебора
набора значений. Данный блок кода может представлять тело метода, оператора или блок
get в свойствах.
Итератор использует две специальных инструкции:

    - yield return: определяет возвращаемый элемент
    - yield break: указывает, что последовательность больше не имеет элементов
    
Рассмотрим небольшой пример:
*/

Numbers numbers = new Numbers();
foreach (int n in numbers)
{
    Console.WriteLine(n);
}
/*
В классе Numbers метод GetEnumerator() фактически представляет итератор. С помощью 
оператора yield return возвращается некоторое значение (в данном случае квадрат числа).
В программе с помощью цикла foreach мы можем перебрать объект Numbers как обычную 
коллекцию. При получении каждого элемента в цикле foreach будет срабатывать оператор
 yield return, который будет возвращать один элемент и запоминать текущую позицию.
Благодаря итераторам мы можем пойти дальше и легко реализовать перебор числа в цикле
 foreach:
*/

foreach(var n in 5) Console.WriteLine(n);
foreach (var n in -5) Console.WriteLine(n);

/* В данном случае итератор реализован как метод расширения для типа int или
 System.Int32. В методе итератора фактически возвращаем все целочисленные значения
  от 0 до текущего числа.
  Другой пример: пусть у нас есть коллекция Company, которая представляет компанию 
  и которая хранит в массиве personnel штат сотрудников - объектов Person. 
  Используем оператор yield для перебора этой коллекции: */


  /*
  Метод GetEnumerator() представляет итератор. И когда мы будем осуществлять перебор
   в объекте Company в цикле foreach, то будет идти обращение к вызову yield return 
   personnel[i];. При обращении к оператору yield return будет сохраняться текущее 
   местоположение. И когда метод foreach перейдет к следующей итерации для получения
    нового объекта, итератор начнет выполнения с этого местоположения.

Ну и в основной программе в цикле foreach выполняется собственно перебор, благодаря 
реализации итератора:
  */

  var people = new Person[] 
{ 
    new Person("Tom"), 
    new Person("Bob"), 
    new Person("Sam") 
};
var microsoft = new Company(people);
 
foreach(Person employee in microsoft)
{
    Console.WriteLine(employee.Name);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */




/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */




Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */