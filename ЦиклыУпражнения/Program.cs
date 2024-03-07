// See https://aka.ms/new-console-template for more information
///<summary>Вызов конструкции свитч кейс</summary>
///<remarks>В зависимости от введеной пользователем цифры выполняет связанную с этим номером инструкцию</remarks>
Console.WriteLine("Введите номер упражнения от 1 до 4");
int number = Convert.ToInt32(Console.ReadLine());
switch (number)
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
///<summary>Расчёт процентов по вкладу в банк</summary>
///<remarks>В зависимости от введеной пользователем суммы вклада и сроком вклада расчтывает сумму вклада с процентами через цикл for</remarks>
///<return>Вывод на экран итоговой суммы по вкладу с процентами за каждый месяц</return>
void methodOne()
{
    decimal percentage = 0.07M;
    Console.WriteLine("Введите сумму вклада");
    decimal inputSum = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Введите срок вклада в месяцах");
    int userNumberOfMonths = Convert.ToInt32(Console.ReadLine());
    for (int monthsNumber = 0; monthsNumber < userNumberOfMonths; monthsNumber++)
    {
        inputSum += inputSum * percentage;
        Console.WriteLine($"Ваша сумма вклада с учётом процентов: {Convert.ToDecimal(inputSum)}");
    }
}
///<summary>Расчёт процентов по вкладу в банк</summary>
///<remarks>В зависимости от введеной пользователем суммы вклада и сроком вклада расчтывает сумму вклада с процентами через цикл while</remarks>
//////<return>Вывод на экран итоговой суммы по вкладу с процентами за каждый месяц</return>
void methodTwo()
{
    decimal percentage = 0.07M;
    int monthsNumber = 0;
    Console.WriteLine("Введите сумму вклада");
    decimal inputSum = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Введите срок вклада в месяцах");
    int userNumberOfMonths = Convert.ToInt32(Console.ReadLine());
    while (userNumberOfMonths>monthsNumber)
    {
        userNumberOfMonths--;
        inputSum += inputSum * percentage;
        Console.WriteLine($"Ваша сумма вклада с учётом процентов: {Convert.ToDecimal(inputSum)}");
    }
}
///<summary>Таблица умножения</summary>
///<remarks>С помощью 2х циклов for изображает таблицу умножения на экране</remarks>
///<return>Вызывает консоль и выводит на экран таблицу умножения 9x9</return>
void methodThree()
{
    Console.WriteLine();
    for (int i = 1; i < 10; i++)            // Передача значение первого столбца для заполнения строки J (1*1-9) (2*1-9)
    {
        for (int j = 1; j < 10; j++)
        {
            Console.Write($"{i * j} \t");   // Вывод на экран содержимого J в одну строку подряд пока условие true 
        }
        Console.WriteLine();    // Переход на другую строку когда J переполнено
    }
}
///<summary>Проверка допустимости вводимых пользователем данных</summary>
///<remarks>С помощью цикла while проверяется что бы пользователь ввёл данные в нужном диапозоне, если он ошибается повтор ввода</remarks>
///<return>Вывод на консоль результат умножения 2х чисел в случает правильного ввода данных иначе сообщение об ошибке и запрос повторного ввода данных</return>
void methodFour()
{
    bool inputCheck;
    while (true)
    {
        Console.WriteLine("Введите первое число от 0 до 10");
        inputCheck = Int32.TryParse(Console.ReadLine(), out int number);
        if (!inputCheck)
        { 
            Console.WriteLine("Вы не ввели число, повторите ввод");
            break;
        }
        Console.WriteLine("Введите первое число от 0 до 10");
        inputCheck = Int32.TryParse(Console.ReadLine(), out int number2);
        if (!inputCheck)
        {
            Console.WriteLine("Вы не ввели число2, повторите ввод");
            break;
        }
        if (number < 0 || number > 10 || number2 < 0 || number2 > 10)
        {
            Console.WriteLine("Оба числа должны быть в диапозоне от 0 до 10");
        }
        else
        {
            Console.WriteLine($"Результат умножение двух числе равен: {number * number2}");
            break;
        }
    }
}