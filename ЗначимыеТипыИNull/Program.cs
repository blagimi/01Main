/*
 * В отличие от ссылочных типов переменным/параметрам значимых типов нельзя напрямую присвоить значение null. 
 * Тем не менее нередко бывает удобно, чтобы переменная/параметр значимого типа могли принимать значение null, 
 * Например, получаем числовое значение из базы данных, которое в бд может отсутствовать. То есть, если значение в базе данных есть - получим число, если нет - то null.
 * Чтобы присвоения переменной или параметру значимого типа значения null, эти переменная/параметр значимого типа должны представлять тип nullable. 
 * Для этого после названия типа указывается знак вопроса ?
 */
int? val = null;
Console.WriteLine(val);
/*
if (val.HasValue)
{
    Console.WriteLine(val.Value) ;
}
else
{
    Console.WriteLine("null");
}
*/
PrintNullable(val);

/* Здесь переменная val представляет не просто тип int, а тип int? - тип, переменные/параметры которого могут принимать как значения типа int, так и значение null. 
 * В данном случае мы передаем ей значение null. Но также можно передать и значение типа int:
 */
IsNull(val);    // null
val = 22;
IsNull(val);    // 22
/*
 * Однако если переменная/параметр представляет значимый не nullable-тип, то присвоить им значение null не получится:
 */
//int val2 = null; //Ошибка

/*
 * Свойства Value и HasValue и метод GetValueOrDefault
 * Структура Nullable<T> имеет 2 свойства:
 * Value - значение объекта
 * HasValue - возвращение true, если объект хранит некоторое значение и false если null
 * Можно использовать эти свойства для проверки наличия и получения значений
 */
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

/* 
 * Преобразования значимых nullable типов
 */

// Явное преобразование от Т? к Т
int? x1 = null;
if (x1.HasValue)        // При наличие значения
{
    int x2 = (int)x1;   // Присвоение его новой переменной, явно преобразовывая в int
    Console.WriteLine(x2);
}
// Неявное преобразование от Т к Т?
int x3 = 4;     //  Значение переменной значимого НЕ nullable типа 
int? x4 = x1;   //  Присваивается переменной nullable типа без преобразования
Console.WriteLine(x4);

// Неявные расширяющие преобразования от V к Т?
int x5 = 4;     // Переменная типа int неявно переносится в тип double
long? x6 = x5;
Console.WriteLine(x6);

// Неявные сужающие переобразования от V к Т?
long x7 = 4;        
long? x8 = (int)x7;

// Явные сужающие преобразования от V? к Т?
long? x9 = 4;
int? x10 = (int?)x9;

//явные сужающие преобразования от V? к T
long? x11 = null;
if (x11.HasValue)
{
    int x12 = (int)x11;
    Console.WriteLine(x12);
}
Console.WriteLine($"{x1},{x3},{x4},{x5},{x6},{x7},{x8},{x9},{x10},{x11}");

/*
 * Операции с nullable-типами
 * nullable-типы поддерживают тот же набор операций, что и их не-nullable двойники. 
 * Но следует учитывать, что если в операции участвует nullable-тип, то результатом также будет значение nullable-типа
 */
int? x = 5;
//int z = x + 7;        //  Ошибка
int z = (int)x + 7;     //  После явного преобразования возможно
Console.WriteLine(z);   //  12
int? w = x + 7;         //  Можно если переменная так же является nullable
Console.WriteLine(w);   //  12
int d = x.Value + 7;    //  Можно
Console.WriteLine(d);   //  12
/*
 * В арифметических операциях, если один из операндов равен null, то результатом операции также будет null:
 */
int? j = null;
int? p = j + 7;
Console.WriteLine(p);   // Null
PrintNullable(p);       // Null

/*
 * В операциях сравнения >, <, >= и <=, если хотя бы один из операндов равен null, 
 * то возвращается false (кроме операции !=):
 */
int? f = null;
int? g = 5;
int? h = null;
Console.WriteLine($"x > y is {f > g}");     // false
Console.WriteLine($"x < y is {f < g}");     // false 
Console.WriteLine($"x >= y is {f >= g}");   // false
Console.WriteLine($"x <= y is {f <= g}");   // false

Console.WriteLine($"x > z is {f > h}");     // false
Console.WriteLine($"x < z is {f < h}");     // false 
Console.WriteLine($"x >= z is {f >= h}");   // false
Console.WriteLine($"x <= z is {f <= h}");   // false

/*
 * В операциях же == и != идет стандартное сравнение:
 */

int? xa = null;
int? ya = 5;
int? za = null;

Console.WriteLine($"x == y is {xa == ya}");   // false
Console.WriteLine($"x != y is {xa != ya}");   // true

Console.WriteLine($"x == z is {xa == za}");   // true
Console.WriteLine($"x != z is {xa != za}");   // false

void IsNull(int? obj)
{
    if (obj == null) Console.WriteLine("Null");
    else Console.WriteLine(obj);
}
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