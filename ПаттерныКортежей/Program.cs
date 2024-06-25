
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Паттерны кортежей позволяют сравнивать значения кортежей. Например передадим в
 * конструкцию switch кортеж с названием языка и времени дня и в зависимости от 
 * переданных данных возвратим определенное сообщение. Здесь в метод передаются два
 * значения из которых создается кортеж(можно и сразу передавать в метод кортеж).
 * Далее в конструкции switch с помощью круглых скобок определяются значения
 * которым должны соответствовать элементы кортежа.
 */

string GetWelcome(string lang, string daytime) => (lang, daytime) switch
{
    ("english", "morning") => "Good morning",
    ("english", "evening") => "Good evening",
    ("german", "morning") => "Guten Morgen",
    ("german", "evening") => "Guten Abend",
    _ => "Здрасьть"
};

string message = GetWelcome("english", "evening");
Console.WriteLine(message);  // Good evening

message = GetWelcome("french", "morning");
Console.WriteLine(message);  // Здрасьть

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Нам не обязательно сравнивать все значения кортежа, мы можем использовать только некоторые
элементы кортежа. В случае, если мы не хотим использовать элемент кортежа, то вместо него 
ставим прочерк. Теперь кортеж состоит из 3х элементов. Но первые четыре выражения не
используют последний элемент кортежа, допустим он не важен, поэтому вместо него ставится
прочерк. В предпоследнем примере наоборот не важны первые элементы а важен третий. В 
любом случае нам надо указать конкретные значения или прочерки для всех элементов 
кортежа.
*/

string GetWelcome2(string lang, string daytime, string status) => (lang, daytime, status) switch
{
    ("english", "morning", _) => "Good morning",
    ("english", "evening", _) => "Good evening",
    ("german", "morning", _) => "Guten Morgen",
    ("german", "evening", _) => "Guten Abend",
    (_, _, "admin") => "Hello, Admin",
    _ => "Здрасьть"
};

string message2 = GetWelcome2("english", "evening", "user");
Console.WriteLine(message2);  // Good evening

message2 = GetWelcome2("french", "morning", "admin");
Console.WriteLine(message2);  // Hello, Admin

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */