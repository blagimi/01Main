
#region Методы Skip и Take

/*
Ряд методов в LINQ позволяют получить часть коллекции, в частности, такие методы как Skip, Take, SkipWhile, 
TakeWhile.
*/

#endregion

#region Skip

/*
Метод Skip() пропускает определенное количество элементов. Количество пропускаемых элементов передается 
в качестве параметра в метод:
*/

static void Example()
{
    string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
    // пропускаем первые два элемента
    var result = people.Skip(2);    // "Bob", "Mike", "Kate"

    foreach (var person in result)
        Console.WriteLine(person);
}

Example();

/*
В данном случае пропускаем первые два элемента. Консольный вывод:

Bob
Mike
Kate
Если необходимо пропустить определенное количество элементов с конца коллекции, то 
применяется метод SkipLast():
*/

static void Example2()
{
    string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
    // пропускаем последние два элемента

    var result = people.SkipLast(2);    // "Tom", "Sam", "Bob"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example2();
/*    
В данном случае пропускаем последние два элемента. Консольный вывод:

Tom
Sam
Bob

*/

#endregion

#region SkipWhile

/*
Метод SkipWhile() пропускает цепочку элементов, начиная с первого элемента, пока они удовлетворяют 
определенному условию:


SkipWhile(Func<TSource, bool> predicate);
В метод передается делегат, который представляет условие, он получает каждый элемент коллекции и возвращает 
значение true, если элемент соответствует условию. Например:

*/

static void Example3()
{
    string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
    // пропускаем первые элементы, длина которых равна 3
    var result = people.SkipWhile(p=> p.Length == 3);    // "Mike", "Kate", "Bob"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example3();

/*
Здесь метод SkipWhile пропускает элементы, длина которых равна 3 символам. Первые два элемента массива 
people ("Tom", "Sam") соответствуют этому условию и поэтому будут пропущены. На третьем элементе 
("Mike") цепочка обрывается, поэтому последний элемент ("Bob"), длина которго тоже равна 3-м символам, 
не будет пропущен и будет включен в выходную коллекцию:

Mike
Kate
Bob
Если в массиве первый элемент имел бы длину больше или меньше 3 символов, то цепочка пропускаемых
элементов прервалась бы уже на первом элементе, и поэтому метод SkipWhile возвратил бы все элементы массива.
*/

#endregion

#region Take

/*
Метод Take() извлекает определенное число элементов. Количество извлекаемых элементов передается в 
метод в качестве параметра. Например, извлечем три первых элемента:

*/

static void Example4()
{
    string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
    // извлекаем первые 3 элемента
    var result = people.Take(3);    // "Tom", "Sam", "Mike"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example4();

/*
Метод TakeLast() извлекает определенное количество элементов с конце коллекции:
*/

static void Example5()
{
    string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
    // извлекаем последние 3 элемента
    var result = people.TakeLast(3);    // "Mike", "Kate", "Bob"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example5();

#endregion

#region TakeWhile

/*
Метод TakeWhile() выбирает цепочку элементов, начиная с первого элемента, пока они удовлетворяют 
определенному условию:

TakeWhile(Func<TSource, bool> predicate);
В метод передается делегат, который представляет условие, он получает каждый элемент коллекции и 
возвращает значение true, если элемент соответствует условию. Например:
*/

static void Example6()
{
    string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
    // извлекаем первые элементы, длина которых равна 3
    var result = people.TakeWhile(p=> p.Length == 3);    // "Tom", "Sam"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example6();

/*
Здесь метод TakeWhile выбирает элементы, длина которых равна 3 символам. Первые два элемента массива 
people ("Tom", "Sam") соответствуют этому условию и поэтому будут выбраны в выходную коллекцию. На 
третьем элементе ("Mike") цепочка обрывается, поэтому последний элемент ("Bob"), длина которго тоже 
равна 3-м символам, не будет включен в выходную коллекцию:

Tom
Sam
Если бы первый элемент в массиве имел бы длину больше или меньше 3 символов, то в этом случае метод 
TakeWhile возвратил бы нам 0 элементов.
*/

#endregion

#region Постраничный вывод

/*
Совмещая оба метода - Take и Skip, мы можем выбрать определенное количество элементов начиная с 
определенного элемента. Например, выберем два элемента, начиная со четвертого (то есть пропустим 
3 первых элемента):
*/

static void Example7()
{
    string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob", "Alice" };
    // пропускаем 3 элемента и выбираем 2 элемента
    var result = people.Skip(3).Take(2);    // "Kate", "Bob"
    
    foreach (var person in result)
        Console.WriteLine(person);
}

Example7();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
