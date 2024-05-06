/*
 * Типы исключений. Класс Exception.
 * Базовым для всех типов исключений является тип Exception. Этот тип определяет ряд свойств, с помощью которых можно получить информацию об исключении:
 * - InnerException: хранит информацию об исключении, которое послужило причиной текущего исключения
 * - Message: хранит сообщение об исключении, текст ошибки
 * - Source: хранит имя объекта или сборки, которое вызвало исключение
 * - StackTrace: возвращает строковое представление стека вызывов, которые привели к возникновению исключения
 * - TargetSite: возвращает метод, в котором и было вызвано исключение
 */
try
{
    int x = 5;
    int y = x/0;
    Console.WriteLine($"result {y}");
}
/*
 * Тип Exception является базовым типом для всех исключений, то выражение catch (Exception ex) будет обрабатывать все исключения, которые могут возникнуть.
 */
catch (Exception exception)
{
    Console.WriteLine($"Метод {exception.TargetSite}\nПолучил исключение {exception.Message}\n{exception.StackTrace}");
}
/*
 * Также есть более специализированные типы исключений, которые предназначены для обработки каких-то определенных видов исключений:
 * DivideByZeroException: представляет исключение, которое генерируется при делении на ноль
 * ArgumentOutOfRangeException: генерируется, если значение аргумента находится вне диапазона допустимых значений
 * ArgumentException: генерируется, если в метод для параметра передается некорректное значение
 * IndexOutOfRangeException: генерируется, если индекс элемента массива или коллекции находится вне диапазона допустимых значений
 * InvalidCastException: генерируется при попытке произвести недопустимые преобразования типов
 * NullReferenceException: генерируется при попытке обращения к объекту, который равен null (то есть по сути неопределен)
 */

/*
 * Можно разграничить обработку различных типов исключений, включив дополнительные блоки catch:
 */

try
{
    int[] numbers = new int [4];
    numbers[7] = 9;     // IndexOutOfRange

    int x = 5;
    int y = x / 0;    // DividedByZero
    Console.WriteLine($"result{y}");
}
/*
 * В данном случае блоки catch обрабатывают исключения типов IndexOutOfRangeException и DivideByZeroException. 
 * Когда в блоке try возникнет исключение, то CLR будет искать нужный блок catch для обработки исключения.
 * Так, в данном случае на строке.
 * numbers[7] = 9; происходит обращение к 7-му элементу массива. Однако поскольку в массиве только 4 элемента, 
 * то мы получим исключение типа IndexOutOfRangeException. CLR найдет блок catch, который обрабатывает данное 
 * исключение, и передаст ему управление.  Следует отметить, что в данном случае в блоке try есть ситуация для 
 * генерации второго исключения - деление на ноль. Однако поскольку после генерации IndexOutOfRangeException 
 * управление переходит в соответствующий блок catch, то деление на ноль int y = x / 0 в принципе не будет 
 * выполняться, поэтому исключение типа DivideByZeroException никогда не будет сгенерировано.
 */
catch (DivideByZeroException)
{
    Console.WriteLine("DividedByZero ex");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    object obj = "you";
    int num = (int)obj; // InvalidCast
    Console.WriteLine(num);
}
catch (DivideByZeroException)
{
    Console.WriteLine("divByZero");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("IndexOutOfRange");
}
catch (Exception ex)
{
    Console.WriteLine($"Исключене {ex.Message}");
}
/*
 * И в данном случае блок catch (Exception ex){} будет обрабатывать все исключения кроме
 * DivideByZeroException и IndexOutOfRangeException. При этом блоки catch для более общих, 
 * более базовых исключений следует помещать в конце - после блоков catch для более конкретный, 
 * специализированных типов. Так как CLR выбирает для обработки исключения первый блок catch,
 * который соответствует типу сгенерированного исключения. Поэтому в данном случае сначала обрабатывается
 * исключение DivideByZeroException и IndexOutOfRangeException, и только потом Exception 
 * (так как DivideByZeroException и IndexOutOfRangeException наследуется от класса Exception).
 */