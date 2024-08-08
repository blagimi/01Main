﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* 
Двухсвязный список LinkedList<T> 
Класс LinkedList<T> представляет двухсвязный список, в котором каждый
элемент хранит ссылку одновременно на следущий и на предыдущий элемент.
*/



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/* Создание связанного списка */

/* Для создания связного списка можно принименять один из его конструктора. Например,
 создадим пустой связный список LinkedList<string> people = new LinkedList<string>();
В данном случае связанный список people предназначен для хранения строк.
Также можно в конструктор передать коллекцию элементов, например, список List, по 
которому будет создан связный список: */

var employees = new List<string> { "Tom", "Sam", "Bob" };
 
LinkedList<string> people = new LinkedList<string>(employees);
foreach (string person in people)
{
    Console.WriteLine(person);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadKey();
