/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Оператор orderby и метод OrderBy

/*

Для сортировки набора данных в LINQ можно применять оператор orderby:

*/

static void Example()
{
    int[] numbers = { 3, 12, 4, 10};
    var orderedNumbers = from i in numbers
                        orderby i
                        select i;
    foreach (int i in orderedNumbers)
        Console.WriteLine(i);
}

Example();

/*
Оператор orderby принимает критерий сортировки. В данном случае в качестве критерия выступает само число. Результат работы программы:

3
4
10
12

Если числа сортируются стандартным образом, как принято в математике, то строки сортируются исходя из алфавитного порядка:

*/

static void Example2()
{
    string[] people = { "Tom", "Bob", "Sam" };
    var orderedPeople = from p in people orderby p select p;
    foreach (var p in orderedPeople)
        Console.WriteLine(p);       // Bob Sam Tom
    }

Example2();

/*
Вместо оператора orderby можно применять метод расширения OrderBy():

OrderBy (Func<TSource,TKey> keySelector)
OrderBy (Func<TSource,TKey> keySelector, IComparer<TKey>? comparer);
Первая версия метода получает делегат, который через параметр получает элемент коллекции и который возвращает значение, применяемое для сортировки. Вторая версия позволяет также задать принцип сортировки через реализацию интерфейса IComparer.

Перепишем предыдущие два примера с помощью метода OrderBy:

*/

static void Example3()
{
    int[] numbers = { 3, 12, 4, 10 };
    var orderedNumbers = numbers.OrderBy(n=>n);
    foreach (int i in orderedNumbers)
        Console.WriteLine(i);
    
    string[] people = { "Tom", "Bob", "Sam" };
    var orderedPeople = people.OrderBy(p=>p);
    foreach (var p in orderedPeople)
        Console.WriteLine(p);
}

Example3();


#endregion

#region Сортировка сложных объектов

/*

Возьмем посложнее пример. Допустим, надо отсортировать выборку сложных объектов. Тогда в качестве критерия мы 
можем указать свойство класса объекта:

*/

static void Example4()
{
    var people = new List<Person>
    {
        new Person("Tom", 37),
        new Person("Sam", 28),
        new Person("Tom", 22),
        new Person("Bob", 41),
    };
    // с помощью оператора orderby
    var sortedPeople1 = from p in people
                    orderby p.Name
                    select p;
    
    foreach (var p in sortedPeople1)
        Console.WriteLine($"{p.Name} - {p.Age}");
    
    // с помощью метода OrderBy
    var sortedPeople2 = people.OrderBy(p => p.Name);
    
    foreach (var p in sortedPeople2)
        Console.WriteLine($"{p.Name} - {p.Age}"); 
}

Example4();


#endregion

#region Сортировка по возрастанию и убыванию

/*

По умолчанию оператор orderby и метод OrderBy производят сортировку по возрастанию. С помощью ключевых слов ascending (сортировка по возрастанию) и descending (сортировка по убыванию) для оператора orderby можно явным образом указать направление сортировки. Например, отсортируем массив чисел по убыванию:

*/

static void Example5()
{
    int[] numbers = { 3, 12, 4, 10 };
    var orderedNumbers = from i in numbers
                        orderby i descending
                        select i;
    foreach (int i in orderedNumbers)
        Console.WriteLine(i);   // 12 10 4 3
}

Example5();

/*
Для сортировки по убыванию можно применять метод OrderByDescending(), который работает аналогично OrderBy за исключением направления сортировки:

*/

static void Example6()
{
    int[] numbers = { 3, 12, 4, 10 };
    var orderedNumbers = numbers.OrderByDescending(n => n);
    foreach (int i in orderedNumbers)
        Console.WriteLine(i);   // 12 10 4 3
}

Example6();


#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, int Age);