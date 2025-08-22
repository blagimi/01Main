using System.Reflection;     // подключаем функционал рефлексии


#region Получение всех компонентов типа

/*

Метод GetMembers() возвращает все доступные компоненты типа в виде объекта MemberInfo. 
Этот объект позволяет извлечь некоторую информацию о компоненте типа. В частности, 
некоторые его свойства:

DeclaringType: возвращает полное название типа.

MemberType: возвращает значение из перечисления MemberTypes:

MemberTypes.Constructor

MemberTypes.Method

MemberTypes.Field

MemberTypes.Event

MemberTypes.Property

MemberTypes.NestedType

Name: возвращает название компонента

Применим метод GetMembers и выведем все доступные элементы типа:

*/

Type myType = typeof(Person);
 
foreach (MemberInfo member in myType.GetMembers())
{
    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
}

/*

В данном случае мы получим все общедоступные члены класса Person.

Person Method get_Age
Person Method set_Age
Person Method Print
System.Object Method GetType
System.Object Method ToString
System.Object Method Equals
System.Object Method GetHashCode
Person Constructor .ctor
Person Property Age
Обратите внимание, что в данном случае мы получаем только все публичные компоненты 
класса, и нам не выводится информация о приватной переменной name.

Кроме того, для свойства выводятся методы доступа - геттер (здесь get_Age) и сеттер 
(здесь set_Age).

Третий момент, который надо отметить, что по умолчанию мы получаем весь функционал, в 
том числе унаследованный от базовых классов 
(в данном случае функционал базового класса Object).

*/

#endregion

#region BindingFlags

/*

В примере выше использовалась простая форма метода GetMembers(), которая извлекает все общедоступные публичные методы. Но мы можем использовать и другую форму метода: MembersInfo[] GetMembers(BindingFlags). Перечисление BindingFlags может принимать различные значения:

DeclaredOnly: получает только методы непосредственно данного класса, унаследованные методы не извлекаются

Instance: получает только методы экземпляра

NonPublic: извлекает не публичные методы

Public: получает только публичные методы

Static: получает только статические методы

Объединяя данные значения с помощью побитовой операции ИЛИ можно комбинировать вывод. Например, получим только компоненты непосредственно самого класса без унаследованных, как публичные, так и все остальные:


using System.Reflection;     // подключаем функционал рефлексии

*/

Type myType2 = typeof(Person);
 
foreach (MemberInfo member in myType2.GetMembers(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
{
    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
}
 
/*
И в данном случае мы получим несколько другой вывод:

Person Method get_Age
Person Method set_Age
Person Method Print
Person Constructor .ctor
Person Property Age
Person Field name
Person Field <Age>k__BackingField

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

public class Person
{
    string name;
    public int Age { get; set; }
    public Person(string name, int age)
    {
        this.name = name;
        this.Age = age;
    }
    public void Print() => Console.WriteLine($"Name: {name} Age: {Age}");
}