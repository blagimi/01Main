﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region 

/*

Отмена задач и параллельных операций. CancellationToken

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

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */