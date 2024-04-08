PrintNullable(5);       // 5
PrintNullable(null);    // параметр равен null

/*
 * Если мы попробуем получить через свойство Value значение переменной, которая равна null, то мы столкнемся с ошибкой:
 */
int? number = null;
//Console.WriteLine(number.Value);    // ! Ошибка 
Console.WriteLine(number);          // Ошибки нет - просто ничего не выведет
int? number2 = null; // если значения нет, метод возвращает значение по умолчанию
Console.WriteLine(number2.GetValueOrDefault());      // 0  - значение по умолчанию для числовых типов
Console.WriteLine(number2.GetValueOrDefault(10));    // 10

/*
 * Также структура Nullable<T> имеет метод GetValueOrDefault(). Он возвращает значение переменной/параметра, если они не равны null. 
 * Если они равны null, то возвращается значение по умолчанию. Значение по умолчанию можно передать в метод. Если в метод не передается 
 * данных, то возвращается значение по умолчанию для данного типа данных (например, для числовых данных это число 0).
 */
number2 = 15;    // если значение задано, оно возвращается методом
Console.WriteLine(number2.GetValueOrDefault());    // 15
Console.WriteLine(number2.GetValueOrDefault(10));  // 15
void PrintNullable(int? number)
{
    if (number.HasValue)
    {
        Console.WriteLine(number.Value);
        // аналогично
        Console.WriteLine(number);
    }
    else
    {
        Console.WriteLine("параметр равен null");
    }
}