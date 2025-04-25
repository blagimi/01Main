﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Отмена задач и параллельных операций. CancellationToken

/*

Параллельное выполнение задач может занимать много времени. И иногда может возникнуть необходимость прервать 
выполняемую задачу. Для этого платформа .NET предоставляет структуру CancellationToken из пространства 
имен System.Threading.

Общий алгоритм отмены задачи обычно предусматривает следующий порядок действий:

    Создание объекта CancellationTokenSource, который управляет и посылает уведомление об отмене токену.

    С помощью свойства CancellationTokenSource.Token получаем собственно токен - объект структуры 
    CancellationToken и передаем его в задачу, которая может быть отменена.

    CancellationTokenSource cancelTokenSource = new CancellationTokenSource(); 
    CancellationToken token = cancelTokenSource.Token;

    Для передачи токена в задачу можно применять один из конструкторов класса Task:
 
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource(); 
    CancellationToken token = cancelTokenSource.Token;
    Task task = new Task(() => { выполняемые_действия}, token); //

    Определяем в задаче действия на случай ее отмены.

    Вызываем метод CancellationTokenSource.Cancel(), который устанавливает для свойства 
    CancellationToken.IsCancellationRequested значение true. Стоит понимать, что сам по себе 
    метод CancellationTokenSource.Cancel() не отменяет задачу, он лишь посылает уведомление об 
    отмене через установку свойства CancellationToken.IsCancellationRequested. Каким образом 
    будет происходить выход из задачи, это решает сам разработчик.

    Класс CancellationTokenSource реализует интерфейс IDisposable. И когда работа с объектом
     CancellationTokenSource завершена, у него следует вызвать метод Dispose для освобождения 
     всех связанных с ним используемых ресурсов. (Вместо явного вызова метода Dispose можно 
     использовать конструкцию using).

Теперь касательно третьего пункта - определения действий отмены задачи. Как именно завершить 
задачу? Конкретные действия на лежат целиком на разработчике, тем не менее есть два общих варианта выхода:

    При получении сигнала отмены выйти из метода задачи, например, с помощью оператора return
     или построив логику метода соответствующим образом. Но следует учитывать, что в этом случае 
     задача перейдет в состояние TaskStatus.RanToCompletion, а не в состояние TaskStatus.Canceled.

    При получении сигнала отмены сгенерировать исключение OperationCanceledException, вызвав у 
    токена метод ThrowIfCancellationRequested(). После этого задача перейдет в состояние TaskStatus.Canceled.



*/

#endregion


#region Мягкий выход из задачи без исключения OperationCanceledException

/*

Сначала рассмотрим первый - "мягкий" вариант завершения:

*/

static void Exemple ()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    // задача вычисляет квадраты чисел
    Task task = new Task(() =>
    {
        for (int i = 1; i < 10; i++)
        {
            if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
            {
                Console.WriteLine("Операция прервана");
                return;     //  выходим из метода и тем самым завершаем задачу
            }
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200);
        }
    }, token);
    task.Start();
    
    Thread.Sleep(1000);
    // после задержки по времени отменяем выполнение задачи
    cancelTokenSource.Cancel();
    // ожидаем завершения задачи
    Thread.Sleep(1000);
    //  проверяем статус задачи
    Console.WriteLine($"Task Status: {task.Status}");
    cancelTokenSource.Dispose(); // освобождаем ресурсы
}

Exemple();

/*
В данном случае задача task вычисляет и выводит на консоль квадраты чисел от 1 до 9. Для 
отмены задачи нам надо создать и использовать токен. Вначале создается объект CancellationTokenSource:

CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
Затем из него получаем сам токен:

CancellationToken token = cancelTokenSource.Token;
Чтобы отменить операцию, необходимо вызвать метод Cancel() у объекта CancellationTokenSource:

cancelTokenSource.Cancel();
В данном случае отмена задачи вызывается через секунду, чтобы задача произвела некоторые действия.

В самом методе задачи в цикле мы можем отловить сигнал отмены с помощью проверки свойства 
token.IsCancellationRequested:

if (token.IsCancellationRequested)
{
    Console.WriteLine("Операция прервана");
    return;
}
Если был вызван метод cancelTokenSource.Cancel(), то выражение token.IsCancellationRequested 
возвращает true.

После завершения задачи проверяем ее статус:

Console.WriteLine($"Task Status: {task.Status}");
Поскольку задача успешно завершена, у задачи должен быть статус RanToCompletion

И в конце у объекта CancellationTokenSource вызываем метод Dispose:

cancelTokenSource.Dispose();
Консольный вывод программы:

Квадрат числа 1 равен 1
Квадрат числа 2 равен 4
Квадрат числа 3 равен 9
Квадрат числа 4 равен 16
Квадрат числа 5 равен 25
Операция прервана
Task Status: RanToCompletion

*/

#endregion

#region Отмена задачи с помощью генерации исключения

/*

Второй способ завершения задачи представляет генерация исключения OperationCanceledException. Для этого 
применяется метод ThrowIfCancellationRequested() объекта CancellationToken:
*/

static void ExempleTwo1()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    Task task = new Task(() =>
    {
        for (int i = 1; i < 10; i++)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested(); // генерируем исключение
    
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200);
        }
    }, token);
    try
    {
        task.Start();
        Thread.Sleep(1000);
        // после задержки по времени отменяем выполнение задачи
        cancelTokenSource.Cancel();
    
        task.Wait(); // ожидаем завершения задачи
    }
    catch (AggregateException ae)
    {
        foreach (Exception e in ae.InnerExceptions)
        {
            if (e is TaskCanceledException)
                Console.WriteLine("Операция прервана");
            else
                Console.WriteLine(e.Message);
        }
    }
    finally
    {
        cancelTokenSource.Dispose();
    }
    
    //  проверяем статус задачи
    Console.WriteLine($"Task Status: {task.Status}");
}

ExempleTwo1();

/*
Здесь опять же проверяем значение свойства IsCancellationRequested, и если оно равно true, генерируем 
исключение:

if (token.IsCancellationRequested)
    token.ThrowIfCancellationRequested(); // генерируем исключение
Чтобы обработать исключение, помещаем весь код работы с задачей в конструкцию try..catch и также с 
помощью вызова cancelTokenSource.Cancel() посылаем сообщение об отмене задачи.

Стоит отметить, что генерируемое исключение будет спрятано в объекте AggregateException, который по 
сути представляет набор исключений. Если причина исключения состояла в отмене задачи, то мы можем 
найти в этом наборе исключений исключение типа TaskCanceledException

catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        if (e is TaskCanceledException)
            Console.WriteLine("Операция прервана");
        else
            Console.WriteLine(e.Message);
    }
}
Класс TaskCanceledException является производным от OperationCanceledException. Исключение типа 
TaskCanceledException возникает, если для задачи устанавливается статус Canceled.

Консольный вывод программы:

Квадрат числа 1 равен 1
Квадрат числа 2 равен 4
Квадрат числа 3 равен 9
Квадрат числа 4 равен 16
Квадрат числа 5 равен 25
Операция прервана
Task Status: Canceled

Стоит отметить, что исключение возникает только тогда, когда мы останавливаем текущий поток и ожидаем 
завершения задачи с помощью методов Wait или WaitAll. Если эти методы не используются для ожидания 
задачи, то для нее просто устанавливается состояние Canceled. Например, в следующем случае 
исключение не возникнет:
*/

static void ExempleTwo2()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    Task task = new Task(() =>
    {
        for (int i = 1; i < 10; i++)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested(); // генерируем исключение
    
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200);
        }
    }, token);
    try
    {
        task.Start();
        Thread.Sleep(1000);
        // после задержки по времени отменяем выполнение задачи
        cancelTokenSource.Cancel();
    
        // ожидаем завершения задачи
        Thread.Sleep(1000);
    }
    catch (AggregateException ae)
    {
        foreach (Exception e in ae.InnerExceptions)
        {
            if (e is TaskCanceledException)
                Console.WriteLine("Операция прервана");
            else
                Console.WriteLine(e.Message);
        }
    }
    finally
    {
        cancelTokenSource.Dispose();
    }
    
    //  проверяем статус задачи
    Console.WriteLine($"Task Status: {task.Status}");
}

ExempleTwo2();

/*
Консольный вывод программы:

Квадрат числа 1 равен 1
Квадрат числа 2 равен 4
Квадрат числа 3 равен 9
Квадрат числа 4 равен 16
Квадрат числа 5 равен 25
Task Status: Canceled

*/

#endregion

#region Регистрация обработчика отмены задачи

/*

Выше для проверки сигнала отмены применялось свойство IsCancellationRequested. Но есть и другой способ узнать
о том, что был послан сигнал отмены задачи. Метод Register() позволяет зарегистрировать обработчик отмены 
задачи в виде делегата Action:
*/

static void ExampleThree()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    // задача вычисляет квадраты чисел
    Task task = new Task(() =>
    {
        int i = 1;
        token.Register(() => 
        { 
            Console.WriteLine("Операция прервана"); 
            i = 10; 
        });
        for (; i < 10; i++)
        {
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(400);
        }
    }, token);
    task.Start();
    
    Thread.Sleep(1000);
    // после задержки по времени отменяем выполнение задачи
    cancelTokenSource.Cancel();
    // ожидаем завершения задачи
    Thread.Sleep(1000);
    //  проверяем статус задачи
    Console.WriteLine($"Task Status: {task.Status}");
    cancelTokenSource.Dispose(); // освобождаем ресурсы
}


/*
Здесь обработчик отмены представлен лямбда-выражением:

token.Register(() => 
{ 
    Console.WriteLine("Операция прервана"); 
    i = 10; 
});
Поскольку действие задачи представляет цикл, который выполняется при значении i меньше 10, то установка этой 
переменной в обработчике отмены приведет к выходу из цикла и соответственно завершению задачи.

*/

#endregion

#region Отмена параллельных операций Parallel

/*

Для отмены выполнения параллельных операций, запущенных с помощью методов Parallel.For() и 
Parallel.ForEach(), можно использовать перегруженные версии данных методов, которые принимают 
в качестве параметра объект ParallelOptions. Данный объект позволяет установить токен:

*/
static void ExampleFour()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    // в другой задаче посылаем сигнал отмены
    new Task(() =>
    {
        Thread.Sleep(400);
        cancelTokenSource.Cancel();
    }).Start();
    
    try
    {
        Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5},
                                    new ParallelOptions { CancellationToken = token }, Square);
        // или так
        //Parallel.For(1, 5, new ParallelOptions { CancellationToken = token }, Square);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Операция прервана");
    }
    finally
    {
        cancelTokenSource.Dispose();
    }
    
    void Square(int n)
    {
        Thread.Sleep(3000);
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
    }
}

ExampleFour();
/*
В параллельной запущенной задаче через 400 миллисекунд происходит вызов cancelTokenSource.Cancel(), в 
результате программа выбрасывает исключение OperationCanceledException, и выполнение параллельных 
операций прекращается.

*/

#endregion

#region Передача токена во внешний метод

/*

Если операция, которая выполняется в задаче, представляет внешний метод, то ему можно передавать в качестве 
одного из параметров:

*/

static void ExampleFive()
{
    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    CancellationToken token = cancelTokenSource.Token;
    
    Task task = new Task(() =>PrintSquares(token), token);
    try
    {
        task.Start();
        Thread.Sleep(1000);
        // после задержки по времени отменяем выполнение задачи
        cancelTokenSource.Cancel();
    
        // ожидаем завершения задачи
        task.Wait();
    }
    catch (AggregateException ae)
    {
        foreach (Exception e in ae.InnerExceptions)
        {
            if (e is TaskCanceledException)
                Console.WriteLine("Операция прервана");
            else
                Console.WriteLine(e.Message);
        }
    }
    finally
    {
        cancelTokenSource.Dispose();
    }
    
    //  проверяем статус задачи
    Console.WriteLine($"Task Status: {task.Status}");
    
    
    void PrintSquares(CancellationToken token)
    {
        for (int i = 1; i < 10; i++)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested(); // генерируем исключение
    
            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200);
        }
    }
}

ExampleFive();

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */