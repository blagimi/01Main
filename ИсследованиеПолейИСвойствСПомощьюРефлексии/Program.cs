using System.Reflection;

#region Получение информации о полях

/*

Для извлечения всех полей применяется метод GetFields(), который возвращает массив 
объектов класса FieldInfo.

Некоторые основные свойства и методы класса FieldInfo:

Свойство IsFamily: возвращает true, если поле имеет модификатор доступа protected

Свойство IsFamilyAndAssembly: возвращает true, если поле имеет модификатор 
доступа private protected

Свойство IsFamilyOrAssembly: возвращает true, если поле имеет модификатор 
доступа protected internal

Свойство IsAssembly: возвращает true, если поле имеет модификатор доступа internal

Свойство IsPrivate: возвращает true, если поле имеет модификатор доступа private

Свойство IsPublic: возвращает true, если поле имеет модификатор доступа public

Свойство IsStatic: возвращает true, если поле статическое

Метод GetValue(): возвращает значение поля

Метод SetValue(): устанавливает значение поля

Например, получим все поля класса:

*/

Type myType = typeof(Person);
 
Console.WriteLine("Поля:");
foreach (FieldInfo field in myType.GetFields(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
{
    string modificator = "";
 
    // получаем модификатор доступа
    if (field.IsPublic)
        modificator += "public ";
    else if (field.IsPrivate)
        modificator += "private ";
    else if (field.IsAssembly)
        modificator += "internal ";
    else if (field.IsFamily)
        modificator += "protected ";
    else if (field.IsFamilyAndAssembly)
        modificator += "private protected ";
    else if (field.IsFamilyOrAssembly)
        modificator += "protected internal ";
 
    // если поле статическое
    if (field.IsStatic) modificator += "static ";
 
    Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
}

/*

Чтобы получить и статические, и не статические, и публичные, и непубличные поля, 
в метод GetFields() передается набор флагов

BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static
Консольный вывод:

Поля:
private String name
private Int32 age
private static Int32 minAge

*/

#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


class Person
{
    static int minAge = 0;
    string name;
    int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"{name} - {age}");
}