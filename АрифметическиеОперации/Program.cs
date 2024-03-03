// See https://aka.ms/new-console-template for more information
const int TEN = 10;
int z1 = TEN + 12;  // 22
Console.WriteLine($"Сложение: {z1}");
int z2 = TEN - 6;   //  4
Console.WriteLine($"Вычитание: {z2}");
int z3 = TEN * 5;   // 50
Console.WriteLine($"Умножение: {z3}");
int z4 = TEN / 5;   //  2
Console.WriteLine($"Деление: {z4}");

double z5 = TEN / 4;    // 2   
Console.WriteLine($"{z5} Деление 2х целых числе, остаток отбрасывается");
double z6 = 10.0 / 4.0; // Определение участвующих операндов как вещественные числа
Console.WriteLine($"{z6} Деление 2х вещественных чисел, остаток указывается как есть");
double x = 10.0;
double z7 = x % 4.0;    // Получение остатка от деления 
Console.WriteLine($"{z7} остаток от деления");

int x1 = 5;     //  6
int y1 = ++x1;  //  6
Console.WriteLine($"{x1} - {y1}");

int x2 = 5;     // 6
int y2 = x2++;  // 5
Console.WriteLine($"{x2} - {y2}");

int x3 = 5;     //  4
int y3 = --x3;  //  4
Console.WriteLine($"{x3} - {y3}");

int x4 = 5;     //  4
int y4 = x4--;  //  5
Console.WriteLine($"{x4} - {y4}");

int a = 3;
int b = 5;
int c = 40;
int d = c---b*a;
Console.WriteLine($"a: {a} b: {b} c: {c} d: {d}");      // 3 5 39 25
int a1 = 3;
int b1 = 5;
int c1 = 40;
int f = (c1 - (--b1)) * a1;  // Меняем расстановку с помощью скобок
Console.WriteLine($"a: {a1} b: {b1} c: {c1} f:{f}");    // 3 4 40 108