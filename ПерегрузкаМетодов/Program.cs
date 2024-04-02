/*
 * Перегрузка методов
 * Иногда возникает необходимость создать один и тот же метод, но с разным набором параметров. 
 * И в зависимости от имеющихся параметров применять определенную версию метода. 
 * Такая возможность еще называется перегрузкой методов (method overloading).
 */
using System.Runtime.CompilerServices;

Calculator calc = new();
calc.Add(1, 2, 3);
calc.Increment(4);
calc.Increment(1);
public class Calculator
{
    public  void Add(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"Result is {result}");
    }
    public void Add(int a, int b, int c)
    {
        int result = a + b + c;
        Console.WriteLine($"Result is {result}");
    }
    public  int Add(int a, int b, int c, int d)
    {
        int result = a + b + c + d;
        Console.WriteLine($"Result is {result}");
        return result;
    }
    public  void Add(double a, double b)
    {
        double result = a + b;
        Console.WriteLine($"Result is {result}");
    }

     public void Increment(ref int val)
    {
        val++;
        Console.WriteLine(val);
    }

     public void Increment(int val)
    {
        val++;
        Console.WriteLine(val);
    }
}