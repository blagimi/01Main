﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
В C# 8.0 была добавлена новая функциональность - индексы и диапазоны, которые упрощают 
получение из массивов подмассивов. Для этого в C# есть два типа: System.Range и 
System.Index. Оба типа являются структурами. Тип Range представляет некоторый диапазон 
значений в некоторой последовательность, а тип Index - индекс в последовательности.
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Индексы
Индекс фактически представляет числовое значение, и при определении индекса мы 
можем указать это значение:

Index myIndex = 2;
В данном случае индекс представляет третий элемент последовательности (индексация начинается с 0).
С помощью специального оператора ^ можно задать индекс относительно конца последовательности.
Index myIndex = ^2;
Теперь индекс представляет второй элемент с конца последовательности, то есть предпоследний элемент.
Используем индексы для получения элементов массива:
*/

Index myIndex1 = 2;     // третий элемент
Index myIndex2 = ^2;    // предпоследний элемент
 
string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
string selected1 = people[myIndex1];    // Sam
string selected2 = people[myIndex2];    // Kate
Console.WriteLine(selected1);   
Console.WriteLine(selected2);

/*
Фактически для данной задачи индексы не нужны, и мы можем воспользоваться стандартными 
возможностями массивов:
*/

string[] people2 = { "Tom", "Bob", "Sam", "Kate", "Alice" };
string selected3 = people2[2];    // Sam
string selected4 = people2[people2.Length - 2];    // Kate
Console.WriteLine(selected3);   
Console.WriteLine(selected4);

/*
То есть в подобных ситуациях плюсом индексов является большая удобочитаемость. Так, people[^2] более читабельно, чем people[people.Length - 2].
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Диапазон
Диапазон представляет часть последовательности, которая ограничена двумя индексами.
Начальный индекс включается в диапазон, а конечный индекс НЕ входит в диапазон. Для
определения диапазона применяется оператор ..:

Range myRange1 = 1..4; // по 1-го индекса включая по 4-й индекс не включая

В данном случае диапазон myRange1 включает элементы с 1 индекса по 4-й индекс 
(не включая). При этом элемент по 4-му индексу не включается в диапазон. При этом
 границы диапазона задаются не просто числами, а именно объектами Index. То есть 
 следующие определения диапазонов будут равноценны:
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */