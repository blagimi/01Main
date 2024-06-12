namespace НеизменяемыйТипImmutableRecords;

public record Person2 (string name, int age)
{
    public string Name {get; init;} = name;
    public int Age {get; init;} = age;
}
