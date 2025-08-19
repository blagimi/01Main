﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Введение в рефлексию. Класс System.Type

/*

Рефлексия представляет собой процесс выявления типов во время выполнения приложения. Каждое приложение содержит
набор используемых классов, интерфейсов, а также их методов, свойств и прочих кирпичиков, из которых складывается 
приложение. И рефлексия как раз и позволяет определить все эти составные элементы приложения. То есть основная 
задача рефлексии - это исследование типов.

Основной функционал рефлексии сосредоточен в пространстве имен System.Reflection. В нем мы можем выделить 
следующие основные классы:

Assembly: класс, представляющий сборку и позволяющий манипулировать этой сборкой

AssemblyName: класс, хранящий информацию о сборке

MemberInfo: базовый абстрактный класс, определяющий общий функционал для классов EventInfo, FieldInfo, 
MethodInfo и PropertyInfo

EventInfo: класс, хранящий информацию о событии

FieldInfo: хранит информацию об определенном поле типа

MethodInfo: хранит информацию об определенном методе

PropertyInfo: хранит информацию о свойстве

ConstructorInfo: класс, представляющий конструктор

Module: класс, позволяющий получить доступ к определенному модулю внутри сборки

ParameterInfo: класс, хранящий информацию о параметре метода

Эти классы представляют составные блоки типа и приложения: методы, свойства и т.д. Но чтобы получить 
информацию о членах типа, нам надо воспользоваться классом System.Type.

Класс Type представляет изучаемый тип, инкапсулируя всю информацию о нем. С помощью его свойств и методов 
можно получить эту информацию. Некоторые из его свойств и методов:

Метод FindMembers() возвращает массив объектов MemberInfo данного типа

Метод GetConstructors() возвращает все конструкторы данного типа в виде набора объектов ConstructorInfo

Метод GetEvents() возвращает все события данного типа в виде массива объектов EventInfo

Метод GetFields() возвращает все поля данного типа в виде массива объектов FieldInfo

Метод GetInterfaces() получает все реализуемые данным типом интерфейсы в виде массива объектов Type

Метод GetMembers() возвращает все члены типа в виде массива объектов MemberInfo

Метод GetMethods() получает все методы типа в виде массива объектов MethodInfo

Метод GetProperties() получает все свойства в виде массива объектов PropertyInfo

Свойство Name возвращает имя типа

Свойство Assembly возвращает название сборки, где определен тип

Свойство Namespace возвращает название пространства имен, где определен тип

Свойство IsArray возвращает true, если тип является массивом

Свойство IsClass возвращает true, если тип представляет класс

Свойство IsEnum возвращает true, если тип является перечислением

Свойство IsInterface возвращает true, если тип представляет интерфейс

*/

#endregion

#region Получение типа

/*

Чтобы управлять типом и получать всю информацию о нем, нам надо сперва получить данный тип. Это можно сделать 
тремя способами: с помощью оператора typeof, с помощью метода GetType() класса Object и применяя статический 
метод Type.GetType().

Получение типа через typeof:

*/
Type myType = typeof(Person);

Console.WriteLine(myType);  // Person

/*
public class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

Здесь определен класс Person с некоторой функциональностью. И чтобы получить его тип, используется выражение 
Type myType = typeof(Person);

Получение типа с помощью метода GetType, унаследованного от класса Object:

*/

Person tom = new Person("Tom");

Type myType2 = tom.GetType();


/*
В отличие от предыдущего примера здесь, чтобы получить тип, надо создавать объект класса.

И третий способ получения типа - статический метод Type.GetType():
*/

Type? myType3 = Type.GetType("Person", false, true);

/*
Первый параметр указывает на полное имя класса с пространством имен. Второй параметр указывает, будет ли 
генерироваться исключение, если класс не удастся найти. В данном случае значение false означает, что исключение 
не будет генерироваться. И третий параметр указывает, надо ли учитывать регистр символов в первом параметре. 
Значение true означает, что регистр игнорируется. Поскольку указанный тип может отсутствовать, то метод возвращает 
объект nullable-типа

В данном случае класс основной программы и класс Person находятся в глобальном пространстве имен. Однако если 
тип располагается в другом пространстве имен, то его также надо указать:
*/

Type? myType4 = Type.GetType("PeopleTypes.Person", false, true);
 
Console.WriteLine(myType4);  // PeopleTypes.Person

/* 
namespace PeopleTypes
{
    public class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
    }
}
В качестве альтернативы можно применять оператор typeof, передавая в него имя типа с указанием пространства имен:
*/

Type myType5 = typeof(PeopleTypes.Person);

/*
Если нужный нам тип находится в другой сборке dll, то после полного имени класса через запятую указывается имя сборки:
*/

Type? myType6 = Type.GetType("PeopleTypes.Person, MyLibrary", false, true);

/*
Теперь исследуем тип и получим некоторую информацию о нем.
*/


Type myType7 = typeof(PeopleTypes.Person);
 
Console.WriteLine($"Name: {myType7.Name}");              // получаем краткое имя типа
Console.WriteLine($"Full Name: {myType7.FullName}");     // получаем полное имя типа
Console.WriteLine($"Namespace: {myType7.Namespace}");    // получаем пространство имен типа
Console.WriteLine($"Is struct: {myType7.IsValueType}");  // является ли тип структурой
Console.WriteLine($"Is class: {myType7.IsClass}");       // является ли тип классом

/*
Консольный вывод:

Name: Person
Full Name: PeopleTypes.Person
Namespace: PeopleTypes
Is struct: False
Is class: True

*/


#endregion

#region Поиск реализованных интерфейсов

/*

Чтобы получить все реализованные типом интерфейсы, надо использовать метод GetInterfaces(), который 
возвращает массив объектов Type:

*/

Type myType8 = typeof(Person);
 
Console.WriteLine("Реализованные интерфейсы:");
foreach (Type i in myType8.GetInterfaces())
{
    Console.WriteLine(i.Name);
}

/* 
public class Person : IEater, IMovable
{
    public string Name { get; }
    public Person(string name) => Name = name;
    public void Eat() => Console.WriteLine($"{Name} eats");

    public void Move() => Console.WriteLine($"{Name} moves");
}
interface IEater
{
    void Eat();
}
interface IMovable
{
    void Move();
}

Так как каждый интерфейс представляет объект Type, то для каждого полученного интерфейса можно также 
применить выше рассмотренные методы для извлечения информации о свойствах и методах

Но пока все примеры выше никак не использовали рефлексию. В следующих темах рассмотрим, как можно с помощью 
рефлексии получать компоненты типа и обращаться к ним, например, изменять значения приватных полей класса.

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */



namespace PeopleTypes
{
    public class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
    }
}

public class Person : IEater, IMovable
{
    public string Name { get;}
    public Person(string name) => Name = name;
    public void Eat() => Console.WriteLine($"{Name} eats");
 
    public void Move()=> Console.WriteLine($"{Name} moves");
}
interface IEater
{
    void Eat();
}
interface IMovable
{
    void Move();
}