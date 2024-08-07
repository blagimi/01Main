﻿
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Паттерны списков (list pattern) позволяют сопоставлять выражения со списками и 
 * массивами. Данный паттерн пока доступен начиная с версии C# 11.Полное совпадение 
 * с массивом/списком:
 */

Console.WriteLine(GetNumber([1, 2, 3, 4, 5]));  // 1
Console.WriteLine(GetNumber([1, 2]));           // 3
Console.WriteLine(GetNumber([]));               // 4
Console.WriteLine(GetNumber([1, 2, 5]));        // 5

static int GetNumber(int[] values) => values switch
{
[1, 2, 3, 4, 5] => 1,
[1, 2, 3] => 2,
[1, 2] => 3,
[] => 4,
    _ => 5
};

/*
 * Аналогично вместо массивов можно применять списки:
 */

List<int> numbers = [1, 2, 3];

Console.WriteLine(GetNumber2(numbers));  // 2

int GetNumber2(List<int> values) => values switch
{
[1, 2, 3, 4, 5] => 1,
[1, 2, 3] => 2,
[1, 2] => 3,
[] => 4,
    _ => 5
};

/*
 * Аналогичным образом паттерны списков можно использовать в конструкции if:
 */

int[] numbers2 = { 1, 2, 3, 4, 5 };
if (numbers2 is [1, 2, 3, 4, 5])
{
    Console.WriteLine("[1, 2, 3, 4, 5]");
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Подстановка
 * С помощью паттерна _ можно обозначить одиночный элемент, который имеет любое значение.
 * Например, паттерн [2, _, 5] соответствует любому массиву из трех элементов, в котором 
 * между 2 и 5 располагается произвольное значение. А массив [_, _] соответствует любому 
 * массиву из двух произвольных элементов
 */

Console.WriteLine(GetNumber3(new[] { 2, 3, 5 }));       // 1
Console.WriteLine(GetNumber3(new[] { 2, 4, 6 }));      // 2
Console.WriteLine(GetNumber3(new[] { 1, 2, 5 }));      // 3
Console.WriteLine(GetNumber3(new[] { 1, 2, 3 }));      // 4
Console.WriteLine(GetNumber3(new int[] { }));         // 5

int GetNumber3(int[] values) => values switch
{
[2, _, 5] => 1,
[2, _, _] => 2,
[_, _, 5] => 3,
[_, _, _] => 4,
    _ => 5
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/*
 * slice-паттерн
 * Для передачи произвольного количества элементов массива/списка применяется
 * slice-паттерн ... Например, паттерн [1, 2, .., 5] соответствует массиву, в который
 * начинается на 1, за которым идет 2. А последний элемент в массиве - 5. При этом между 
 * 2 и 5 может располагаться произвольное количество произвольных целых чисел. То есть
 * паттерн [1, 2, .., 5] будет соответствовать таким массивам как
 */

int[] arr1 = { 1, 2, 3, 4, 5 };
int[] arr2 = { 1, 2, 5 };
int[] arr3 = { 1, 2, 66, 77, 88, 5 };

/*
 * С помощью паттерна .. можно задавать произвольное количество элементов как в 
 * начале, так и в конце массива/списка. Например, паттерн [2,..] представляет
 * массив, который начинается на 2. А паттерн [.., 5] представляет массив, который 
 * заканчивается элементом 5. Паттерн [..] представляет массив, который содержит 
 * произвольное количество элементов. Например
 */

Console.WriteLine(GetNumber4(new[] { 2, 5 }));           // 1
Console.WriteLine(GetNumber4(new[] { 2, 3, 4, 5 }));     // 1

Console.WriteLine(GetNumber4(new[] { 2 }));               // 2
Console.WriteLine(GetNumber4(new[] { 2, 3, 4 }));         // 2

Console.WriteLine(GetNumber4(new[] { 3, 4, 5 }));          // 3
Console.WriteLine(GetNumber4(new[] { 5 }));              // 3

Console.WriteLine(GetNumber4(new int[] { }));           // 4
Console.WriteLine(GetNumber4(new[] { 1 }));              // 4
Console.WriteLine(GetNumber4(new[] { 1, 2, 3 }));        // 4

int GetNumber4(int[] values) => values switch
{
[2, .., 5] => 1,    // если первый элемент - 2, а последний - 5
[2, ..] => 2,        // если первый элемент - 2
[.., 5] => 3,       // если последний элемент - 5
[..] => 4          // произвольное количество элементов
};

/*
 * slice-паттерн можно сочетать с символов подстановки _, например:
 * int GetNumber(int[] values) => values switch
{
    [_, .., _] => 1,
    [..] => 2
};
 */

/*
 * В данном случае паттерн [_, .., _] предполагает массив, который состоит как минимум
 * из двух произвольных элементов, и между первым и последним элементром может 
 * находиться произвольное количество других элементов: 
 */

Console.WriteLine(GetNumber5(new[] { 1, 2, 3, 4 }));   // 1
Console.WriteLine(GetNumber5(new[] { 1, 2, 3 }));     // 1
Console.WriteLine(GetNumber5(new[] { 1, 2 }));        // 1
Console.WriteLine(GetNumber5(new[] { 1 }));          // 2
Console.WriteLine(GetNumber5(new int[] { }));       // 2

int GetNumber5(int[] values) => values switch
{
[_, .., _] => 1,
[..] => 2
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Получение элементов в переменные
 */

int[] numbers3 = { 2, 3, 5 };
if (numbers3 is [var first, var second, .., var last])
{
    Console.WriteLine($"first: {first}, second: {second}  last: {last}");
}

/*
 * В данном случае получаем первый элемент массива в переменную first, второй элемент
 * в переменную second, а последний элемент - в переменную last.Пример с различными
 * массивами:
 */

Console.WriteLine(GetData(new[] { 1, 2, 3 }));        // First: 1  Second: 2  Last: 3
Console.WriteLine(GetData(new[] { 2, 4, 6, 8 }));    // First: 2  Second: 4  Last: 8
Console.WriteLine(GetData(new[] { 1, 2 }));          // Array has less than 3 elements

string GetData(int[] values) => values switch
{
[var first, var second, .., var last] => $"First: {first}  Second: {second}  Last: {last}",
[..] => "Array has less than 3 elements"
};

/*
 * В данном случае получаем первый элемент массива в переменную first, второй элемент 
 * в переменную second, а последний элемент - в переменную last.При этом значения, 
 * которые проектируются на паттерн .., также можно получить в переменную. Например,
 * в паттерне [2, .. var middle, 5] элементы, которые проектируются на .., можно 
 * передаются в переменную middle. Несколько примеров:
 */

Console.WriteLine(GetSlice(new[] { 2, 3, 4, 5 }));       // Middle: 3, 4
Console.WriteLine(GetSlice(new[] { 2, 4, 6, 8 }));      // End: 4, 6, 8
Console.WriteLine(GetSlice(new[] { 1, 2, 3, 5 }));      // Start: 1, 2, 3
Console.WriteLine(GetSlice(new[] { 1, 2, 3, 4 }));      // All: 1, 2, 3, 4
Console.WriteLine(GetSlice(new int[] { }));             // All: 

string GetSlice(int[] values) => values switch
{
[2, .. var middle, 5] => $"Middle: {string.Join(", ", middle)}",
[2, .. var end] => $"End: {string.Join(", ", end)}",
[.. var start, 5] => $"Start: {string.Join(", ", start)}",
[.. var all] => $"All: {string.Join(", ", all)}"
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Свойства коллекций.
 * Стоит отметить, что, поскольку массивы и списки - обычные классы C#, которые 
 * имеют свойства, то для них мы также можем применять паттерн свойств. Объединение 
 * паттерна свойств и паттерна списков позволяет упростить решение некоторых задач. 
 * Например, у нас есть задача: если массив имеет три элемента, то разложить его на 
 * три переменных:
 */

int[] numbers6 = { 2, 3, 5 };
if (numbers6 is { Length: 3 } and [var first5, var second5, var third5])
{
    Console.WriteLine($"first: {first5}, second: {second5}  third: {third5}");
}