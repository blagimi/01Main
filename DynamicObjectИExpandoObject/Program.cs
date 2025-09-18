#region DynamicObject и ExpandoObject

/*

Интересные возможности при разработке в C# и .NET с использованием DLR предоставляет пространство имен 
System.Dynamic и в частности класс ExpandoObject. Он позволяет создавать динамические объекты, наподобие 
тех, что используются в javascript:

*/

// определяем объект, который будет хранять ряд значений
dynamic person = new System.Dynamic.ExpandoObject();
person.Name = "Tom";
person.Age = 46;
person.Languages = new List<string> { "english", "german", "french" };
 
Console.WriteLine($"{person.Name} - {person.Age}");
foreach (var lang in person.Languages)
    Console.WriteLine(lang);
 
// объявляем метод
person.IncrementAge = (Action<int>)(x => person.Age += x);
person.IncrementAge(6); // увеличиваем возраст на 6 лет
Console.WriteLine($"{person.Name} - {person.Age}");

/*

Консольный вывод:

Tom - 46
english
german
french
Tom - 52
У динамического объекта ExpandoObject можно объявить любые свойства, например, Name, Age, Languages, 
которые могут представлять самые различные объекты. Кроме того, можно задать методы с помощью делегатов.

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
