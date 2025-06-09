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

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */