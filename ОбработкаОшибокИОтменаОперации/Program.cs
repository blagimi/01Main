﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


#region Обработка ошибок и отмена операции


/*

При выполнении параллельных операций также могут возникать ошибки, обработка которых имеет 
свои особенности. При параллельной обработке коллекция разделяется а части, и каждая часть 
обрабатывается в отдельном потоке. Однако если возникнет ошибка в одном из потоков, то система 
прерывает выполнение всех потоков.

При генерации исключений все они агрегируются в одном исключении типа AggregateException

Например, пусть в метод факториала передается массив объектов, который содержит не только числа, 
но и строки:

*/

static void Example ()
{
    object[] numbers = new object[] { 1, 2, 3, 4, 5, "6" };

    var squares = from n in numbers.AsParallel()
                  let x = (int)n
                  select Square(x);
    try
    {
        squares.ForAll(n => Console.WriteLine(n));
    }
    catch (AggregateException ex)
    {
        foreach (var e in ex.InnerExceptions)
        {
            Console.WriteLine(e.Message);
        }
    }

    int Square(int n) => n * n;

}

Example();

/*

Запустим проект без отладки. И так как массив содержит строку, то попытка приведения закончится неудачей, 
и на консоль будет выведено сообщение об ошибке. При запуске приложения в Visual Studio в режиме отладки 
выполнение остановится на строке преобразования. А после продолжения также сработает перехват исключения 
в блоке catch, и на консоль будет выведено сообщение об ошибке.

*/


#endregion


#region Прерывание параллельной операции

/*
Вполне вероятно, что нам может потребоваться прекратить операцию до ее завершения. В этом случае мы можем 
использовать метод WithCancellation(), которому в качестве параметра передается токен CancellationToken:
*/

static void Example2()
{
    CancellationTokenSource cts = new CancellationTokenSource();
    // запускаем дополнительную задачу, в которой через 400 миллисек. прерываем операцию
    new Task(() =>
    {
        Thread.Sleep(400);
        cts.Cancel();
    }).Start();

    try
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };

        var squares = from n in numbers.AsParallel().WithCancellation(cts.Token)
                      select Square(n);

        foreach (var n in squares)
            Console.WriteLine(n);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Операция была прервана");
    }
    catch (AggregateException ex)
    {
        if (ex.InnerExceptions != null)
        {
            foreach (Exception e in ex.InnerExceptions)
                Console.WriteLine(e.Message);
        }
    }
    finally
    {
        cts.Dispose();
    }
    int Square(int n)
    {
        var result = n * n;
        Console.WriteLine($"Квадрат числа {n} равен {result}");
        Thread.Sleep(1000); // имитация долгого вычисления
        return result;
    }
}

Example2();

/*

В параллельной запущенной задаче вызывается метод cts.Cancel(), что приводит к завершению 
операции и генерации исключения OperationCanceledException:

Квадрат числа 5 равен 25
Квадрат числа 3 равен 9
Квадрат числа 1 равен 1
Квадрат числа 7 равен 49
Операция была прервана
При этом также имеет смысл обрабатывать исключение AggregateException, так как если параллельно 
возникает еще одно исключение, то это исключение, а также OperationCanceledException помещаются 
внутрь одного объекта AggregateException.

*/

#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */