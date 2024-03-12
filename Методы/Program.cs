/* Общее определение методов выглядит следующим образом:
[модификаторы] тип_возвращаемого_значения название_метода([параметры])
{
    // тело метода
}
*/
static void SayHelloEn()        // Приветствие на английском
{
    Console.WriteLine("hello");
}

SayHelloEn(); // Вызов метода
static void SayHelloRu()        // Приветсвие на русском
{
    Console.WriteLine("Привет");
}
static void SayHelloFr()        // Приветствие на французком
{
    Console.WriteLine("Salut");
}
string language = "En";         // Проверка языка
switch (language)               // Вызов метода соответсвующему языку
{
    case "En":
        SayHelloEn();
        break;
    case "Fr":
        SayHelloFr();
        break;
    default:
        SayHelloRu();
        break;
}

/* Сокращенная запись метода
 * Мы можем его сократить следующим образом:
 * void SayHello() => Console.WriteLine("Hello");
 * То есть после списка параметров ставится оператор =>, после которого идет выполняемая инструкция.
 */