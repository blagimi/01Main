// See https://aka.ms/new-console-template for more information
// Цикл for
Console.WriteLine("1) --- ");
for (int i = 1; i < 4; i++)
{
    Console.Write($"{i} ");   // 1 2 3
}
Console.WriteLine();
/* Если блок цикла for содержит одну инструкцию, то мы можем его сократить, убрав фигурные свобки:
 *for (int i = 1; i < 4; i++)
 *   Console.WriteLine(i);
 * или так
 * for (int i = 1; i < 4; i++) Console.WriteLine(i); */
// Так же можно определять несколько переменных в обьявлении цикла
Console.WriteLine("2) --- ");
for (int i = 1, j = 1; i < 10;i++,j++)
    Console.Write($"{i*j} ");    // 1 4 9 16 25 36 49 64 81
// Цикл do..while
Console.WriteLine();
Console.WriteLine("3) --- ");
int a = 6;
do    // Выполниться хотя бы один раз
{
    Console.Write($"{a} ");   // 6 5 4 3 2 1
    a--;
}
// Цикл while
while (a > 0);
Console.WriteLine();
Console.WriteLine("4) --- ");
int b = 6;
while (b>0)
{
    Console.Write($"{b} ");
    b--;
}
Console.WriteLine();
// Цикл foreach
Console.WriteLine("5) --- ");
foreach (char c in "Tom")
{
    Console.Write($"{c} ");
}
Console.WriteLine();
// Оператор break
Console.WriteLine("6) --- ");
for (int n = 0; n < 9; n++)
{
    if (n == 5)
        break;  //  Завершает цикл когда итерация доходит до значения 5
    Console.Write($"{n} ");
}
Console.WriteLine();
// Оператор continue
Console.WriteLine("7) --- ");
for (int m = 0; m < 9; m++)
{
    if (m == 5) // Пропускает итерацию в которой значение равно 5 и продолжает цикл
        continue;
    Console.Write($"{m} ");
}
Console.WriteLine();
// Вложенные циклы
Console.WriteLine("8) --- ");
for (int r = 1; r < 10; r++)
{
    for (int e = 1; e < 10; e++)
    {
        Console.Write($"{r * e} \t");
    }
    Console.WriteLine();    // Таблица умножения
}