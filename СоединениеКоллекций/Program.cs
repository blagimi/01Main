﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Соединение коллекций
Соединение в LINQ используется для объединения двух разнотипных наборов в один. Для соединения используется
оператор join или метод Join(). Как правило, данная операция применяется к двум наборам, которые имеют 
один общий критерий.

*/

#region Оператор join

/*
Оператор join имеет следующий формальный синтаксис:

from объект1 in набор1
join объект2 in набор2 on объект2.свойство2 equals объект1.свойство1
После оператора join идет выборка объектов из второй коллекции. После оператора on указывается 
критерий соединения - свойство объекта из второй выборки, а после оператора equals - свойство 
объекта из первой выборки, которому должно быть равно свойство объекта из второй выборки. Если 
эти свойства равны, то оба объекта попадают в финальный результат.

Например, у нас есть два класса:

Класс Person представляет пользователя и хранит два свойства: Name (имя) и Company (компания пользователя). 
Класс Company представляет компанию и хранит два свойства: Title (название компании) и Language 
(основной язык программирования в компании)

Объекты обоих классов будет иметь один общий критерий - название компании. Соединим по этому критерию 
два набора этих классов:
*/

static void Example()
{
    Person[] people =
    {
        new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
        new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    };
    Company[] companies =
    {
        new Company("Microsoft", "C#"),
        new Company("Google", "Go"),
        new Company("Oracle", "Java")
    };
    var employees = from p in people
                    join c in companies on p.Company equals c.Title
                    select new { Name = p.Name, Company = c.Title, Language = c.Language };

    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");
}

Example();

/*
С помощью выражения

join c in companies on p.Company equals c.Title
объект p из списка people (то есть объект Person) соединяется с объектом c из списка companies (то есть с объектом Company), если значение свойства p.Company совпадает со значением свойства c.Title. Результатом соединения будет объект анонимного типа, который будет содержать три свойства. В итоге мы получим следующий вывод:

Tom - Microsoft (C#)
Sam - Google (Go)
Mike - Microsoft (C#)
Обратите внимание, что в массиве people есть объект new Person("Bob", "JetBrains"), но в массиве компаний компании с именем "JetBrains" нет, соответственно он не попал с результат. Аналогично в списке people нет объектов Person, которые бы соотствовали компании new Company("Oracle", "Java").
*/

#endregion

#region Метод Join

/*
В качестве альтернативы можно было бы использовать метод Join():

Join(IEnumerable<TInner> inner, 
    Func<TOuter,TKey> outerKeySelector, 
    Func<TInner,TKey> innerKeySelector, 
    Func<TOuter,TInner,TResult> resultSelector);
Метод Join() принимает четыре параметра:

второй список, который соединяем с текущим

делегат, который определяет свойство объекта из текущего списка, по которому идет соединение

делегат, который определяет свойство объекта из второго списка, по которому идет соединение

делегат, который определяет новый объект в результате соединения

Перепишим предыдущий пример с использованием метода Join:

*/

static void Example2()

{
    Person[] people =
    {
        new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
        new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    };
    Company[] companies =
    {
        new Company("Microsoft", "C#"),
        new Company("Google", "Go"),
        new Company("Oracle", "Java")
    };
    var employees = people.Join(companies, // второй набор
                p => p.Company, // свойство-селектор объекта из первого набора
                c => c.Title, // свойство-селектор объекта из второго набора
                (p, c) => new { Name = p.Name, Company = c.Title, Language = c.Language }); // результат
    
    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");
}

Example2();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, string Company);
record class Company(string Title, string Language);