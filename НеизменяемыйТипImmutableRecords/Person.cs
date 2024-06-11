namespace НеизменяемыйТипImmutableRecords;

public record Person
{
    public string Name { get; init; }
 
    public Person(string name) => Name = name;
}
