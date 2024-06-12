namespace НеизменяемыйТипImmutableRecords;

public record class Employee (string Name, int Age, string Company) : Person3(Name, Age);
