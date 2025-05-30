﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Основы LINQ

/*

LINQ (Language-Integrated Query) представляет простой и удобный язык запросов к источнику данных. В качестве 
источника данных может выступать объект, реализующий интерфейс IEnumerable 
(например, стандартные коллекции, массивы), набор данных DataSet, документ XML. Но вне зависимости от типа 
источника LINQ позволяет применить ко всем один и тот же подход для выборки данных.

Существует несколько разновидностей LINQ:

LINQ to Objects: применяется для работы с массивами и коллекциями

LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework

LINQ to XML: применяется при работе с файлами XML

LINQ to DataSet: применяется при работе с объектом DataSet

Parallel LINQ (PLINQ): используется для выполнения параллельных запросов

В этой главе речь пойдет прежде всего о LINQ to Objects, но в последующих материалах также будут затронуты 
и другие разновидности LINQ. Основная часть функциональности LINQ сосредоточена в пространстве имен 
System.LINQ. В проектах под .NET 6 данное пространство имен подключается по умолчанию.

В чем же удобство LINQ? Посмотрим на простейшем примере. Выберем из массива строки, которые начинаются 
на определенную букву, например, букву "T", и отсортируем полученный список:

*/

static void Example()
{
    string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
    
    // создаем новый список для результатов
    var selectedPeople = new List<string>();
    // проходим по массиву
    foreach (string person in people)
    {
        // если строка начинается на букву T, добавляем в список
        if (person.ToUpper().StartsWith("T"))
            selectedPeople.Add(person);
    }
    // сортируем список
    selectedPeople.Sort();
    
    foreach (string person in selectedPeople)
        Console.WriteLine(person);
}

Example();

/*

Для отфильтрованных строк создается специальный список. Затем в цикле проходим по всем элементам 
массива и, если они соответствуют условию (начинаются на букву T), то добавляем их в этот список. 
Затем сортируем список по возрастанию. И в конце элементы полученного списка выводим на консоль:

Tim
Tom
Tomas
Хотя подобный подход вполне работает, однако LINQ позволяет значительно сократить код с помощью 
интуитивно понятного и краткого синтаксиса.

Для работы с колекциями можно использовать два способа:

Операторы запросов LINQ

Методы расширений LINQ

Рассмотрим оба способа

*/


#endregion


#region Операторы запросов LINQ

/*

Операторы запросов LINQ в каком-то роде частично напоминают синтаксис запросов SQL, поэтому если вы работали 
когда-нибудь с sql-запросами, то будет проще понять общую концепцию. Итак, изменим предыдущий пример, 
применив операторы запросов LINQ:
*/

static void Example2()
{
    string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
    
    // создаем новый список для результатов
    var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                        where p.ToUpper().StartsWith("T") //фильтрация по критерию
                        orderby p  // упорядочиваем по возрастанию
                        select p; // выбираем объект в создаваемую коллекцию
    
    foreach (string person in selectedPeople)
        Console.WriteLine(person);
}

Example2();

/*    
Прежде всего, как мы видим, код стал меньше и проще, а результат будет тем же. В принципе все выражение 
можно было бы записать в одну строку:

var selectedPeople = from p in people where p.ToUpper().StartsWith("T") orderby p  select p;
Но для более понятной логической разбивки я поместил каждое отдельное подвыражение на отдельной строке.

Простейшее определение запроса LINQ выглядит следующим образом:

from переменная in набор_объектов
select переменная;
Итак, что делает этот запрос LINQ? Выражение from p in people проходит по всем элементам массива people и 
определяет каждый элемент как p. Используя переменную p мы можем проводить над ней разные операции.

Несмотря на то, что мы не указываем тип переменной p, выражения LINQ являются строго типизированными. 
То есть среда автоматически распознает, что набор people состоит из объектов string, поэтому переменная p 
будет рассматриваться в качестве строки.

Далее с помощью оператора where проводится фильтрация объектов, и если объект соответствует критерию 
(в данном случае начальная буква должна быть "T"), то этот объект передается дальше.

Оператор orderby упорядочивает по возрастанию, то есть сортирует выбранные объекты.

Оператор select передает выбранные значения в результирующую выборку, которая возвращается LINQ-выражением.

В данном случае результатом выражения LINQ является объект IEnumerable<T>. Нередко результирующая выборка 
определяется с помощью ключевого слова var, тогда компилятор на этапе компиляции сам выводит тип.

*/

#endregion


#region Методы расширения LINQ

/*

Кроме стандартного синтаксиса from .. in .. select для создания запроса LINQ мы можем применять 
специальные методы расширения, которые определены для интерфейса IEnumerable. Как правило, эти 
методы реализуют ту же функциональность, что и операторы LINQ типа where или orderby.

Например:

*/

static void Example3()
{
    string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };
    
    var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
    
    foreach (string person in selectedPeople)
        Console.WriteLine(person);
}

Example3();

/*
Запрос people.Where(p=>p.ToUpper().StartsWith("T")).OrderBy(p => p) будет аналогичен предыдущему. 
Он состоит из цепочки методов Where и OrderBy. В качестве аргумента эти методы принимают делегат 
или лямбда-выражение.

И хотя ряд действий мы можем реализовать как с помощью операторов запросов LINQ, так и с помощью 
методов расширений LINQ, но не каждый метод расширения имеет аналог среди операторов LINQ. И в 
этом случае можно сочетать оба подхода. Например, используем стандартный синтаксис linq и метод 
расширения Count(), который возвращает количество элементов в выборке:

int number = (from p in people where p.ToUpper().StartsWith("T") select p).Count();
Console.WriteLine(number); // 3
Список используемых методов расширения LINQ
Select: определяет проекцию выбранных значений

Where: определяет фильтр выборки

OrderBy: упорядочивает элементы по возрастанию

OrderByDescending: упорядочивает элементы по убыванию

ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию

Join: соединяет две коллекции по определенному признаку

Aggregate: применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту

GroupBy: группирует элементы по ключу

ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь

GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу

Reverse: располагает элементы в обратном порядке

All: определяет, все ли элементы коллекции удовлятворяют определенному условию

Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию

Contains: определяет, содержит ли коллекция определенный элемент

Distinct: удаляет дублирующиеся элементы из коллекции

Except: возвращает разность двух коллекцию, то есть те элементы, которые создаются только в одной коллекции

Union: объединяет две однородные коллекции

Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях

Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию

Sum: подсчитывает сумму числовых значений в коллекции

Average: подсчитывает cреднее значение числовых значений в коллекции

Min: находит минимальное значение

Max: находит максимальное значение

Take: выбирает определенное количество элементов

Skip: пропускает определенное количество элементов

TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно

SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем 
возвращает оставшиеся элементы

Concat: объединяет две коллекции

Zip: объединяет две коллекции в соответствии с определенным условием

First: выбирает первый элемент коллекции

FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию

Single: выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, 
то генерируется исключение

SingleOrDefault: выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по 
умолчанию. Если в коллекции больше одного элемента, генерирует исключение

ElementAt: выбирает элемент последовательности по определенному индексу

ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, 
если индекс вне допустимого диапазона

Last: выбирает последний элемент коллекции

LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */