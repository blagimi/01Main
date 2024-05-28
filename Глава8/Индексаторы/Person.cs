namespace Индексаторы;

public class Person
{
    public string Name {get;} 
    public Person (string name) => Name = name;

    public Person(string name, Person person1, Person person2, Person person3) : this(name)
    {
    }
}
