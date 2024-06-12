namespace НеизменяемыйТипImmutableRecords;

public record class Person3
{
    public string Name {get;init;}
    public int Age {get; init;}
    public Person3 (string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Deconstruct(out string name, out int age) => (name, age) = (Name, Age);
}
