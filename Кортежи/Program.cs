/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
Кортежи.
Кортежи предоставляют удобный способ для работы с набором значений, который был 
добавлен в версии C# 7.0. Кортеж представляет набор значений, заключенных в 
круглые скобки:
var tuple = (5, 10);
В данном случае определен кортеж tuple, который имеет два значения: 5 и 10. 
В дальнейшем мы можем обращаться к каждому из этих значений через поля с названиями:
Item[порядковый_номер_поля_в_кортеже]
*/

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

var tuple = (5, 10);
Console.WriteLine(tuple.Item1);         //  5
Console.WriteLine(tuple.Item2);         //  10
tuple.Item1 += 26;
Console.WriteLine(tuple.Item1);         //  31

/*
В данном случае тип определяется неявно. Но его так же можно явно указать.
(int, int) turple = (5,10);
(string, int, double) person = ("Tom", 25, 81.23);
Так же можно дать названия полям кортежа. Теперь для обращения к ним используются
имена а не названия Item1, Item2.
*/

var tuple2 = (count:5, sum:10);
Console.WriteLine(tuple2.count);        // 5
Console.WriteLine(tuple2.sum);          // 10

/*
Можно выполнить декомпозицию кортежа на отдельные переменные.
*/

var (name, age) = ("Tom", 23);
Console.WriteLine(name);                // Tom
Console.WriteLine(age);                 // 23

/*
Одна из задач которую позволяют элегантно решить кортеж это обмен занчениями
*/

string main = "Java";
string second = "C#";
(main, second) = (second, main);
Console.WriteLine(main);                // C#
Console.WriteLine(second);              // Java

/*
Что можно использовать, например в сортировке массива.
*/

int[] nums = [54,7,-41,2,4,2,89,33,-5,12];
                                        //  Сортировка
for (int i = 0; i < nums.Length; i++)
{
    for (int j = i+1; j<nums.Length; j++)
    {
        if (nums[i]>nums[j])
            (nums[i],nums[j]) = (nums[j],nums[i]);
    }
}
                                        //  Вывод
System.Console.WriteLine("Вывод отсортированного от меньшего к большему массива");
for (int i = 0; i<nums.Length; i++)
{
    System.Console.WriteLine(nums[i]);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Кортеж как результат метода.
Кортежи могут выступать в качестве результата функции. Например возвращение из функции
двух и более значений, в то время как функция может возвращать только одно. Котрежи
представляют оптимальный способ для решения этой задачи.
Метод GetValues возвращает кортеж. Кортеж определен как набор значений, помещенных
в круглые скобки. В данном случае возвращается кортеж из 2х элеметнов типа int т.е
два числа.
*/
var turple3 = GetValues();
System.Console.WriteLine(turple3.Item1); // 1    
System.Console.WriteLine(turple3.Item2); // 3

(int,int) GetValues()
{
    var result = (1,3);
    return result;
}

/*
Еще пример.
*/

var turple4 = GetValuesData(new int[] {1,2,3,4,5,6,7});
System.Console.WriteLine(turple4.count); // 7
System.Console.WriteLine(turple4.sum);   // 28

(int sum, int count) GetValuesData(int[] numbers)
{
    var result = (sum:0, count: numbers.Length);
    foreach(var n in numbers)
    {
        result.sum += n;
    }
    return result;
}


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Кортеж как параметр метода.
Здесь в метод PrintPerson передается кортеж из двух элементов, первый из которых
предоставляет строку, а второй - значение типа int.
*/

PrintPerson(("Tom",37));                //  Tom - 37
PrintPerson(("Bob",41));                //  Bob - 41

void PrintPerson((string name, int age) person)
{
    System.Console.WriteLine($"{person.name} - {person.age}");
}


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();