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

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
