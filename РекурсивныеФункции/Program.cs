/* Рекурсивные функции.
Конструкция при которой функция вызывает саму себя.
При создании рекурсивной функции в ней всегда должен быть базовый вариант
с которого начинается вычисление функции.
*/
// Рекурсивная функция факториала
// n! = 1*2*3..*n. Для нахождения факториала нужно перемножить все числа до заданого числа.
static int Factorial (int n)
{
    if (n==1) return 1;                 // Базовый вариант
    return n * Factorial(n-1);          // Рекурсивный спуск
}
System.Console.WriteLine(Factorial(4)); // 24
// Рекурсивная функция Фибоначчи
// f(n) = f(n-1)+f(n-2) Сумма 2х предыдущих чисел Фибоначчи
static int Fibonachi(int n)
{
    if (n == 0 || n == 1) return n; // fib 0 = 0 fib 1 = 1
    return Fibonachi(n-1)+Fibonachi(n-2);
}
System.Console.WriteLine(Fibonachi(5)); // 5 fib(4)+fib(3)
/* 
Рекурсии и циклы.
Вместо рекурсий можно использовать и циклы они более быстрые чем рекурсия и эффективней.
*/
static int Fibonachi2(int n)
{
    int result = 0;
    int b = 1;
    int temp;
    for (int i = 0; i < n; i++)
    {
        temp = result;
        result = b;
        b+=temp;
    }
    return result;
}
System.Console.WriteLine(Fibonachi2(6));

Console.ReadKey();