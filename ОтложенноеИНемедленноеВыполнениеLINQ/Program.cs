﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Отложенное и немедленное выполнение LINQ

/*
Есть два способа выполнения запроса LINQ: отложенное (deferred) и немедленное (immediate) выполнение.

При отложенном выполнении LINQ-выражение не выполняется, пока не будет произведена итерация или перебор по выборке, 
например, в цикле foreach. Обычно подобные операции возвращают объект IEnumerable<T> или IOrderedEnumerable<T>. 
Полный список отложенных операций LINQ:

AsEnumerable

Cast

Concat

DefaultIfEmpty

Distinct

Except

GroupBy

GroupJoin

Intersect

Join

OfType

OrderBy

OrderByDescending

Range

Repeat

Reverse

Select

SelectMany

Skip

SkipWhile

Take

TakeWhile

ThenBy

ThenByDescending

Union

Where

Рассмотрим отложенное выполнение:
*/

static void Example()
{
    string[] people = { "Tom", "Sam", "Bob" };

    var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);

    // выполнение LINQ-запроса
    foreach (string s in selectedPeople)
        Console.WriteLine(s);
}

Example();

/*

То есть фактическое выполнение запроса происходит не в строке определения: var selectedPeople = people.Where..., а при переборе в цикле foreach.

Фактически LINQ-запрос разбивается на три этапа:

Получение источника данных

Создание запроса

Выполнение запроса и получение его результатов

Как это происходит в нашем случае:

Получение источника данных - определение массива teams:

string[] people = { "Tom", "Sam", "Bob" };
Создание запроса - определение переменной selectedTeams:

var selectedPeople = people.Where(s=>s.Length == 3).OrderBy(s=>s);
Выполнение запроса и получение его результатов:

foreach (string s in selectedPeople)
    Console.WriteLine(s);
После определения запроса он может выполняться множество раз. И до выполнения запроса источник данных может изменяться. Чтобы более наглядно увидеть это, мы можем изменить какой-либо элемент до перебора выборки:
*/

static void Example2()
{
    string[] people = { "Tom", "Sam", "Bob" };

    var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);

    people[2] = "Mike";
    // выполнение LINQ-запроса
    foreach (string s in selectedPeople)
        Console.WriteLine(s);
}

Example2();

/*
Теперь выборка будет содержать два элемента, а не три, так как последний элемент после изменения не будет 
соответствовать условию.

Важно понимать, что переменная запроса сама по себе не выполняет никаких действий и не возвращает никаких данных. 
Она только хранит набор команд, которые необходимы для получения результатов. То есть выполнение запроса после его 
создания откладывается. Само получение результатов производится при переборе в цикле foreach.
*/

#endregion

#region Немедленное выполнение запроса

/*
С помощью ряда методов мы можем применить немедленное выполнение запроса. Это методы, которые возвращают 
одно атомарное значение или один элемент или данные типов Array, List и Dictionary. Полный список подобных 
операций в LINQ:

Aggregate

All

Any

Average

Contains

Count

ElementAt

ElementAtOrDefault

Empty

First

FirstOrDefault

Last

LastOrDefault

LongCount

Max

Min

SequenceEqual

Single

SingleOrDefault

Sum

ToArray

ToDictionary

ToList

ToLookup

Рассмотрим пример с методом Count(), который возвращает число элементов последовательности:
*/

static void Example3()
{
    string[] people = { "Tom", "Sam", "Bob" };
    // определение и выполнение LINQ-запроса
    var count = people.Where(s => s.Length == 3).OrderBy(s => s).Count();

    Console.WriteLine(count);   // 3 - до изменения коллекции

    people[2] = "Mike";
    Console.WriteLine(count);   // 3 - после изменения коллекции
}

Example3();
/*
Результатом метода Count будет объект int, поэтому сработает немедленное выполнение.

Сначала создается запрос: people.Where(s=>s.Length == 3).OrderBy(s=>s). Далее к нему применяется метод Count(), 
который выполняет запрос, неявно выполняет перебор по последовательности элементов, генерируемой этим запросом, 
и возвращает число элементов в этой последовательности.

Также мы можем изменить код таким образом, чтобы метод Count() учитывал изменения и выполнялся отдельно от 
определения запроса:
*/

static void Example4()
{
    string[] people = { "Tom", "Sam", "Bob" };
    // определение LINQ-запроса
    var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);
    // выполнение запроса
    Console.WriteLine(selectedPeople.Count());   // 3 - до изменения коллекции

    people[2] = "Mike";
    // выполнение запроса
    Console.WriteLine(selectedPeople.Count());   // 2 - после изменения коллекции

    /*
    Также для немедленного выполнения LINQ-запроса и кэширования его результатов мы можем применять методы 
    преобразования ToArray<T>(), ToList<T>(), ToDictionary() и т.д.. Эти методы получают результат запроса в 
    виде объектов Array, List и Dictionary соответственно. Например:
    */

}

Example4();

static void Example5()
{
    string[] people = { "Tom", "Sam", "Bob" };

    // определение и выполнение LINQ-запроса
    var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s).ToList();

    // изменение массива никак не затронет список selectedPeople
    people[2] = "Mike";

    // выполнение запроса
    foreach (string s in selectedPeople)
        Console.WriteLine(s);
}

Example5();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
