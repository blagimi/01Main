using System;
using System.Dynamic;

namespace DynamicObjectИExpandoObject;

public class PersonObject : DynamicObject
{
     // словарь для хранения всех свойств
    Dictionary<string, object> members = new Dictionary<string, object>();
 
    // установка свойства
    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if(value is not null)
        {
            members[binder.Name] = value;
            return true;
        }
        return false;
    }
    // получение свойства
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = null;
        if (members.ContainsKey(binder.Name))
        {
            result = members[binder.Name];
            return true;
        }
        return false;
    }
    // вызов метода
    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        result = null;
        if(args?[0] is int number)
        {
            // получаем метод по имен
            dynamic method = members[binder.Name];
            // вызываем метод, передавая его параметру значение args?[0]
            result = method(number);
        }
        // если result не равен null, то вызов метода прошел успешно
        return result != null;
    }
}

/*

Класс наследуется от DynamicObject, так как непосредственно создавать объекты DynamicObject мы не можем. И также здесь переопределяется три унаследованных метода.

Для хранения всех членов класса, как свойств, так и методов, определен словарь Dictionary<string, object> members. Ключами здесь являются названия свойств и методов, 
а значениями - значения этих свойств.

В методе TrySetMember() производится установка свойства:

bool TrySetMember(SetMemberBinder binder, object? value)
Параметр binder хранит название устанавливаемого свойства (binder.Name), а value - значение, которое ему надо установить.

Для получения значения свойства переопределен метод TryGetMember:

bool TryGetMember(GetMemberBinder binder, out object? result)
Опять же binder содержит название свойства, а параметр result будет содержать значение получаемого свойства.

Для вызова методов определен метод TryInvokeMember:

public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
{
    result = null;
    if(args?[0] is int number)
    {
        // получаем метод по имен
        dynamic method = members[binder.Name];
        // вызываем метод, передавая его параметру значение args?[0]
        result = method(number);
    }
    // если result не равен null, то вызов метода прошел успешно
    return result != null;
}
Сначала с помощью bindera получаем метод и затем передаем ему аргумент args[0], предварительно приведя его к типу int, и результат метода устанавливаем в параметре result. 
То есть в данном случае подразумевается, что метод будет принимать один параметр типа int и возвращать какой-то результат. Если метод возвращает true, то будем считать, 
что вызов метод прошел успешно.

Теперь применим класс в программе:

*/
