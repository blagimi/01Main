﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Последовательное и параллельное выполнение. Task.WhenAll и Task.WhenAny


Асинхронный метод может содержать множество выражений await. Когда система встречает в блоке кода оператор await, 
то выполнение в асинхронном методе останавливается, пока не завершится асинхронная задача. После завершения задачи 
управление переходит к следующему оператору await и так далее. Это позволяет вызывать асинхронные задачи 
последовательно в определенном порядке. Например:

*/

async static void Example()
{
    await PrintAsync("Hello C#");
    await PrintAsync("Hello World");
    await PrintAsync("Hello METANIT.COM");
    
    async Task PrintAsync(string message)
    {
        await Task.Delay(2000);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example();

/*

консольный вывод данной программы:

Hello C#
Hello World
Hello METANIT.COM
То есть мы видим, что вызовы PrintAsync выполняются последовательно в том порядке, в котором они определены в 
коде. Каждая задача выполняется как минимум 2 секунды, соответственно общее время выполнения трех задач будет 
как минимум 6 секунд. И в данном случае вывод строго детерминирован.

Нередко такая последовательность бывает необходима, если одна задача зависит от результатов другой.

Однако это не всегда необходимо. В подобном случае мы можем сразу запустить все задачи параллельно и применить 
оператор await там, где необходимо гарантировать завершение выполнения задачи, например, в самом конце программы.

*/

async static void Example2()
{
    // определяем и запускаем задачи
    var task1 = PrintAsync("Hello C#");
    var task2 = PrintAsync("Hello World");
    var task3 = PrintAsync("Hello METANIT.COM");
    
    // ожидаем завершения задач
    await task1;
    await task2;
    await task3;
    
    async Task PrintAsync(string message)
    {
        await Task.Delay(2000);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example2();
/*

В этом случае все задачи запускаются и выполняются параллельно, соответственно общее время выполнения будет 
меньше 6 секунд, а консольный вывод программы недетерминирован. Например, он может быть следующим:

Hello METANIT.COM
Hello C#
Hello World
Однако .NET позволяет упростить отслеживание выполнения набора задач с помощью метода Task.WhenAll. Этот метод 
принимает набор асинхронных задач и ожидает завершения всех этих задач. Этот метод является аналогом 
статического метода Task.WaitAll(), однако предназначен непосредственно для асинхронных методов и позволяет 
применять оператор await:

*/

async static void Example3()
{
    // определяем и запускаем задачи
    var task1 = PrintAsync("Hello C#");
    var task2 = PrintAsync("Hello World");
    var task3 = PrintAsync("Hello METANIT.COM");
    
    // ожидаем завершения всех задач
    await Task.WhenAll(task1, task2, task3);
    
    async Task PrintAsync(string message)
    {
        await Task.Delay(2000);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example3();
/*

Вначале запускаются три задачи. Затем Task.WhenAll создает новую задачу, которая будет автоматически выполнена 
после выполнения всех предоставленных задач, то есть задач task1, task2, task3. А с помощью оператора await 
ожидаем ее завершения.

Если нам надо дождаться, когда будет выполнена хотя бы одна задача из некоторого набора задач, то можно применять 
метод Task.WhenAny(). Это аналог метода Task.WaitAny() - он завершает выполнение, когда завершается хотя бы 
одна задача. Но для ожидания выполнения к Task.WhenAny() применяется оператор await:

*/
async static void Example4()
{
    // определяем и запускаем задачи
    var task1 = PrintAsync("Hello C#");
    var task2 = PrintAsync("Hello World");
    var task3 = PrintAsync("Hello METANIT.COM");
    
    // ожидаем завершения хотя бы одной задачи
    await Task.WhenAny(task1, task2, task3);
    
    async Task PrintAsync(string message)
    {   
        await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example4(); 

#region Получение результата

/*

Задачи, передаваемые в Task.WhenAll и Task.WhenAny, могут возвращать некоторое значение. В этом случае из методов Task.WhenAll и Task.WhenAny можно получить массив, который будет содержать результаты задач:

*/

async static void Example5()
{
    // определяем и запускаем задачи
    var task1 = SquareAsync(4);
    var task2 = SquareAsync(5);
    var task3 = SquareAsync(6);
    
    // ожидаем завершения всех задач
    int[] results = await Task.WhenAll(task1, task2, task3);
    // получаем результаты:
    foreach (int result in results)
        Console.WriteLine(result);
    
    async Task<int> SquareAsync(int n)
    {
        await Task.Delay(1000);
        return n * n;
    }
}

Example5();

/*
В данном случае метод Square возвращает число int - квадрат передаваемого в метод числа. И переменная results будет содержать результат вызова Task.WhenAll - по сути результаты всех трех запущенных задач. Поскольку все передаваемые в Task.WhenAll задачи возвращают int, то соответственно результат Task.WhenAll будет представлять массив значений int.

Также после завершения задачи ее результат можно получить стандартным образом через свойство Result:
*/

async static void Example6()
{
    // определяем и запускаем задачи
    var task1 = SquareAsync(4);
    var task2 = SquareAsync(5);
    var task3 = SquareAsync(6);
    
    await Task.WhenAll(task1, task2, task3);
    // получаем результат задачи task2
    Console.WriteLine($"task2 result: {task2.Result}"); // task2 result: 25
    
    async Task<int> SquareAsync(int n)
    {
        await Task.Delay(1000);
        return n * n;
    }
}

Example6();

#endregion


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */