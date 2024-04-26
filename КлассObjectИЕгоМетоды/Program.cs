﻿/*
 * Класс System.Object и его методы.
 * Все классы в .NET, даже те, которые мы сами создаем, а также базовые типы, 
 * такие как System.Int32, являются неявно производными от класса Object. 
 * Даже если мы не указываем класс Object в качестве базового, по умолчанию 
 * неявно класс Object все равно стоит на вершине иерархии наследования. 
 * Поэтому все типы и классы могут реализовать те методы, которые определены
 * в классе System.Object. 
 */
using КлассObjectИЕгоМетоды;

/*
 * Метод ToString.
 * Служит для получения строкового представления данного объекта.
 * Для базовых типов просто будет выводиться их строковое значение:
 */
int i = 5;
Console.WriteLine(i.ToString()); // 5

double d = 3.5;
Console.WriteLine(d.ToString()); // 3.5
/*
 * Для классов же этот метод выводит полное название класса с указанием 
 * пространства имен, в котором определен этот класс. И мы можем 
 * переопределить данный метод. 
 */

/*
 * Для переопределения метода ToString() в классе Clock, который представляет часы
 * используется ключевое слово override (как и при обычном переопределении 
 * виртуальных или абстрактных методов). В данном случае метод ToString() 
 * выводит в строке значения свойств Hours, Minutes, Seconds.Класс Person 
 * не переопределяет метод ToString, поэтому для этого класса срабатывает 
 * стандартная реализация этого метода, которая выводит просто название класса.
 */

Person person = new() { Name = "Tom" };
Console.WriteLine(person.ToString());   // КлассObjectИЕгоМетоды.Person

Clock clock = new() { Hours = 15, Minutes = 34, Seconds = 53 };
Console.WriteLine(clock.ToString());    // 15:34:53

/*
 * То есть если имя - свойство Name не имеет значения, оно представляет 
 * пустую строку, то возвращается базовая реализация - название класса.
 * Стоит отметить, что базовая реализация возвращает не просто строку,
 * а объект string? - то есть это может быть строка string, либо значение 
 * null, которое указывает на отсутствие значения. И в реальности в 
 * качестве возвращаемого типа для метода мы можем использовать как string,
 * так и string?Если же имя у объекта Person установлено, то возвращается
 * значение свойства Name. Для проверки строки на наличие значения 
 * применяется метод String.IsNullOrEmpty().
 */
Person2 person2 = new() { Name="Jack"};
Console.WriteLine(person2.ToString());  // Jack

/*
 * Стоит отметить, что различные технологии на платформе .NET активно 
 * используют метод ToString для разных целей. 
 * В частности, тот же метод Console.WriteLine() по умолчанию выводит 
 * именно строковое представление объекта. Поэтому, если нам надо вывести 
 * строковое представление объекта на консоль, то при передаче объекта в 
 * метод Console.WriteLine необязательно использовать метод ToString() - 
 * он вызывается неявно
 */
Console.WriteLine(person);  // КлассObjectИЕгоМетоды.Person
Console.WriteLine(clock);   // выведет 15:34:53

/*
 * Метод GetHashCode.
 * Метод GetHashCode позволяет возвратить некоторое числовое значение, 
 * которое будет соответствовать данному объекту или его хэш-код. 
 * По данному числу, например, можно сравнивать объекты. 
 * Можно определять самые разные алгоритмы генерации подобного числа
 * или взять реализацию базового типа:
 * В данном случае метод GetHashCode возвращает хеш-код для значения свойства 
 * Name. То есть два объекта Person, которые имеют одно и то же имя, будут 
 * возвращать один и тот же хеш-код. Однако в реальности алгоритм может быть 
 * самым различным.
 */
Console.WriteLine(person.Name.GetHashCode());
Console.WriteLine(person2.GetHashCode());
/*
 * Получение типа объекта и метод GetType.
 * Метод GetType позволяет получить тип данного объекта:
 * Этот метод возвращает объект Type, то есть тип объекта.
 * С помощью ключевого слова typeof мы получаем тип класса и сравниваем его с типом объекта. И если этот объект представляет тип Person, то выполняем определенные действия.
 */
Console.WriteLine(person.GetType());    // Person
if (person.GetType() == typeof(Person))
    Console.WriteLine("Это класс person");
/*
 * Причем поскольку класс Object является базовым типом для всех классов, 
 * то мы можем переменной типа object присвоить объект любого типа. 
 * Однако для этой переменной метод GetType все равно вернет тот тип,
 * на объект которого ссылается переменная. То есть в данном случае объект
 * типа Person.
 * Стоит отметить, что проверку типа в примере выше можно сократить
 * с помощью оператора is:
 */
if (person is Person)
    Console.WriteLine("Это IS person");
/*
 * В отличие от методов ToString, Equals, GetHashCode метод GetType() 
 * не переопределяется.
 */