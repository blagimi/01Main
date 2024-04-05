PrintNullable(5);       // 5
PrintNullable(null);    // параметр равен null

void PrintNullable(int? number)
{
    if (number.HasValue)
    {
        Console.WriteLine(number.Value);
        // аналогично
        Console.WriteLine(number);
    }
    else
    {
        Console.WriteLine("параметр равен null");
    }
}