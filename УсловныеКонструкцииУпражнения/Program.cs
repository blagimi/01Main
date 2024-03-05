// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;

Console.WriteLine("Выберите упражнение от 1 до 7");
int practice = Convert.ToInt32(Console.ReadLine());
switch (practice)
{
    case 1:
        methodOne();
        break;
    case 2:
        methodTwo();
        break;
    case 3:
        methodThree();
        break;
    case 4:
        methodFour();
        break;
    default:
        Console.WriteLine("Неверно выбран номер");
        break;
}


void methodOne ()
{
    Console.WriteLine("1) Сравнение 2х цифр.");
    Console.WriteLine("Введите первую цифру: ");
    int inputNumber1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите вторую цифру: ");
    int inputNumber2 = Convert.ToInt32(Console.ReadLine());
    if (inputNumber1 > inputNumber2)
        Console.WriteLine($"Первая цифра {inputNumber1} больше второй {inputNumber2}");
    else if (inputNumber1 < inputNumber2)
        Console.WriteLine($"Первая цифра {inputNumber1} меньше второй {inputNumber2}");
    else
        Console.WriteLine($"Цифра {inputNumber1} и {inputNumber2} равны");
}
void methodTwo()
{
    Console.WriteLine("2) Проверка диапозона цифр");
    Console.WriteLine("Введите цифру от 1 до 10");
    int inputNumber = Convert.ToInt32(Console.ReadLine());
    if (inputNumber > 5 && inputNumber < 10)
        Console.WriteLine("Введенная цифра больше 5 и меньше 10");
    else
        Console.WriteLine("Неизвестная цифра");
}

void methodThree()
{
    Console.WriteLine("3) Проверка цифр на равенство");
    Console.WriteLine("Введите цифру: ");
    int inputNumber = Convert.ToInt32(Console.ReadLine());
    if ((inputNumber == 5) || (inputNumber == 10))
        Console.WriteLine("Введеная цифра либо равна 5 либо 10");
    else
        Console.WriteLine("Неизвестная цифра");
}

void methodFour()
{
    Console.WriteLine("4) Расчёт процента по вкладам");
    Console.WriteLine("Введите сумму вклада от 1 до 300: ");
    double inputSum = Convert.ToDouble(Console.ReadLine());
    double percentage = 0.0;
    if (inputSum < 100.0)
    {
        percentage = 0.05;     
    }
    else if ((inputSum >= 100.0) && (inputSum <= 200.0))
    {
        percentage = 0.07;
    }
    else if (inputSum > 200.0)
    {
        percentage = 0.10;
    }
    inputSum += inputSum * percentage +15;
    Console.WriteLine($"Сумма по вашему вкладу с процентами равна: {inputSum}");
}