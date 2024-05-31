namespace ЧастичныеКлассыИМетоды;

public partial class Person
{
    partial void Read()
    {
        Console.WriteLine("I am reading book");
    }
    public void Eat()
    {
        Console.WriteLine("I am eat");
    }
}
