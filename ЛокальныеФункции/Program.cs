// Локальные функции это функции определенные внутри методов.
// Метод сравнение суммы чисел 2х массивов

void Compare(int[] mass1, int[] mass2)
{
    int Sum(int[] tmpMass)
    {
        int result = 0;
        foreach (int n in tmpMass)
        {
            result += n;
        }
        return result;
    }
    int massSum1 = Sum(mass1);
    int massSum2 = Sum(mass2);
    if (massSum1>massSum2)
        System.Console.WriteLine("Массив 1 больше массива 2");
    else if (massSum2>massSum1)
        System.Console.WriteLine("Массив 2 больше массива 1");
    else
        System.Console.WriteLine("Массивы равны");
}

int[] massive1 = {1,2,3,4,5};
int[] massive2 = {1,2,3,4};
Compare(massive1,massive2);

//Статические локальные функции
// Не могут обращаться к содержимому метода, для передачи нужно указывать параметры

int Sum (int[] numbers)
{
    int result = 0;
    int limit = 0;
    foreach(int number in numbers)
    {
        if (IsPassed(number,limit)) result += number;   // Сложение положительных чисел
    }
    return result;

    static bool IsPassed (int number, int lim)  // Проверка на числа больше 0
    {
        //return number > limit;  // Не имеет доступа к limit
        return number > lim;
    }
}
int[] example = {1,2,3,4,-5,-6,-7,-8};
Sum(example);
System.Console.WriteLine(Sum(example));
Console.ReadKey();