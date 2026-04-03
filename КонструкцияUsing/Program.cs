#region Конструкция using

/*

В прошлой теме, где рассматривалась реализация метода Dispose, говорилось, что для его вызова 
можно использовать следующую конструкцию try..catch:

*/

Test();

/*

Однако синтаксис C# также предлагает синонимичную конструкцию для автоматического вызова метод 
Dispose - конструкцию using:

using (Person tom = new Person("Tom"))
{
}
Конструкция using оформляет блок кода и создает объект некоторого типа, который реализует 
интерфейс IDisposable, в частности, его метод Dispose. При завершении блока кода у объекта 
вызывается метод Dispose.

Важно, что данная конструкция применяется только для типов, которые реализуют интерфейс IDisposable.

Ее использование:

*/

Test2();

/*

Консольный вывод:

Name: Tom
Tom has been disposed
Конец метода Test
Здесь мы видим, что по завершении блока using у объекта Person вызывается метод Dispose. Вне блока 
кода using объект tom не существует.

Начиная с версии C# 8.0 мы можем задать в качестве области действия всю окружающую область 
видимости, например, метод:

*/

Test3();

/*

В данном случае using сообщает компилятору, что объявляемая переменная должна быть удалена в конце
области видимости - то есть в конце метода Test. Соответственно мы получим следующий консольный 
вывод:

Name: Tom
Конец метода Test
Tom has been disposed

*/


#endregion


void Test()
{
    Person? tom = null;
    try
    {
        tom = new Person("Tom");
    }
    finally
    {
        tom?.Dispose();
    }
}

void Test2()
{
    using (Person tom = new Person("Tom"))
    {
        // переменная tom доступна только в блоке using
        // некоторые действия с объектом Person
        Console.WriteLine($"Name: {tom.Name}");
    }
    Console.WriteLine("Конец метода Test");
}

void Test3()
{
    using Person tom = new Person("Tom");
     
    // переменная tom доступна только в блоке using
    // некоторые действия с объектом Person
    Console.WriteLine($"Name: {tom.Name}");
    Console.WriteLine("Конец метода Test");
}

public class Person : IDisposable
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    public void Dispose() => Console.WriteLine($"{Name} has been disposed");
}

