using System.Reflection;

#region Получение информации о методах

/*

Для получения получении информации отдельно о методах применяется метод GetMethods(). 
Этот метод возвращает все методы типа в виде массива объектов MethodInfo. Его свойства
 предоставляют информацию о методе. Отметим некоторые из его свойств:

IsAbstract: возвращает true, если метод абстрактный

IsFamily: возвращает true, если метод имеет модификатор доступа protected

IsFamilyAndAssembly: возвращает true, если метод имеет модификатор доступа private 
protected

IsFamilyOrAssembly: возвращает true, если метод имеет модификатор доступа protected 
internal

IsAssembly: возвращает true, если метод имеет модификатор доступа internal

IsPrivate: возвращает true, если метод имеет модификатор доступа private

IsPublic: возвращает true, если метод имеет модификатор доступа public

IsConstructor: возвращает true, если метод предоставляет конструктор

IsStatic: возвращает true, если метод статический

IsVirtual: возвращает true, если метод виртуальный

ReturnType: возвращает тип возвращаемого значения

Некоторые из методов MethodInfo:

GetMethodBody(): возвращает тело метода в виде объекта MethodBody

GetParameters(): возвращает массив параметров, где каждый параметр представлен 
объектом типа ParameterInfo

Invoke(): вызывает метод

Применим ряд свойств для исследования методов класса:

*/

Type myType = typeof(Printer);
 
Console.WriteLine("Методы:");
foreach (MethodInfo method in myType.GetMethods())
{
    string modificator = "";

    // если метод статический
    if (method.IsStatic) modificator += "static ";
    // если метод виртуальный
    if (method.IsVirtual) modificator += "virtual ";

    Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
}

/*

На выходе получим следующую информацию:

Методы:
String get_DefaultMessage ()
Void set_DefaultMessage ()
Void PrintMessage ()
String CreateMessage ()
Type GetType ()
virtual String ToString ()
virtual Boolean Equals ()
virtual Int32 GetHashCode ()
Как видно из вывода в категорию методов также попадают и свойства, которые по сути представляют два метода: get и set. Если подобная ситуация не устраивает, то можно дополнительно фильтровать список методов:

foreach (MethodInfo method in myType.GetMethods()
            .Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
{
 // .........
}

*/


#endregion

#region BindingFlags

/*

В примере выше использовалась простая форма метода GetMethods(), которая извлекает все 
общедоступные публичные методы. Но мы можем использовать и другую форму метода: 
MethodInfo[] GetMethods(BindingFlags). Объединяя значения BindingFlags можно 
комбинировать вывод. Например, получим только методы самого класса без унаследованных, 
как публичные, так и все остальные:

*/

Type myType2 = typeof(Printer);
 
Console.WriteLine("Методы:");
foreach (MethodInfo method in myType2.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    Console.WriteLine($"{method.ReturnType.Name} {method.Name} ()");
}

/*

Теперь метод Print в классе Person является приватным, а метод SayMessage имеет 
модификатор protected internal.

Для получения всех непубличных методов в метод GetMethods() передается набор флагов 
BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, то есть получаем 
все методы экземпляра, как публичные, так и непубличные, но исключаем статические.
Соответственно теперь получим следующий вывод:

Методы:
String get_DefaultMessage ()
Void set_DefaultMessage ()
Void PrintMessage ()
String CreateMessage ()

*/


#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

class Printer
{
    public string DefaultMessage { get; set; } = "Hello";
    public void PrintMessage(string message, int times = 1)
    {
        while (times-- > 0) Console.WriteLine(message);
    }
    public string CreateMessage() => DefaultMessage;
}