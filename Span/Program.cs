﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Тип Span представляет непрерывную область памяти. Цель данного типа - повысить 
производительность и эффективность использования памяти. Span позволяет избежать
дополнительных выделений памяти при операции с наборами данных. Поскольку Span
является структурой, то объект этого типа располагаетс в стеке, а не в хипе.
Создание Span
Для создания объекта Span можно применять один из его конструкторов:
Span(): создает пустой объект Span
Span(T item): создает объект Span с одним элементом item
Span(T[] array): создает объект Span из массива array
Span(void* pointer, int length): создает объект Span, который получает length байт
 памяти, начиная с указателя pointer
Span(T[] array, int start, int length): создает объект Span, который получает из
 массива array length элементов, начиная с индекса start
Например, простейшее создание Span:
*/
//Например, простейшее создание Span:
  
Span<string> people = ["Tom", "Bob", "Sam"];
//В данном случае Span будет хранить ссылки на три строки.

//Нередко Span создается на основе каких-то других наборов данных:

string[] people2 =  { "Tom", "Alice", "Bob" };
Span<string> peopleSpan = new Span<string>(people2);
//Мы также можем непосредственно присвоить массив, и он неявно будет преобразован в Span:

string[] people3 = { "Tom", "Alice", "Bob" };
Span<string> peopleSpan2 = people3;
//Далее мы можем получать, устанавливать или перебирать данные также, как в массиве:

string[] people4 = { "Tom", "Alice", "Bob" };
Span<string> peopleSpan3 = people4;
peopleSpan3[1] = "Ann";              // переустановка значения элемента
Console.WriteLine(peopleSpan3[2]);   // получение элемента
Console.WriteLine(peopleSpan3.Length);   // получение длины Span
 
// перебор Span
foreach (var s in peopleSpan3)
{
    Console.WriteLine(s);
}

/*
Если Span ведет себя внешне как массив, то в чем его преимущество или когда он нам 
может пригодиться? Рассмотрим простейшую ситуацию - у нас есть массив со значениями
 дневных температур воздуха за месяц, и нам надо получить их него два набора - набор 
 температур за первую декаду и за последнюю декаду. Используя массивы, мы могли бы 
 сделать так:
*/

int[] temperatures =
{
    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
};
int[] firstDecade = new int[10];    // выделяем память для первой декады
int[] lastDecade = new int[10];     // выделяем память для второй декады
Array.Copy(temperatures, 0, firstDecade, 0, 10);    // копируем данные в первый массив
Array.Copy(temperatures, 20, lastDecade, 0, 10);    // копируем данные во второй массив

/*
Для хранения данных создаются два дополнительных массива для дневных температур
 каждой декады. С помощью метода Array.Copy данные из исходного массива temperatures 
 копируются в два остальных массива. Но суть в данном случае в том, что для обоих 
 массивов мы вынуждены выделить память. То есть оба массива по сути содержат те же 
 данные, что и temperatures, однако в отдельных частях памяти.
*/

/* Span позволяет работать с памятью более эффективно и избежать ненужных выделений
 памяти. Так, используем вместо массивов Span: */

int[] temperatures2 =
{
    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
};
Span<int> temperaturesSpan = temperatures;
 
Span<int> firstDecade2 = temperaturesSpan.Slice(0, 10);    // нет выделения памяти под данные
Span<int> lastDecade2 = temperaturesSpan.Slice(20, 10);    // нет выделения памяти под данные

/* Для создания производных объектов Span применяется метод Slice, который из Spana 
выделяет часть и возвращает ее в виде другого объекта Span. Теперь объекты Span 
firstDecade и lastDecade работают с теми же данными, что и temperaturesSpan, а 
дополнительно память не выделяется. То есть во всех трех случаях мы работаем с
тем же массивом temperatures. Мы даже можем в одном Span изменить данные, и данные
изменятся в другом: */

int[] temperatures3 =
{
    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
};
Span<int> temperaturesSpan3 = temperatures3;
 
Span<int> firstDecade3 = temperaturesSpan3.Slice(0, 10);
 
temperaturesSpan3[0] = 25; // меняем в temperatureSpan
Console.WriteLine(firstDecade3[0]); //25

/*
За счет чего это достигается? Для понимания работы Span можно обратиться к исходному коду типа. В частности, мы можем в нем увидеть следующее свойство:

1
2
3
4
5
6
public readonly ref struct Span<T>
{
    //....
    public ref T this[int index] { get { ... } }
    //....
}
Здесь мы видим, что индексатор возвращает ref-ссылку, благодаря чем мы получаем доступ 
непосредственно к объекту и можем его изменять.

В данном случае, конечно, преимущества от отсутствия выделения дополнительной памяти
 под хранение объектов минимальны. Но при более интенсивной работе с данными выигрыш 
 в производительности неизбежно должен возрастать.
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */