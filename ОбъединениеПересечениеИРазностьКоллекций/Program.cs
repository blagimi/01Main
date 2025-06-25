﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

LINQ предоставляет несколько методов для работы с коллекциями как с множествами, а именно находить их 
разность, объединение и пересечение.

*/

#region Разность последовательностей

/*
С помощью метода Except() можно получить разность двух последовательностей:
*/

static void Example()
{
    string[] soft = { "Microsoft", "Google", "Apple" };
    string[] hard = { "Apple", "IBM", "Samsung" };

    // разность последовательностей
    var result = soft.Except(hard);

    foreach (string s in result)
        Console.WriteLine(s);
}

Example();

/*
В данном случае из массива soft убираются все элементы, которые есть в массиве hard. Результатом операции будут два элемента:

Microsoft
Google

*/

#endregion

#region Пересечение последовательностей

/*
Для получения пересечения последовательностей, то есть общих для обоих наборов элементов, применяется метод 
Intersect:

*/

static void Example2()
{
    string[] soft = { "Microsoft", "Google", "Apple"};
    string[] hard = { "Apple", "IBM", "Samsung"};
    
    // пересечение последовательностей
    var result = soft.Intersect(hard);
    
    foreach (string s in result)
        Console.WriteLine(s);
}

Example2();

/*

Так как оба набора имеют только один общий элемент, то соответственно только он и попадет в результирующую выборку:

Apple

*/

#endregion

#region Удаление дубликатов

/*
Для удаления дублей в наборе используется метод Distinct:

*/

static void Example3()
{
    string[] soft = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };
 
// удаление дублей
var result = soft.Distinct();
 
foreach (string s in result)
    Console.WriteLine(s);

}

Example3();

/*    
Microsoft
Google
Apple
*/

#endregion

#region Объединение последовательностей

/*
Для объединения двух последовательностей используется метод Union. Его результатом является новый набор, 
в котором имеются элементы, как из первой, так и из второй последовательности. Повторяющиеся элементы 
добавляются в результат только один раз:

*/

static void Example4()
{
    string[] soft = { "Microsoft", "Google", "Apple"};
    string[] hard = { "Apple", "IBM", "Samsung"};
    
    // объединение последовательностей
    var result = soft.Union(hard);
    
    foreach (string s in result)
        Console.WriteLine(s);
}

Example4();

/*
Результатом операции будет следующий набор:

Microsoft
Google
Apple
IBM
Samsung
Если же нам нужно простое объединение двух наборов, то мы можем использовать метод Concat:

var result = soft.Concat(hard);
В этом случае те элементы, которые встречаются в обоих наборах, дублируются в резутирующей 
последовательности.

Последовательное применение методов Concat и Distinct будет подобно действию метода Union.
*/

#endregion

#region Работа со сложными объектами

/*

Для сравнения объектов в последовательностях применяются реализации методов GetHeshCode() и Equals(). 
Поэтому если мы хотим работать с последовательностями, которые содержат объекты своих классов и структур, 
то нам необходимо определить для них подобные методы:

*/

static void Example5()
{
    Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
    Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };
    
    // объединение последовательностей
    var people = students.Union(employees);
    
    foreach (Person person in people)
        Console.WriteLine(person.Name);
}

Example5();

/*

Здесь объекты Person сравниваются исходя из значения их свойства Name - если имена равны, то и объекты 
Person равны. Консольный вывод:

Tom
Bob
Sam
Mike


*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

class Person
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    public override bool Equals(object? obj)
    {
        if (obj is Person person) return Name == person.Name;
        return false;
    }
    public override int GetHashCode() => Name.GetHashCode();
}