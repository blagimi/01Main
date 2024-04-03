Person tom = new("Tom", 23);
Console.WriteLine($"{tom.Name}, {tom.age}");
ConstPerson jeff = new();
jeff.name = "Jeff";
jeff.Print();

Example example = new Example(10);
Console.WriteLine(example.field);

/*
 * Кроме полей для чтения в C# можно определять структуры для чтения. 
 * Для этого они предваряются модификатором readonly: 
 * Особенностью таких структур является то, что все их поля должны быть также полями для чтения:
 */
readonly struct Person
{
    public readonly int age;
    public readonly string Name { get; } // Указывать readonly необязательно
    public Person (string name, int age)
    {
        Name = name;
        this.age = age;
    }
}

/* 
 * Кроме полей класс может определять для хранения данные констант.
 * В отличие от полей их значение устанавливается один раз непосредственно при их объявлении и впоследствии не может быть изменено. 
 * Кроме того, константы хранят некоторые данные, которые относятся не к одному объекту, 
 * а ко всему классу в целом. И для обращения к константам применяется не имя объекта, а имя класса:
 */
class ConstPerson
{
    public const string type = "Person";
    public string name = "Undefined";
    public void Print() => Console.WriteLine($"{type}:{name}");
}
/*
 * Сравнение констант
 * Константы должны быть определены во время компиляции, а поля для чтения могут быть определены во время выполнения программы.
 * Соответственно значение константы можно установить только при ее определении.
 * Поле для чтения можно инициализировать либо при его определении, либо в конструкторе класса.
 * Константы не могут использовать модификатор static, так как уже неявно являются статическими. Поля для чтения могут быть как статическими, так и не статическими.
 */

class Example
{
    public const double KOEF = 4.5;
    public readonly double field = 7.8;

    public Example(int f)
    {
        this.field = KOEF * f;
    }
}