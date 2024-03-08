// See https://aka.ms/new-console-template for more information
int[,,] mas = { { { 1, 2 },{ 3, 4 } },
                { { 4, 5 }, { 6, 7 } },
                { { 7, 8 }, { 9, 10 } },
                { { 10, 11 }, { 12, 13 } }
              };
/*
foreach (int i in mas)
{
    Console.Write($"{i}\t");
}
Console.WriteLine();
Console.WriteLine();
*/
//int x = mas.GetUpperBound(0);
//int y = mas.GetUpperBound(1);

Console.Write("{");
for (int i = 0; i < mas.GetLength(0); i++)
{
    Console.Write("{");
    for (int j = 0; j < mas.GetLength(1); j++)
    {
        Console.Write("{");
        for (int k = 0; k < mas.GetLength(2); k++)
        {
            Console.Write(mas[i, j, k]);
            if (k < mas.GetUpperBound(2))
                Console.Write(",");
        }
        Console.Write("}");
        if (j < mas.GetUpperBound(1))
            Console.Write(",");
    }
    Console.Write("}");
    if (i < mas.GetUpperBound(0))
        Console.Write(",");
}
Console.Write("}");
Console.WriteLine();
/*
for (int i = 0; i < mas.Length; i++)
{
    Console.Write($"{i}\t");
}
*/
