using System;

namespace ФинализируемыеОбъекты;

public class Person
{
    public string? Name  {get;}
    public Person(string name) => Name = name;

    ~Person()
    {
        System.Console.WriteLine($"{Name} has deleted");
    }

}
