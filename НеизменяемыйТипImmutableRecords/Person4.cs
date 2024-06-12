namespace НеизменяемыйТипImmutableRecords;

public record Person4 (string Name, int Age)
{
    public string Company {get;set;} = "";
}
