using ПозиционныйПаттерн;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Позиционный паттерн применяется к типу у которого определен метод деконструктора.
 * Используем позиционный паттерн и в зависимости от значений объекта MessageDetails
 * возвратим определенное сообщение.
 */

MessageDetails details1 = new () { Language = "english", DateTime = "evening", Status = "user" };
string message = GetWelcome(details1);
Console.WriteLine(message);  // Good evening

MessageDetails details2 = new () { Language = "french", DateTime = "morning", Status = "admin" };
message = GetWelcome(details2);
Console.WriteLine(message);  // Hello, Admin
static string GetWelcome(MessageDetails details) => details switch
{
    ("english","morning",_) => "Good morning",
    ("english","evening",_) => "Good evening",
    ("german", "morning", _) => "Guten Morgen",
    ("german", "evening", _) => "Guten Abend",
    (_, _, "admin") => "Hello, Admin",
    _ => "Здрасьте"
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */