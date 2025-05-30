﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

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

#region Переменые в запросах и оператор let

/*

Иногда возникает необходимость произвести в запросах LINQ какие-то дополнительные промежуточные вычисления. 
Для этих целей мы можем задать в запросах свои переменные с помощью оператора let:

*/

static void Example4()
{
    var people = new List<Person>
    {
        new Person ("Tom", 23),
        new Person ("Bob", 27)
    };
    
    var personnel = from p in people
                let name = $"Mr. {p.Name}"
                let year = DateTime.Now.Year - p.Age
                select new
                {
                    Name = name,
                    Year = year
                };
    
    foreach (var p in personnel)
        Console.WriteLine($"{p.Name} - {p.Year}");   
}

Example4();

/*
В данном случае создаются две переменных. Переменная name, значение которой равно $"Mr. {p.Name}".

Возможность определения переменных наверное одно из главных преимуществ операторов LINQ по сравнению с 
методами расширения.

*/

#endregion

#region Выборка из нескольких источников

/*

В LINQ можно выбирать объекты не только из одного, но и из большего количества источников. 
Например, возьмем классы:

record class Course(string Title);  // учебный курс
record class Student(string Name);  // студент
Класс Course представляет учебный курс и хранит его название. Класс Student представляет 
студента и хранит его имя.

Допустим, нам надо из списка курсов и списка студентов получить набор пар студент-курс 
(условно говоря сущность, которая представляет учебу студента на данном курсе):

*/
static void Example5()
{
    var courses = new List<Course> { new Course("C#"), new Course("Java") };
    var students = new List<Student> { new Student("Tom"), new Student("Bob") };
    
    var enrollments = from course in courses    //  выбираем по одному курсу
                from student in students       //  выбираем по одному студенту
                select new { Student = student.Name, Course = course.Title};   // соединяем каждого студента с каждым курсом
    
    foreach (var enrollment in enrollments)
        Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");

    }
Example5();

/*
Консольный вывод:

Tom - C#
Bob - C#
Tom - Java
Bob - Java
Таким образом, при выборке из двух источников каждый элемент из первого источника будет 
сопоставляться с каждым элементом из второго источника. То есть получиться 4 пары.

*/

#endregion

#region SelectMany и сведение объектов

/*

Метод SelectMany позволяет свести набор коллекций в одну коллекцию. Он имеет ряд перегруженных версий. Возьмем 
одну из них:

SelectMany(Func<TSource, IEnumerable<TResult>> selector);
SelectMany(Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource,TCollection,TResult> resultSelector);
Первая версия метода принимает функцию преобразования в виде делегата Func<TSource,IEnumerable<TResult>>. 
Функция преобразования получает каждый объект выборки типа TSource и с его помощью создает набор объектов 
TResult. Метод SelectMany возвращает коллекцию преобразованных объектов.

Вторая версия принимает функцию преобразования в виде делегата Func<TSource,IEnumerable<TResult>>. 
Функция преобразования получает каждый объект выборки типа TSource и возвращает некоторую промежуточную 
коллекцию типа TCollection. Второй параметр - то же функция функция преобразования в виде делегата 
Func<TSource,TCollection,TResult>, которая получает два параметра - каждый элемент текущей выборки и каждый
элемент промежуточной коллекции и на их основе создает некоторый объект типа TResult.

Рассмотрим следующий пример:

*/

static void Example6()
{
        var companies = new List<Company>
    {
        new Company("Microsoft", new List<Person2> {new Person2("Tom"), new Person2("Bob")}),
        new Company("Google", new List<Person2> {new Person2("Sam"), new Person2("Mike")}),
    };
    var employees = companies.SelectMany(c => c.Staff);
    
    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name}");

}

Example6();
/*
Здесь нам дан список компаний, в каждой компании имеет набор сотрудников в виде списка объектов Person.
И на выходе мы получаем список сотрудников всех компаний, то есть по сути коллекцию объектов Person. 
Консольный вывод:

Tom
Bob
Sam
Mike
Аналогичный пример с помощью операторов LINQ:
*/

static void Example7()
{
    var companies = new List<Company>
    {
        new Company("Microsoft", new List<Person2> {new Person2("Tom"), new Person2("Bob")}),
        new Company("Google", new List<Person2> {new Person2("Sam"), new Person2("Mike")}),
    };
    var employees = from c in companies
                    from emp in c.Staff
                    select emp;
    
    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name}");

}

Example7();

/*

Теперь добавим к сотрудникам их компанию:

*/

static void Example8()
{
    var companies = new List<Company>
    {
        new Company("Microsoft", new List<Person2> {new Person2("Tom"), new Person2("Bob")}),
        new Company("Google", new List<Person2> {new Person2("Sam"), new Person2("Mike")}),
    };
    
    var employees = companies.SelectMany(c => c.Staff,
                                        (c, emp)=> new { Name = emp.Name, Company = c.Name });
    
    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name} - {emp.Company}");

}

Example8();

/*
Здесь применяется другая версия метода SelectMany. Первый делегат в виде c => c.Staff создает промежуточную коллекцию - фактически просто возвращаем набор сотрудников каждой компании. Второй делегат - (c, emp)=> new { Name = emp.Name, Company = c.Name } получает каждую компанию и каждый элемент промежуточной коллекции - объект Person и на их основе создает анонимный объект с двумя свойствами Name и Company. Консольный вывод программы:

Tom - Microsoft
Bob - Microsoft
Sam - Google
Mike - Google
Аналогичный пример с помощью операторов запросов:

*/

static void Example9()
{
    var companies = new List<Company>
    {
        new Company("Microsoft", new List<Person2> {new Person2("Tom"), new Person2("Bob")}),
        new Company("Google", new List<Person2> {new Person2("Sam"), new Person2("Mike")}),
    };
    var employees = from c in companies
                from emp in c.Staff
                select new { Name = emp.Name, Company = c.Name };
    
    foreach (var emp in employees)
        Console.WriteLine($"{emp.Name} - {emp.Company}");
    
}

Example9();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, int Age);
record class Course(string Title);  // учебный курс
record class Student(string Name);  // студент

record class Person2(string Name);
record class Company(string Name, List<Person2> Staff);