
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


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
