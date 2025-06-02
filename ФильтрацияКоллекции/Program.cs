#region Фильтрация коллекции

/*

Для выбора элементов из некоторого набора по условию используется метод Where:

Where<TSource> (Func<TSource,bool> predicate)

Этот метод принимает делегат Func<TSource,bool>, который в качестве параметра принимает каждый элемент последовательности и возвращает значение bool. Если элемент соответствует некоторому условию, то возвращается true, и тогда этот элемент передаетсяв коллекцию, которая возвращается из метода Where.

Например, выберем все строки, длина которых равна 3:

*/

static void Example()
{
    string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

    var selectedPeople = people.Where(p => p.Length == 3); // "Tom", "Bob", "Sam", "Tim"

    foreach (string person in selectedPeople)
        Console.WriteLine(person);

}

Example();

/*  

Если выражение в методе Where для определенного элемента будет равно true (в данном случае выражение p.Length == 3), то данный элемент попадает в результирующую выборку.

Аналогичный запрос с помощью операторов LINQ:

*/

static void Example2()
{
    string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };
    
    var selectedPeople = from p in people
                        where p.Length == 3
                        select p;
}

Example2();

/*

Другой пример - выберем все четные элементы, которые больше 10.

Фильтрация с помощью операторов LINQ:

*/

static void Example3()
{
    int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
    // методы расширения
    var evens1 = numbers.Where(i => i % 2 == 0 && i > 10);
    // операторы запросов
    var evens2 = from i in numbers
                where i%2==0 && i>10
                select i;
}

Example3();



#endregion



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */