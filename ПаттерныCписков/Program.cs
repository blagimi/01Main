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


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */