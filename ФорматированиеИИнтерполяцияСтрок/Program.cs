﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Форматирование строк

/* При выводе строк в консоли с помощью метода Console.WriteLine для встраивания 
значений в строку мы можем применять форматирование вместо конкатенации:
*/

string name = "Tom";
int age = 23;
 
Console.WriteLine("Имя: {0}  Возраст: {1}", name, age);
// консольный вывод
// Имя: Tom  Возраст: 23

/* В строке "Имя: {0} Возраст: {1}" на место {0} и {1} затем будут вставляться в
порядке следования значения переменныйх name и age

То же самое форматирование в строке мы можем сделать не только в методе
Console.WriteLine, но и в любом месте программы с помощью метода string.Format:
*/

string name2= "Tom";
int age2 = 23;
string output = string.Format("Имя: {0}  Возраст: {1}", name2, age2);
Console.WriteLine(output);

/*
Метод Format принимает строку с плейсхолдерами типа {0}, {1} и т.д., а также набор
 аргументов, которые вставляются на место данных плейсхолдеров. В итоге генерируется
  новая строка.
*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Спецификаторы форматирования

/*
В методе Format могут использоваться различные спецификаторы и описатели, которые 
позволяют настроить вывод данных. Рассмотрим основные описатели. Все используемые 
форматы:

C / c

Задает формат денежной единицы, указывает количество десятичных разрядов после запятой

D / d

Целочисленный формат, указывает минимальное количество цифр

E / e

Экспоненциальное представление числа, указывает количество десятичных разрядов 
после запятой

F / f

Формат дробных чисел с фиксированной точкой, указывает количество десятичных
 разрядов после запятой

G / g

Задает более короткий из двух форматов: F или E

N / n

Также задает формат дробных чисел с фиксированной точкой, определяет количество 
разрядов после запятой

P / p

Задает отображения знака процентов рядом с число, указывает количество десятичных
 разрядов после запятой

X / x

Шестнадцатеричный формат числа

*/

/*
Форматирование валюты
Для форматирования валюты используется описатель "C":

*/
double number = 23.7;
string result = string.Format("{0:C0}", number);
Console.WriteLine(result); // 24 р.
string result2 = string.Format("{0:C2}", number);
Console.WriteLine(result2); // 23,70 р.
/*
Число после описателя указывает, сколько чисел будет использоваться после 
разделителя между целой и дробной частью. При выводе также добавляется
обозначение денежного знака для текущей культуры компьютера. В зависимости
 от локализации текущей операционной системы результат может различаться. 
 Также обратите внимание на округление в первом примере.
*/

/*
Форматирование целых чисел
Для форматирования целочисленных значение применяется описатель "d":

*/
int number2 = 23;
string result3 = string.Format("{0:d}", number2);
Console.WriteLine(result3); // 23
string result4 = string.Format("{0:d4}", number2);
Console.WriteLine(result4); // 0023

/*
Число после описателя указывает, сколько цифр будет в числовом значении. 
Если в исходном числе цифр меньше, то к нему добавляются нули.
*/

/*
Форматирование дробных чисел
Для форматирования дробны чисел используется описатель F, число после 
которого указывает, сколько знаков будет использоваться после разделителя 
между целой и дробной частью. Если исходное число - целое, то к нему
 добавляются разделитель и нули.
*/

int number3 = 23;
string result5 = string.Format("{0:f}", number3);
Console.WriteLine(result5); // 23,00
 
double number4 = 45.08;
string result6 = string.Format("{0:f4}", number4);
Console.WriteLine(result6); // 45,0800
 
double number5 = 25.07;
string result7 = string.Format("{0:f1}", number5);
Console.WriteLine(result7); // 25,1

/*
Формат процентов
Описатель "P" задает отображение процентов. Используемый с ним числовой спецификатор указывает, сколько знаков будет после запятой:
*/

decimal number6 = 0.15345m;
Console.WriteLine("{0:P1}", number6);// 15,3%

/*
Настраиваемые форматы
Используя знак #, можно настроить формат вывода. Например, нам надо вывести некоторое число в формате телефона +х (ххх)ххх-хх-хх:
*/

long number7 = 19876543210;
string result8 = string.Format("{0:+# (###) ###-##-##}", number7);
Console.WriteLine(result8); // +1 (987) 654-32-10

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Метод ToString

/*
Метод ToString() не только получает строковое описание объекта, но и может осуществлять
 форматирование. Он поддерживает те же описатели, что используются в методе Format:
*/

long number8 = 19876543210;
Console.WriteLine(number8.ToString("+# (###) ###-##-##"));// +1 (987) 654-32-10
 
double money = 24.8;
Console.WriteLine(money.ToString("C2")); // 24,80 р.

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Интерполяция строк

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
