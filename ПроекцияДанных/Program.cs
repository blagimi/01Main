/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Проекция данных

/*

Проекция позволяет преобразовать объект одного типа в объект другого типа. Для проекции используется оператор 
select. Допустим, у нас есть набор объектов следующего класса, представляющего пользователя:

record class Person(string Name, int Age);

Но, допустим, нам нужен не весь объект, а только его свойство Name:
*/

static void Example()
{
    var people = new List<Person>
    {
        new Person ("Tom", 23),
        new Person ("Bob", 27),
        new Person ("Sam", 29),
        new Person ("Alice", 24)
    };
    
    var names = from p in people select p.Name;
    
    foreach (string n in names)
        Console.WriteLine(n);
}

Example();

/*     
Результат выражения LINQ будет представлять набор строк, поскольку выражение select p.Name выбирает в 
результирующую выборку только значения свойства Name.

Tom
Bob
Sam
Alice
В качестве альтернативы мы могли бы использовать метод расширения Select():

Select(Func<TSource,TResult> selector)
Этот метод принимает функцию преобразования в виде делегата Func<TSource,TResult>. Функция преобразования 
получает каждый объект выборки типа TSource и с его помощью создает объект TResult. Метод Select возвращает 
коллекцию преобразованных объектов.

Перепишем предыдущий пример с применением метода Select:
*/

static void Example2()
{
    var people = new List<Person>
    {
        new Person ("Tom", 23),
        new Person ("Bob", 27),
        new Person ("Sam", 29),
        new Person ("Alice", 24)
    };
    var names = people.Select(u => u.Name);
    
    foreach (string n in names)
        Console.WriteLine(n);
    }

Example2();

/*     
Аналогично можно создать объекты другого типа, в том числе анонимного:

*/

static void Example3()
{
    var people = new List<Person>
    {
        new Person ("Tom", 23),
        new Person ("Bob", 27)
    };
    
    var personel = from p in people
                select new
                {
                    FirstName = p.Name,
                    Year = DateTime.Now.Year - p.Age
                };
    
    foreach (var p in personel)
        Console.WriteLine($"{p.FirstName} - {p.Year}");
}

Example3();
/* 
Здесь оператор select создает объект анонимного типа, используя текущий объект Person. И теперь результат 
будет содержать набор объектов данного анонимного типа, в котором определены два свойства: FirstName и 
Year (год рождения). Консольный вывод программы:

Tom - 1999
Bob - 1995
В качестве альтернативы мы могли бы использовать метод расширения Select():

// проекция на объекты анонимного типа
var personel = people.Select(p => new
{ 
    FirstName = p.Name, 
    Year = DateTime.Now.Year - p.Age 
});

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, int Age);