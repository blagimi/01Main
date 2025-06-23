/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

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

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
