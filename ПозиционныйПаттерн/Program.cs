using ПозиционныйПаттерн;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Позиционный паттерн применяется к типу у которого определен метод деконструктора.
 * Используем позиционный паттерн и в зависимости от значений объекта MessageDetails
 * возвратим определенное сообщение. Фактически этот паттерн похож на пример с кортежем
 * только теперь вместо кортежа в конструкцию switch передается объект MessageDetails.
 * Через метод деконструктора можно получить набор выходных параметров в виде кортежа
 * и опять по позиции сравнивать их с некоторым значениями в конструкции switch.
 */

MessageDetails details1 = new () { Language = "english", DateTime = "evening", Status = "user" };
string message = GetWelcome(details1);
Console.WriteLine(message);  // Good evening

MessageDetails details2 = new () { Language = "french", DateTime = "morning", Status = "admin" };
message = GetWelcome(details2);
Console.WriteLine(message);  // Hello, Admin

/*
 * В предпоследней инструкции в конструкции switch получаем по позиции значения из 
 * MessageDetails в переменные lang, datetime, status и используем их для создания сообщения.
 */
MessageDetails details3 = new() { Language = "chinese", DateTime = "night", Status = "moderator" };
message = GetWelcome(details3);
Console.WriteLine(message);
static string GetWelcome(MessageDetails details) => details switch
{
    ("english","morning",_) => "Good morning",
    ("english","evening",_) => "Good evening",
    ("german", "morning", _) => "Guten Morgen",
    ("german", "evening", _) => "Guten Abend",
    (_, _, "admin") => "Hello, Admin",
/* Так же можно взять значенияя объекта MessageDetails и использовать их при создании
результата метода.*/
    (var lang, var datetime, var status) => $"{lang} not found,{datetime} unknown, {status} undefined",
    _ => "Здрасьте"
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */