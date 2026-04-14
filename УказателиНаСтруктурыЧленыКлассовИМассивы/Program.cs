#region Указатели на типы и операция ->

/*
Кроме указателей на простые типы можно использовать указатели на структуры. А для доступа к полям 
структуры, на которую указывает указатель, используется операция ->:
*/

unsafe
{
    Point point = new(0,0);
    System.Console.WriteLine(point); // X: 0 Y: 0
    Point* p = &point;

    p-> X = 30;
    System.Console.WriteLine(p->X); //  30

    //  Разименовывание указателя
    (*p).Y = 180;
    System.Console.WriteLine((*p).Y);    //  180;
    System.Console.WriteLine(point);    //  X:30    Y:180
}

#endregion

Console.ReadLine();

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x, int y)
    {
        X = x; Y = y;
    }
    public override string ToString() => $"X: {X}  Y: {Y}";
}