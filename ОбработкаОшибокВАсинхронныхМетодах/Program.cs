﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Обработка ошибок в асинхронных методах, использующих ключевые слова async и await, имеет свои особенности.

Для обработки ошибок выражение await помещается в блок try:

*/

async static void  Example()
{
    try
    {
        await PrintAsync("Hello METANIT.COM");
        await PrintAsync("Hi");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
    async Task PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(100);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example();

/*

В данном случае асинхронный метод PrintAsync генерирует исключение ArgumentException, если методу передается 
строка с длиной меньше 3 символов.

Для обработки исключения в методе Main выражение await помещено в блок try. В итоге при выполнении вызова 
await PrintAsync("Hi") будет сгенерировано исключение, что привет к генерации исключения. Однако программа 
не остановит аварийно свою работу, а обработает исключение и продолжит дальнейшие вычисления.

Консольный вывод программы:

Hello METANIT.COM
Invalid string length: 2
Следует учитывать, что если асинхронный метод имеет тип void, то в этом случае исключение во вне не 
передается, соответственно мы не сможем обработать исключение при вызове метода:

*/

async static void Example2()
{
    try
    {
        PrintAsync("Hello METANIT.COM");
        PrintAsync("Hi");       // здесь программа сгенерирует исключение и аварийно остановится
        await Task.Delay(1000); // ждем завершения задач
    }
    catch (Exception ex)    // исключение НЕ будет обработано
    {
        Console.WriteLine(ex.Message);
    }
    
    async void PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(100);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example2();

/*

В данном случае, не смотря на то, что асинхронные методы вызываются в блоке try, исключение не будет перехвачено 
и обработано. В этом один из минусов применения асинхронных void-методов. Правда, в этом случае мы можем 
определить обработку исключения в самом асинхронном методе:

*/

async static void Example3()
{
    PrintAsync("Hello METANIT.COM");
    PrintAsync("Hi");
    await Task.Delay(1000); // ждем завершения задач
    
    async void PrintAsync(string message)
    {
        try
        {
            // если длина строки меньше 3 символов, генерируем исключение
            if (message.Length < 3)
                throw new ArgumentException($"Invalid string length: {message.Length}");
            await Task.Delay(100);     // имитация продолжительной операции
            Console.WriteLine(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
    }
}

Example3();

#region Исследование исключения

/*

При возникновении ошибки у объекта Task, представляющего асинхронную задачу, в которой произошла ошибка, 
свойство IsFaulted имеет значение true. Кроме того, свойство Exception объекта Task содержит всю информацию 
об ошибке. Проинспектируем данное свойство:

*/

async static void Example4()
{
    var task = PrintAsync("Hi");
    try
    {
        await task;
    }
    catch
    {
        Console.WriteLine(task.Exception?.InnerException?.Message); // Invalid string length: 2
        Console.WriteLine($"IsFaulted: {task.IsFaulted}");  // IsFaulted: True
        Console.WriteLine($"Status: {task.Status}");        // Status: Faulted
    }
    
    async Task PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(1000);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example4();

/*

И если мы передадим в метод строку с длиной меньше 3 символов, то task.IsFaulted будет равно true.

*/

#endregion


#region Обработка нескольких исключений. WhenAll

/*

Если мы ожидаем выполнения сразу нескольких задач, например, с помощью Task.WhenAll, то мы можем получить сразу 
несколько исключений одномоментно для каждой выполняемой задачи. В этом случае мы можем получить все исключения 
из свойства Exception.InnerExceptions:

*/

async static void Example5()
{
    // определяем и запускаем задачи
    var task1 = PrintAsync("H");
    var task2 = PrintAsync("Hi");
    var allTasks = Task.WhenAll(task1, task2);
    try
    {
        await allTasks;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
        if(allTasks.Exception is not null)
        {
            foreach (var exception in allTasks.Exception.InnerExceptions)
            {
                Console.WriteLine($"InnerException: {exception.Message}");
            }
        }
    }
    
    async Task PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string: {message}");
        await Task.Delay(1000);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example5();

/*

Здесь в два вызова метода PrintAsync передаются заведомо некорректные значения. Таким образом, при обоих 
вызовах будет сгенерирована ошибка.

Хотя блок catch через переменную Exception ex будет получать одно перехваченное исключение, но с помощью 
коллекции Exception.InnerExceptions мы сможем получить информацию обо всех возникших исключениях.

В итоге при выполнении этого метода мы получим следующий консольный вывод:

Exception: Invalid string: H
IsFaulted: True
InnerException: Invalid string: H
InnerException: Invalid string: Hi

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */