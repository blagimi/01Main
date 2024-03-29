/*
 * Определение структуры
 * struct имя_структуры
 * {
 *   // элементы структуры
 * }
 */
Person tom = new();
Person bob = new("Bob");
Person sam = new("Sam", 25);

tom.Print();    // Имя: Tom  Возраст: 1
bob.Print();    // Имя: Bob  Возраст: 1 
sam.Print();    // Имя: Sam  Возраст: 25

struct Person
{
    public string name;
    public int age;

    public Person() : this("Tom")
    { }
    public Person(string name) : this(name, 1)
    { }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public readonly void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}