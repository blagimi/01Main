namespace ЧастичныеКлассыИМетоды;

public partial class Person
{
    partial void Read();
    public void ReadSomething()
    {
        Read();
    }
    public void Move()
    {
        Console.WriteLine("I am moving");
        
    }
}
