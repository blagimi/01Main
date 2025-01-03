﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Обьеденение строк
    
/*
Объединение строк
Конкатенация строк или объединение может производиться как с помощью операции +, так и 
с помощью метода Concat:
*/
string s1 = "hello";
string s2 = "world";
string s3 = s1 + " " + s2; // результат: строка "hello world"
string s4 = string.Concat(s3, "!!!"); // результат: строка "hello world!!!"
 
Console.WriteLine(s4);
/*
Метод Concat является статическим методом класса string, принимающим в качестве
параметров две строки. Также имеются другие версии метода, принимающие другое 
количество параметров.

Для объединения строк также может использоваться метод Join:

*/
string s5 = "apple";
string s6 = "a day";
string s7 = "keeps";
string s8 = "a doctor";
string s9 = "away";
string[] values = new string[] { s5, s6, s7, s8, s9 };
 
string s10 = string.Join(" ", values);
Console.WriteLine(s10); // apple a day keeps a doctor away
/*
Метод Join также является статическим. Использованная выше версия метода получает 
два параметра: строку-разделитель (в данном случае пробел) и массив строк, которые 
будут соединяться и разделяться разделителем. 
*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */