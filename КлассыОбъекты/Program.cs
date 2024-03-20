Person tom = new Person();
string personName = tom.name;
int personAge = tom.age;
Console.WriteLine($"Имя: {personName}  Возраст {personAge}");

tom.name = "Tom";
tom.age = 37;
tom.Print();
class Person
{
    public string name = "Undef";
    public int age;
    public void Print()
    {
        Console.WriteLine($"Имя: {name} Возраст: {age}");
    }
}

