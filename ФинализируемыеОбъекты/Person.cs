using System;

namespace ФинализируемыеОбъекты;

public class Person : IDisposable
{
    public string? Name  {get;}
    public Person(string name) => Name = name;

    ~Person()
    {
        System.Console.WriteLine($"{Name} has deleted");
    }

    public void Dispose()
    {
        Console.WriteLine($"{Name} has been disposed");
    }

}
