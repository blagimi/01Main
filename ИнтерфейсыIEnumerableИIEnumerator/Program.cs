﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using System.Collections;
using ИнтерфейсыIEnumerableИIEnumerator;

/*
Интерфейсы IEnumerable и IEnumerator
Как мы увидели, основной для большинства коллекций является реализация интерфейсов 
IEnumerable и IEnumerator. Благодаря такой реализации мы можем перебирать объекты в
 цикле foreach:

 foreach(var item in перечислимый_объект)
{
     
}
Перебираемая коллекция должна реализовать интерфейс IEnumerable.

Интерфейс IEnumerable имеет метод, возвращающий ссылку на другой интерфейс - перечислитель:

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}
А интерфейс IEnumerator определяет функционал для перебора внутренних объектов в 
контейнере:

Метод MoveNext() перемещает указатель на текущий элемент на следующую позицию в 
последовательности. Если последовательность еще не закончилась, то возвращает true. 
Если же последовательность закончилась, то возвращается false.

Свойство Current возвращает объект в последовательности, на который указывает 
указатель.

Метод Reset() сбрасывает указатель позиции в начальное положение.

Каким именно образом будет осуществляться перемещение указателя и получение элементов 
зависит от реализации интерфейса. В различных реализациях логика может быть построена
 различным образом.

Например, без использования цикла foreach перебирем массив с помощью интерфейса
 IEnumerator:
*/



string[] people = {"Tom", "Sam", "Bob"};
 
System.Collections.IEnumerator peopleEnumerator = people.GetEnumerator(); // получаем IEnumerator
while (peopleEnumerator.MoveNext())   // пока не будет возвращено false
{
    string item = (string)peopleEnumerator.Current; // получаем элемент на текущей позиции
    Console.WriteLine(item);
}
peopleEnumerator.Reset(); // сбрасываем указатель в начало массива

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Реализация IEnumerable и IEnumerator
Рассмотрим простешую реализацию IEnumerable на примере: */


Week week = new Week();
foreach (var day in week)
{
    Console.WriteLine(day);
}
 

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */