﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Типы данных

/*
Как и во многих языках программирования, в C# есть своя система типов данных, которая 
используется для создания переменных. Тип данных определяет внутреннее представление 
данных, множество значений, которые может принимать объект, а также допустимые действия,
которые можно применять над объектом.

В языке C# есть следующие базовые типы данных:

*/

//bool: хранит значение true или false (логические литералы). Представлен системным типом System.Boolean


bool alive = true;
bool isDead = false;
//byte: хранит целое число от 0 до 255 и занимает 1 байт. Представлен системным типом System.Byte


byte bit1 = 1;
byte bit2 = 102;
//sbyte: хранит целое число от -128 до 127 и занимает 1 байт. Представлен системным типом System.SByte


sbyte bit3 = -101;
sbyte bit4 = 102;
//short: хранит целое число от -32768 до 32767 и занимает 2 байта. Представлен системным типом System.Int16


short n1 = 1;
short n2 = 102;
//ushort: хранит целое число от 0 до 65535 и занимает 2 байта. Представлен системным типом System.UInt16


ushort n3 = 1;
ushort n4 = 102;
//int: хранит целое число от -2147483648 до 2147483647 и занимает 4 байта. 
//Представлен системным типом System.Int32. Все целочисленные литералы по умолчанию представляют значения типа int:


int a = 10;
int b = 0b101;  // бинарная форма b =5
int c = 0xFF;   // шестнадцатеричная форма c = 255
//uint: хранит целое число от 0 до 4294967295 и занимает 4 байта. Представлен системным типом System.UInt32


uint a2 = 10;
uint b2 = 0b101;
uint c2 = 0xFF;
//long: хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт. 
//Представлен системным типом System.Int64


long a3 = -10;
long b3 = 0b101;
long c3 = 0xFF;
//ulong: хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт. 
//Представлен системным типом System.UInt64


ulong a4 = 10;
ulong b4 = 0b101;
ulong c4 = 0xFF;
//float: хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта. 
//Представлен системным типом System.Single

//double: хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта. 
//Представлен системным типом System.Double

//decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, 
//имеет значение от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой и
// занимает 16 байт. Представлен системным типом System.Decimal

//char: хранит одиночный символ в кодировке Unicode и занимает 2 байта. 
//Представлен системным типом System.Char. Этому типу соответствуют символьные литералы:


char a5 = 'A';
char b5 = '\x5A';
char c5 = '\u0420';
//string: хранит набор символов Unicode. Представлен системным типом System.String. 
//Этому типу соответствуют строковые литералы.


string hello = "Hello";
string word = "world";
//object: может хранить значение любого типа данных и занимает 4 байта на 32-разрядной 
//платформе и 8 байт на 64-разрядной платформе. Представлен системным типом System.Object,
// который является базовым для всех других типов и классов .NET.


object a6 = 22;
object b6 = 3.14;
object c6 = "hello code";
//Например, определим несколько переменных разных типов и выведем их значения на консоль:


string name2 = "Tom";
int age2 = 33;
bool isEmployed = false;
double weight = 78.65;
 
Console.WriteLine($"Имя: {name2}");
Console.WriteLine($"Возраст: {age2}");
Console.WriteLine($"Вес: {weight}");
Console.WriteLine($"Работает: {isEmployed}");

/*
Для вывода данных на консоль здесь применяется интерполяция: перед строкой ставится 
знак $ и после этого мы можем вводить в строку в фигурных скобках значения переменных.
Консольный вывод программы:
Имя: Tom
Возраст: 33
Вес: 78,65
Работает: False

Использование суффиксов
При присвоении значений надо иметь в виду следующую тонкость: все вещественные литералы
(дробные числа) рассматриваются как значения типа double. И чтобы указать, что дробное
число представляет тип float или тип decimal, необходимо к литералу добавлять суффикс:
F/f - для float и M/m - для decimal.

*/
float a7 = 3.14F;
float b7 = 30.6f;
 
decimal c7 = 1005.8M;
decimal d7 = 334.8m;
/*
Подобным образом все целочисленные литералы рассматриваются как значения типа int. 
Чтобы явным образом указать, что целочисленный литерал представляет значение типа 
uint, надо использовать суффикс U/u, для типа long - суффикс L/l, а для типа ulong 
- суффикс UL/ul:
*/

uint a8 = 10U;
long b8 = 20L;
ulong c8 = 30UL;

/*
Использование системных типов
Выше при перечислении всех базовых типов данных для каждого упоминался системный тип.
Потому что название встроенного типа по сути представляет собой сокращенное 
обозначение системного типа. Например, следующие переменные будут эквивалентны 
по типу:
*/

int a9 = 4;
System.Int32 b9 = 4;

/*
Неявная типизация
Ранее мы явным образом указывали тип переменных, например, int x;. И компилятор 
при запуске уже знал, что x хранит целочисленное значение.
Однако мы можем использовать и модель неявной типизации:
*/
var hello2 = "Hell to World";
var c10 = 20;

/*
Для неявной типизации вместо названия типа данных используется ключевое слово var.
Затем уже при компиляции компилятор сам выводит тип данных исходя из присвоенного 
значения. Так как по умолчанию все целочисленные значения рассматриваются как 
значения типа int, то поэтому в итоге переменная c будет иметь тип int. 
Аналогично переменной hello присваивается строка, поэтому эта переменная
будет иметь тип string

Эти переменные подобны обычным, однако они имеют некоторые ограничения.

Во-первых, мы не можем сначала объявить неявно типизируемую переменную, а
затем инициализировать:
*/

// этот код работает
int a11;
a11 = 20;
 
// этот код не работает
//var c;
//c= 20;
//Во-вторых, мы не можем указать в качестве значения неявно типизируемой переменной null:


// этот код не работает
//var c=null;
//Так как значение null, то компилятор не сможет вывести тип данных.
System.Console.WriteLine($"{a}{b}{c}{alive}{isDead}{bit1}{bit2}{bit3}{bit4}{n1}{n2}{n3}{n4}{a2}{b2}{c2}{a3}{b3}{c3}{a4}{b4}{c4}{a5}{b5}{c5}{hello}{word}{a7}{b7}{c7}{a8}{d7}{b8}{c8}{a9}{b9}{hello2}{c10}{a11}");
#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


Console.Write("Введите имя: ");
string? name = Console.ReadLine();  // ? после типа - присваивает введеное значение либо null
Console.Write("Введите возраст: ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите рост: ");
double  height = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите размер зарплаты: ");
decimal salary = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine($"Имя: {name} Возраст: {age} Зарплата: {salary}");