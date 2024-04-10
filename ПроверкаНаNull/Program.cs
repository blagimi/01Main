/*
 * Проверка на null. Null guard.
 * Если мы собираемся использовать переменную или параметр, которые допускают значение null, то есть представляют nullable-тип (не важно значимый или ссылочный),
 * то, чтобы избежать возникновения NullReferenceException, мы можем проверить на null:
 */
void PrintUpper(string? text)
{
    if (text != null)
    {
        Console.WriteLine(text.ToUpper());
    }
}
void IsPrintToUpper(string? text)
{
    if (text is null) return; Console.WriteLine(text.ToUpper());
}

void IsNotPrintToUpper(string? text)
{
    if (text is not null)
        Console.WriteLine(text.ToUpper());
}
void PrintToUpperType(string? text)
{
    if (text is string)
        Console.WriteLine(text.ToUpper());
    else
        Console.WriteLine("Null");
}

string? text = "Привет мир";
string? text2 = null;
PrintUpper(text);           // text
PrintUpper(text2);          // null
/*
 * Кроме того с помощью оператора is мы можем проверить значение объекта
 * объект is значение
 */
IsPrintToUpper(text);       // text
IsPrintToUpper(text2);      // null
/*
 * или с помощью is not проверить отсутствие значения
 */
IsNotPrintToUpper(text);    // text
IsNotPrintToUpper(text2);   // null

/*
 * Так же можно проверить на соответсвие типу, значение которого собираемся использовать
 */
PrintToUpperType(text);     // text
PrintToUpperType(text2);    // null
/*
 * Подобные проверки называются null guard или защита от null
 */

/*
 * Оператор ??
 * Называется оператором null-объеденения. Приминяется для установки значений по умолчанию
 * для типов которые допускают значение null
 */

string? text3 = null;
string name = text3 ?? "Tom"; // Равно Tom, так как text равен null
Console.WriteLine(name);      // Tom

int? id = 200;
int personId = id ?? 1;        // Равно 200, так как id не равен null
Console.WriteLine(personId);

/*
 * Не в nullable типах использовать нельзя, поскольку они не принимают null в качестве значения
 * int x = 44;
 * int y = x ?? 100; 
 */

/*
 * Так же допустима подобная запись
 */
string? text4 = null;
/* Аналогично записи text4 = text4 ?? "Sam" */
text4 ??= "Sam";
Console.WriteLine(text4);       // Sam

int? id2 = 100;
/* Аналогично записи id2 = id2 ?? 1 */
id2 ??= 1;
Console.WriteLine(id2);         // 100

/*
 * Оператор условного null
 * Иногда при работе с объектами, которые принимают значение null, мы можем столкнуться с ошибкой: 
 * мы пытаемся обратиться к объекту, а этот объект равен null.
 */

/*
 * Допустим надо вывести на консоль заглавными буквами веб-сайт комании, где работает человек.
 */
void PrintWebSite(Person? person)
{
    if (person != null)
    {
        if (person.Company != null)
        {
            if(person.Company.WebSite != null)
            {
                Console.WriteLine(person.Company.WebSite.ToUpper());
            }
        }
    }
}
/*
 * Хоть это и рабочий способ, но для простого вывода строки получается многоэтажная конструкция, но на самом деле ее можно сократить:
 */
void PrintWebSite2(Person person)
{
    if (person != null && person.Company != null && person.Company.WebSite != null)
    {
        Console.WriteLine(person.Company.WebSite.ToUpper());
    }
    else
        Console.WriteLine("null");
}
/* 
 * Конструкция намного проще, но все равно получается довольно большой. 
 * И чтобы ее упростить, в C# есть оператор условного null (Null-Conditional Operator) - оператор ?.:
 * объект?.компонент
 * Если объект не равен null, то происходит обращение к компоненту объекта - полю, свойству, методу. 
 * Если объект представляет значение null, обращение к компаненту метода не происходит.
 */
void PrintWebSite3(Person? person)
{
    Console.WriteLine(person?.Company?.WebSite?.ToUpper());
}
/*
 * Таким образом, если person не равен null, то происходит обращение к его свойству Company. 
 * Если свойство Company не равно null, то идет обрашение к свойству WebSite объекта Company. 
 * Если свойство WebSite не равно null, то идет обращение к методу ToUpper().
 */

Person alex = new() { Company = new() { WebSite = "google.com" } };
Person jeff = new();
PrintWebSite(alex);
PrintWebSite2(jeff);
PrintWebSite3(alex);

class Person                                // Человек
{
    public Company? Company { get; set; }   // Место работы
}
class Company
{
    public string? WebSite { get; set; }    // Веб-сайт компании
}
/*
 * Объект Person представляет человека. Его свойство Company представляет компанию, где человек работает. 
 * Но человек может не работать, поэтому свойство Company имеет тип Company?, то есть может иметь значение null.
 * Класс Company в свою очередь содержит свойство WebSite, которое представляет веб-сайт компании. 
 * Но у компании может и не быть собственного веб-сайта. Поэтому это свойство имеет тип string?, 
 * то есть также допускает значение null.
 */

