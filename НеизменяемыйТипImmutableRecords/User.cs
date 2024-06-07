namespace НеизменяемыйТипImmutableRecords;

public class User
{
public string Name { get; init; }
public User(string name) => Name = name;
}
