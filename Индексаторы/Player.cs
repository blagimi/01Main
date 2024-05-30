namespace Индексаторы;

public class Player
{
    public string? Name {get;set;} 
    public byte? Number {get;set;}
    public Player() {}
    public Player (string? name, byte? number)
    {
        Name = name;
        Number = number;
    } 
}
