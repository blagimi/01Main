﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
#region Строки и класс String
/*
Работа со строками
Строки и класс String
  
Довольно большое количество задач, которые могут встретиться при разработке приложений, 
так или иначе связано с обработкой строк - парсинг веб-страниц, поиск в тексте, какие-то
аналитические задачи, связанные с извлечением нужной информации из текста и т.д. 
Поэтому в этом плане работе со строками уделяется особое внимание.

В языке C# строковые значения представляет тип string, а вся функциональность работы
с данным типом сосредоточена в классе System.String. Собственно string является 
псевдонимом для класса String. Объекты этого класса представляют текст как
последовательность символов Unicode. Максимальный размер объекта String может 
составлять в памяти 2 ГБ, или около 1 миллиарда символов.
*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Создание строк
/*
Создание строк
Создавать строки можно, как используя переменную типа string и присваивая ей значение,
так и применяя один из конструкторов класса String:
*/

string s1 = "hello";
string s2 = new String('a', 6); // результатом будет строка "aaaaaa"
string s3 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
string s4 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' }, 1, 3); // orl
 
Console.WriteLine(s1);  // hello
Console.WriteLine(s2);  // aaaaaaa
Console.WriteLine(s3);  // world
Console.WriteLine(s4);  // orl

/* Конструктор String имеет различное число версий. Так, вызов конструктора */

new String('a', 6);

/* 6 раз повторит объект из первого параметра, то есть фактически создаст строку "aaaaaa".

Еще один конструктор принимает массив символов, из которых создается строка
*/

string s5 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });

/*Третий использованный выше в примере конструктор позволяет создать строку из части
 массива символов. Второй параметр передает начальный индекс, с которого извлкаются 
 символы, а третий параметр указывает на количество символов:

*/
string s6 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' }, 1, 3); // orl

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */