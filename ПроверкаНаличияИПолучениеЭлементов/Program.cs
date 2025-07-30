using System.Diagnostics.CodeAnalysis;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Ряд методов в LINQ позволяют проверить наличие элементов в коллекции и получить их.

*/

#region All

/*

Метод All() проверяет, соответствуют ли все элементы условию. Если все элементы соответствуют условию, 
то возвращается true. Например:
*/

static void Example()
{
    string[] people = { "Tom", "Tim", "Bob", "Sam" };

    // проверяем, все ли элементы имеют длину в 3 символа
    bool allHas3Chars = people.All(s => s.Length == 3);     // true
    Console.WriteLine(allHas3Chars);

    // проверяем, все ли строки начинаются на T
    bool allStartsWithT = people.All(s => s.StartsWith("T"));   // false
    Console.WriteLine(allStartsWithT);
}

Example();

/*
В первом случае проверяем, все ли строки в массиве people имеют длину в три символа. Поскольку 
это условие верно, то метод All возвращает true. Во втором случае смотрим, все ли строки начинаются 
с буквы "T". это условие ложно, поэтому метод All возвращает false.

*/

#endregion

#region Any

/*
Метод Any() действует подобным образом, только возвращает true, если хотя бы один элемент коллекции 
определенному условию:
*/

static void Example2()
{
    string[] people = { "Tom", "Tim", "Bob", "Sam" };
    
    // проверяем, все ли элементы имеют длину больше 3 символов
    bool allHasMore3Chars = people.Any(s => s.Length > 3);     // false
    Console.WriteLine(allHasMore3Chars);
    
    // проверяем, все ли строки начинаются на T
    bool allStartsWithT = people.Any(s => s.StartsWith("T"));   // true
    Console.WriteLine(allStartsWithT);
}

Example2();
/*
Первое выражение вернет false, поскольку все строки имеют длину в 3 символа. Второе выражение возвратит 
true, так как у нас есть в коллекции есть строки, которые начинаются на букву T.
*/

#endregion

#region Contains

/*
Метод Contains() возвращает true, если коллекция содержит определенный элемент.
*/

static void Example3()
{
    string[] people = { "Tom", "Tim", "Bob", "Sam" };

    // проверяем, есть ли строка Tom
    bool hasTom = people.Contains("Tom");     // true
    Console.WriteLine(hasTom);

    // проверяем, есть ли строка Mike
    bool hasMike = people.Contains("Mike");     // false
    Console.WriteLine(hasMike);
}

Example3();

/*
Стоит отметить, что для сравнения объектов применяется реализация метода Equals. Соответственно если мы 
работаем с объектами своих типов, то мы можем реализовать данный метод:
*/

static void Example4()
{
    Person[] people = { new Person("Tom"), new Person("Sam"), new Person("Bob") };

    var tom = new Person("Tom");
    var mike = new Person("Mike");

    // проверяем, есть ли Tom
    bool hasTom = people.Contains(tom);     // true
    Console.WriteLine(hasTom);

    // проверяем, есть ли строка Mike
    bool hasMike = people.Contains(mike);     // false
    Console.WriteLine(hasMike);
}

Example4();

/*
Но стоит отметить, что Contains не всегда может вернуть ожидаемые данные. Например:
*/

static void Example5()
{
    string[] people = { "tom", "Tim", "bOb", "Sam" };

    // проверяем, есть ли строка Tom
    bool hasTom = people.Contains("Tom");     // false
    Console.WriteLine(hasTom);

    // проверяем, есть ли строка Bob
    bool hasMike = people.Contains("Bob");     // false
    Console.WriteLine(hasMike);
}

Example5();

/*
В данном случае в массиве нет строки "Tom", а есть строка "tom". Поэтому вызов people.Contains("Tom") 
возвратит false. Но подобное поведение не всегда может быть желательным. И в этом случае мы можем задать 
логику сравнения с помощью реализации интерфейса IComparer и затем передать ее в качестве второго параметра
в метод Contains:
*/


static void Example6()
{
    string[] people = { "tom", "Tim", "bOb", "Sam" };

    // проверяем, есть ли строка Tom
    bool hasTom = people.Contains("Tom", new CustomStringComparer());     // true
    Console.WriteLine(hasTom);

    // проверяем, есть ли строка Bob
    bool hasMike = people.Contains("Bob", new CustomStringComparer());     // true
    Console.WriteLine(hasMike);
}

Example6();

/*
Интерфейс IEqualityComparer типизируется типом сравниваемых данных (в данном случае типом String). 
Для реализации этого интерфейса необходимо определить методы Equals и GetHashCode. В методе Equals 
сравниваем строки в нижнем регистре, а в методе GetHashCode возвращаем возвращаем хеш-код строки в 
нижнем регистре.
*/

#endregion

#region First/FirstOrdefault

/*
Метод First() возвращает первый элемент последовательности:
*/

static void Example7()
{
    string[] people = { "Tom", "Bob", "Tim", "Sam" };

    // проверяем, есть ли строка Tom
    var first = people.First();  // Tom
    Console.WriteLine(first);
}

Example7();

/*
Также в метод First можно передать метод, который представляет условие. В этом случае метод возвращает первый элемент, который соответствует условию:
*/

static void Example8()
{
    string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

    // первая строка, длина которой равна 4 символам
    var firstWith4Chars = people.First(s => s.Length == 4);  // Kate
    Console.WriteLine(firstWith4Chars);
}

Example8();

/*
Здесь выбираем первый элемент, длина которого - 4 символа.

Стоит учитывать, что если коллекция пуста или в коллекции нет элементов, который соответствуют условию, 
то будет сгенерировано исключение.
*/

static void Example9()
{
    string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

    // первая строка, длина которой равна 5 символам
    var firstWith5Chars = people.First(s => s.Length == 5);  // ! исключение
    Console.WriteLine(firstWith5Chars);

    var first = new string[] { }.First();  // ! исключение
    Console.WriteLine(first);
}

Example9();

#endregion

#region Last и LastOrDefault

/*
Метод Last() аналогичен по работе методу First, только возвращает последний элемент. Если коллекция не 
содержит элемент, который соответствуют условию, или вообще пуста, то метод генерирует исключение.
*/

static void Example10()
{
    string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

    string last = people.Last();
    Console.WriteLine(last); // Sam

    string lastWith4Chars = people.Last(s => s.Length == 4);
    Console.WriteLine(lastWith4Chars); // Mike
}

Example10();

/*
Метод LastOrDefault() возвращает последний элемент или значение по умолчанию, если коллекция не 
содержит элемент, который соответствуют условию, или вообще пуста:
*/

static void Example11()
{
    string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

    string? last = people.LastOrDefault();
    Console.WriteLine(last); // Sam

    string? lastWith4Chars = people.LastOrDefault(s => s.Length == 4);
    Console.WriteLine(lastWith4Chars); // Mike

    string? lastWith5Chars = people.LastOrDefault(s => s.Length == 5);
    Console.WriteLine(lastWith5Chars); // null

    string? lastWith5CharsOrDefault = people.LastOrDefault(s => s.Length == 5, "Undefined");
    Console.WriteLine(lastWith5CharsOrDefault); // Undefined

    // первый элемент из пустой коллекции строк
    string? lastOrDefault = new string[] { }.LastOrDefault("hello");
    Console.WriteLine(lastOrDefault);  // hello
}

Example11();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;

    public override bool Equals(object? obj)
    {
        if (obj is Person person) return Name == person.Name;
        return false;
    }
    public override int GetHashCode() => Name.GetHashCode();
}

class CustomStringComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        if (x is null || y is null) return false;
        return x.ToLower() == y.ToLower();

    }

    public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
}
