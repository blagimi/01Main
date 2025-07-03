﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

К агрегатным операциям относят различные операции над выборкой, например, получение числа элементов,
получение минимального, максимального и среднего значения в выборке, а также суммирование значений.

*/
#region Метод Aggregate

/*
Метод Aggregate выполняет общую агрегацию элементов коллекции в зависимости от указанного выражения. 
Например:

*/

static void Example()
{
    int[] numbers = { 1, 2, 3, 4, 5};
    
    int query = numbers.Aggregate((x,y)=> x - y);
    Console.WriteLine(query);   // -13
}

Example();

/*
Переменная query будет представлять результат агрегации массива. В качестве условия агрегации 
используется выражение (x,y)=> x - y, то есть вначале из первого элемента вычитается второй, 
потом из получившегося значения вычитается третий и так далее. То есть будет эквивалентно выражению:

int query = 1 - 2 - 3 - 4 - 5
В итоге мы получим число -13. Соответственно мы бы могли использовать любые другие операции, 
например, сложение:

int query = numbers.Aggregate((x,y)=> x + y); // аналогично 1 + 2 + 3 + 4 + 5
Еще одна версия метода позволяет задать начальное значение, с которого начинается цепь агрегатных операций:

string[] words = { "Gaudeamus", "igitur", "Juvenes", "dum", "sumus" };
var sentence = words.Aggregate("Text:", (first, next) => $"{first} {next}");
 
Console.WriteLine(sentence);  // Text: Gaudeamus igitur Juvenes dum sumus
В данном случае объединяются все элементы массива words, но первым элемент агрегатной 
операции будет строка "Text:".


*/

#endregion

#region Получение размера выборки. Метод Count

/*
Для получения числа элементов в выборке используется метод Count():
*/

static void Example2()
{
    int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
    int size = numbers.Count();  // 10
    Console.WriteLine(size);
}

Example2();

/*
Метод Count() в одной из версий также может принимать лямбда-выражение, которое устанавливает 
условие выборки. Поэтому мы можем в данном случае не использовать выражение Where:
*/

static void Example3()
{
    int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
    //  количество четных чисел, которые больше 10
    int size = numbers.Count(i => i % 2 == 0 && i > 10);
    Console.WriteLine(size);    // 3
}

Example3();

#endregion

#region Получение суммы

/*
Для получения суммы значений применяется метод Sum:
*/

static void Example4()
{
    int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
    
    int sum = numbers.Sum();
    Console.WriteLine(sum);     // 340
}

Example4();

/*
Метод Sum() имеет ряд перегрузок. В частности, если у нас набор сложных объектов, 
как в примере выше, то мы можем указать свойство, значения которого будут суммироваться:
*/

static void Example5()

{
    Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };
    
    int ageSum = people.Sum(p => p.Age);
    Console.WriteLine(ageSum);     // 106
}

Example5();

/*
В данном случае вычисляется сумма значений свойств Age объектов Person из массива people.
*/

#endregion

#region Максимальное, минимальное и среднее значения

/*
Для нахождения минимального значения применяется метод Min(), для получения максимального - метод Max(), 
а для нахождения среднего значения - метод Average(). Их действие похоже на методы Sum и Count:
*/


static void Example6()
{
    int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
    
    int min = numbers.Min();
    int max = numbers.Max();
    double average = numbers.Average();
    
    Console.WriteLine($"Min: {min}");           // Min: 1
    Console.WriteLine($"Max: {max}");           // Max: 88
    Console.WriteLine($"Average: {average}");   // Average: 34
}

Example6();

/*
Если мы работаем со сложными объектами, то в эти методы передается делегат, который принимает 
свойство, применяемое в вычислениях:
*/

static void Example7()
{
    Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };
    
    int minAge = people.Min(p => p.Age); // минимальный возраст
    int maxAge = people.Max(p => p.Age); // максимальный возраст
    double averageAge = people.Average(p => p.Age); //средний возраст
    
    Console.WriteLine($"Min Age: {minAge}");           // Min Age: 28
    Console.WriteLine($"Max Age: {maxAge}");           // Max Age: 41
    Console.WriteLine($"Average Age: {averageAge}");   // Average Age: 35,33
}

Example7();
 
/*

В данном случае для вычислений применяется свойство Age, то есть вычисляется минимальный, максимальный и средний возраст.

*/

#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, int Age);