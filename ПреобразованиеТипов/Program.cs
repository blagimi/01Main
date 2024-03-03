// See https://aka.ms/new-console-template for more information
Console.Write("Введите имя: ");
string? name = Console.ReadLine();  // ? после типа - присваивает введеное значение либо null
Console.Write("Введите возраст: ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите рост: ");
double  height = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите размер зарплаты: ");
decimal salary = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine($"Имя: {name} Возраст: {age} Зарплата: {salary}");