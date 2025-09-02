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

#region Исследование параметров

/*

С помощью метода GetParameters() можно получить все параметры метода в виде массива 
объектов ParameterInfo. Отметим некоторые из свойств ParameterInfo, которые позволяют 
получить информацию о параметрах:

Attributes: возвращает атрибуты параметра

DefaultValue: возвращает значение параметра по умолчанию

HasDefaultValue: возвращает true, если параметр имеет значение по умолчанию

IsIn: возвращает true, если параметр имеет модификатор in

IsOptional: возвращает true, если параметр является необязательным

IsOut: возвращает true, если параметр является выходным, то есть имеет модификатор out

Name: возвращает имя параметра

ParameterType: возвращает тип параметра

Используем тип ParameterInfo для исследования параметров:

*/

foreach (MethodInfo method in typeof(Printer).GetMethods())
{
    Console.Write($"{method.ReturnType.Name} {method.Name} (");
    //получаем все параметры
    ParameterInfo[] parameters = method.GetParameters();
    for (int i = 0; i < parameters.Length; i++)
    {
        var param = parameters[i];
        // получаем модификаторы параметра
         string modificator = "";
        if (param.IsIn) modificator = "in";
        else if (param.IsOut) modificator = "out";
 
        Console.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
        // если параметр имеет значение по умолчанию
        if (param.HasDefaultValue) Console.Write($"={param.DefaultValue}");
        // если не последний параметр, добавляем запятую
        if (i < parameters.Length - 1) Console.Write(", ");
    }
    Console.WriteLine(")");
}

/*

Консольный вывод:

Void PrintMessage (String  message, Int32  times=1)
Void CreateMessage (String& out message)
Type GetType ()
String ToString ()
Boolean Equals (Object  obj)
Int32 GetHashCode ()

Стоит отметить, что если параметр имеет модификатор ref, in, out, то в конце названия 
типа добавляется амперсанд - String&.

*/

#endregion

#region Вызов методов

/*

С помощью метода Invoke() можно вызвать метод:

public object? Invoke (object? obj, object?[]? parameters);
Первый параметр представляет объект, для которого вызывается метод. Второй объект представляет массив значений, которые передаются параметрам метода. И также метод может возвращать результат в виде значения object?.

Вызов метода:
*/

var myPrinter = new Printer2("Hello");
 
// получаем метод Print
var print = typeof(Printer).GetMethod("Print");
// вызываем метод Print
print?.Invoke(myPrinter, parameters: null); // Hello


/*

Метод GetMethod() возвращает метод, который имеет определенное имя - в данном случае 
метод Print. Далее используя полученный метод, его можно вызвать. Здесь при вызове в 
качестве первого параметра передается объект, для которого вызывается метод 
Print - объект myPrinter. И поскольку метод Print не принимает параметров, параметру 
parameters передается значение null.

Если метод непубличный, то для получения метода мы можем передать флаги в вызов GetMethod:

*/

var myPrinter2 = new Printer2("Hello Alex");
 
// получаем метод Print
var print2 = typeof(Printer2).GetMethod("Print",
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
// вызываем метод Print
print?.Invoke(myPrinter, parameters: null); // Hello Alex

/*

Получение результата:

*/


var myPrinter3 = new Printer3();
// получаем метод CreateMessage
var createMessage = typeof(Printer3).GetMethod("CreateMessage");
// вызываем метод CreateMessage и получаем его результат
var result = createMessage?.Invoke(myPrinter, parameters: null);
Console.WriteLine(result);  // Hello 

/*

Стоит отметить, что результат метода представляет тип object?, соответственно при 
необходимости может потребоваться выполнить приведение типов.

Передача параметров:

*/

var myPrinter4 = new Printer3();
// получаем метод PrintMessage
var printMessage = typeof(Printer3).GetMethod("PrintMessage");
// вызываем метод PrintMessage, передавая ему два аргумента
printMessage?.Invoke(myPrinter, new object[] {"Hi world", 3});

/*

Здесь метод PrintMessage имеет два параметра - messsage (некоторое соощение) и times 
(сколько раз надо вывести сообщение на консоль). И для этих параметров передаем массив 
аргументов new object[] {"Hi world", 3}. Таким образом, метод три раза выведет строку 
"Hi world".

Вызов обобщенного метода:

*/

var myPrinter5 = new Printer4();
// получаем метод PrintValue
var printValue = typeof(Printer4).GetMethod("PrintValue");
// получаем обобщенную версию метода для типа string
var printStringValue = printValue?.MakeGenericMethod(typeof(string));
// вызываем метод PrintValue, передавая ему строку
printStringValue?.Invoke(myPrinter, new object[] {"Hello world"});

/*

Для получения обобщенной версии метода, которая типизирована определенным типом, у 
объекта MethodInfo вызывается метод MakeGenericMethod - в него передает тип, которым 
типизируется метод.
*/ 

#endregion

#region Получение конструкторов

/*

Для получения конструкторов применяется метод GetConstructors(), который возвращает массив объектов класса ConstructorInfo. Этот класс во многом похож на MethodInfo и имеет ряд общей функциональности. Некоторые основные свойства и методы:

Свойство IsFamily: возвращает true, если конструктор имеет модификатор доступа protected

Свойство IsFamilyAndAssembly: возвращает true, если конструктор имеет модификатор доступа private protected

Свойство IsFamilyOrAssembly: возвращает true, если конструктор имеет модификатор доступа protected internal

Свойство IsAssembly: возвращает true, если конструктор имеет модификатор доступа internal

Свойство IsPrivate: возвращает true, если конструктор имеет модификатор доступа private

Свойство IsPublic: возвращает true, если конструктор имеет модификатор доступа public

Метод GetMethodBody(): возвращает тело конструктора в виде объекта MethodBody

Метод GetParameters(): возвращает массив параметров, где каждый параметр представлен объектом типа ParameterInfo

Метод Invoke(): вызывает конструктор

Исследуем конструкторы

*/

Type myType3 = typeof(Person);
 
Console.WriteLine("Конструкторы:");
foreach (ConstructorInfo ctor in myType3.GetConstructors(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    string modificator = "";
 
    // получаем модификатор доступа
    if (ctor.IsPublic)
        modificator += "public";
    else if (ctor.IsPrivate)
        modificator += "private";
    else if (ctor.IsAssembly)
        modificator += "internal";
    else if (ctor.IsFamily)
        modificator += "protected";
    else if (ctor.IsFamilyAndAssembly)
        modificator += "private protected";
    else if (ctor.IsFamilyOrAssembly)
        modificator += "protected internal";
 
    Console.Write($"{modificator} {myType.Name}(");
    // получаем параметры конструктора
    ParameterInfo[] parameters = ctor.GetParameters();
    for (int i = 0; i < parameters.Length; i++)
    {
        var param = parameters[i];
        Console.Write($"{param.ParameterType.Name} {param.Name}");
        if (i < parameters.Length - 1) Console.Write(", ");
    }
    Console.WriteLine(")");
}

/*

В данном случае исследуем конструкторы класса Person, один из которых является приватным. 
Консольный вывод:

Конструкторы:
public Person(String name, Int32 age)
public Person(String name)
private Person()

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

class Printer2
{
    public string Text { get;}
    public Printer2(string text) => Text = text;
    public void Print() => Console.WriteLine(Text);
}

class Printer3
{
    public string CreateMessage() => "Hello Alex";
}

class Printer4
{
    public void PrintValue<T>(T value)
    {
        Console.WriteLine(value);
    }
}

class Person
{
    public string Name { get; }
    public int Age { get; }
    public Person(string name, int age)
    {
        Name = name; Age = age;
    }
    public Person(string name) : this(name, 1) { }
    private Person() : this("Tom") { }
}