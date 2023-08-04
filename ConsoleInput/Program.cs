// See https://aka.ms/new-console-template for more information
Console.Write("Введите имя: ");
string? name = Console.ReadLine();
Console.Write("Введите возраст: ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите рост: ");
double height = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите размер зарплаты: ");
decimal salary = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine($"Имя: {name} Возраст: {age} Рост: {height} Зарплата: {salary}");



int x1 = 5;
int z1 = ++x1; // z1=6; x1=6
Console.WriteLine($"{x1} - {z1}");

int x2 = 5;
int z2 = x2++; // z2=5; x2=6
Console.WriteLine($"{x2} - {z2}");