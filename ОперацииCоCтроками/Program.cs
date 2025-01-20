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

#region Сравнение строк

/*
Для сравнения строк применяется статический метод Compare
*/

string st1 = "hello";
string st2 = "world";
 
int result = string.Compare(st1, st2);
if (result<0)
{
    Console.WriteLine("Строка s1 перед строкой s2");
}
else if (result > 0)
{
    Console.WriteLine("Строка s1 стоит после строки s2");
}
else
{
    Console.WriteLine("Строки s1 и s2 идентичны");
}
// результатом будет "Строка s1 перед строкой s2"

/*
Данная версия метода Compare принимает две строки и возвращает число. Если первая
строка по алфавиту стоит выше второй, то возвращается число меньше нуля. В 
противном случае возвращается число больше нуля. И третий случай - если строки
равны, то возвращается число 0.

В данном случае так как символ h по алфавиту стоит выше символа w, то и первая 
строка будет стоять выше.
*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Поиск в строке

/*
С помощью метода IndexOf мы можем определить индекс первого вхождения отдельного 
символа или подстроки в строке:
*/

string s31 = "hello world";
char ch = 'o';
int indexOfChar = s31.IndexOf(ch); // равно 4
Console.WriteLine(indexOfChar);
 
string substring = "wor";
int indexOfSubstring = s31.IndexOf(substring); // равно 6
Console.WriteLine(indexOfSubstring);

/*
Подобным образом действует метод LastIndexOf, только находит индекс последнего
 вхождения символа или подстроки в строку.

Еще одна группа методов позволяет узнать начинается или заканчивается ли строка на
 определенную подстроку. Для этого предназначены методы StartsWith и EndsWith.
 Например, в массиве строк хранится список файлов, и нам надо вывести все файлы
  с расширением exe:
*/

var files = new string[]
{
    "myapp.exe",
    "forest.jpg",
    "main.exe",
    "book.pdf",
    "river.png"
};
 
for (int i = 0; i < files.Length; i++)
{
    if (files[i].EndsWith(".exe"))
        Console.WriteLine(files[i]);
}

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Разделение строк

/*
С помощью функции Split мы можем разделить строку на массив подстрок. В качестве 
параметра функция Split принимает массив символов или строк, которые и будут служить
разделителями. Например, подсчитаем количество слов в сроке, разделив ее по пробельным
символам:
*/
string text = "И поэтому все так произошло";
 
string[] words = text.Split(new char[] { ' ' });
 
foreach (string s in words)
{
    Console.WriteLine(s);
}
/* 
Это не лучший способ разделения по пробелам, так как во входной строке у нас могло бы
быть несколько подряд идущих пробелов и в итоговый массив также бы попадали пробелы,
поэтому лучше использовать другую версию метода:
*/

string[] words2 = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

/* Второй параметр StringSplitOptions.RemoveEmptyEntries говорит, что надо удалить 
все пустые подстроки. */

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Обрезка строки

/*
Для обрезки начальных или концевых символов используется функция Trim:
*/

string text2 = " hello world ";
 
text2 = text2.Trim(); // результат "hello world"
text2 = text2.Trim(new char[] { 'd', 'h' }); // результат "ello worl"

/*
Функция Trim без параметров обрезает начальные и конечные пробелы и возвращает 
обрезанную строку. Чтобы явным образом указать, какие начальные и конечные символы
следует обрезать, мы можем передать в функцию массив этих символов.
Эта функция имеет частичные аналоги: функция TrimStart обрезает начальные символы,
а функция TrimEnd обрезает конечные символы.
Обрезать определенную часть строки позволяет функция Substring:
*/

string text3 = "Хороший день";
// обрезаем начиная с третьего символа
text3 = text3.Substring(2);
// результат "роший день"
Console.WriteLine(text3);
// обрезаем сначала до последних двух символов
text3 = text3.Substring(0, text.Length - 2);
// результат "роший де"
 Console.WriteLine(text3);

/*
Функция Substring также возвращает обрезанную строку. В качестве параметра первая 
использованная версия применяет индекс, начиная с которого надо обрезать строку.
 Вторая версия применяет два параметра - индекс начала обрезки и длину вырезаемой 
 части строки.
*/


#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Вставка

/* Для вставки одной строки в другую применяется функция Insert: */

string text4 = "Хороший день";
string substring2 = "замечательный ";
 
text4 = text4.Insert(8, substring2);
Console.WriteLine(text4);    // Хороший замечательный день
/* Первым параметром в функции Insert является индекс, по которому надо вставлять
 подстроку, а второй параметр - собственно подстрока. */

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Удаление строк

/*
Удалить часть строки помогает метод Remove:
*/

string text5 = "Хороший день";
// индекс последнего символа
int ind = text5.Length - 1;
// вырезаем последний символ
text5 = text5.Remove(ind); 
Console.WriteLine(text5);    // Хороший ден
 
// вырезаем первые два символа
text5 = text5.Remove(0, 2);
Console.WriteLine(text5);    // роший ден
/* 
Первая версия метода Remove принимает индекс в строке, начиная с которого надо 
удалить все символы. Вторая версия принимает еще один параметр - сколько символов
надо удалить.
*/


#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Замена


#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Смена регистра


#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */