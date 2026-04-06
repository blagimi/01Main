using КонструкцияUsing;

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

#region Освобождение множества ресурсов

/*

Для освобождения множества ресурсов мы можем применять вложенные конструкции using. Например:

*/

test4();

/*

В данном случае обе конструкции using создают объекты одного и того же типа, но это могут быть и 
разные типы данных, главное, чтобы они реализовали интерфейс IDisposable.

Мы можем сократить это определение:

*/

Test5();

/*

И, как уже было выше сказано, в C# мы можем задать в качестве области действия для объектов, 
создаваемых в конструкции using, весь метод:

*/

Test6();

/*
Возьмем другой пример:
*/

using (var con = new Connection())
con.Open(new Socket()); // открываем условный сокет для взаимодействия по сети
 
/*
Здесь мы имитируем функциональность сетевого подключения. Подключение зедсь представлено в виде класса Connection. Непосредственно сам обмен по сети обычно происходит с помощью специальных компонентов, которые называются сокетами и которые обычно работают поверх некоторого порта, обеспечивая отправку/получения данных по сети. И в данном случае сокеты представлены классом Socket, в котором для демонстрации определено одной свойство IsOpened - оно указывает, открыт ли сокет. Сокеты обычно рявляются ресурсами, которые предоставляет операционная система и которые необходимо закрывать после завершения работы с ними, чтобы избежать утечек памяти. В данном случае в классе Connection реализован метод Open(), который получает условный сокет и как бы открывает его для взаимодействия по сети. А метод Close() условно закрывает сокет. В методе Dispose закрываем сокет, так как подключения (и соответственно сокет) нам больше не нужны.

В основной части программы создаем объект подключения и открываем его:

using (var con = new Connection())
con.Open(new Socket()); // открываем условный сокет для взаимодействия по сети
Поскольку конструкция using действует до конца текущего метода (метода Main), то при ее завершении автоматически будет вызываться метод Dispose у класса Connection, который, в свою очередь, вызовет метод Close, а тот закроет сокет. Таким образом, объект Connection закроет (освободит) сокет. Консольный вывод программы:

Подключение открыто. Можно посылать пакеты по сети
Подключение закрыто...
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

void test4()
{
    using (Person tom = new Person("Tom"))
    {
        using (Person bob = new Person("Bob"))
        {
            Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");
        }// вызов метода Dispose для объекта bob
    } // вызов метода Dispose для объекта tom
    Console.WriteLine("Конец метода Test");
}

void Test5()
{
    using (Person tom = new Person("Tom"))
    using(Person bob = new Person("Bob"))
    {
        Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");
    } // вызов метода Dispose для объектов bob и tom
    Console.WriteLine("Конец метода Test");
}

static void Test6()
{
    System.Console.WriteLine("test6");
    using Person2 tom = new Person2 { Name = "Tom" };
    using Person2 bob = new Person2 { Name = "Bob" };
     
    Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");
     
    Console.WriteLine("Конец метода Test");
} // вызов метода Dispose для объектов bob и tom

Console.ReadLine();

public class Person : IDisposable
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    public void Dispose() => Console.WriteLine($"{Name} has been disposed");
}

public class Person2 : IDisposable
{
    public string? Name { get;set;}
 
    public void Dispose() => Console.WriteLine($"{Name} has been disposed");
}

class Connection : IDisposable
{
    Socket? activeSocket = null;
 
    // для открытия сетевого подключения передаем сокет
    public void Open(Socket? socket)
    {
        if(activeSocket != socket)  // проверяем сокет
        {
            Close();    // закрываем сокет, если ранее был установлен другой сокет
            activeSocket = socket;
            activeSocket?.IsOpened = true;  // открываем новый сокет
            Console.WriteLine("Подключение открыто. Можно посылать пакеты по сети");
        }
    }
    // закрываем сокет
    public void Close()
    {
        if(activeSocket is not null)
        {
            activeSocket?.IsOpened = false;
            Console.WriteLine("Подключение закрыто...");
        }
    }
    public void Dispose()
    {
        Close();
    }
}