﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Задачи продолжения или continuation task позволяют определить задачи, которые выполняются после завершения 
других задач. Благодаря этому мы можем вызвать после выполнения одной задачи несколько других, определить 
условия их вызова, передать из предыдущей задачи в следующую некоторые данные.

Задачи продолжения похожи на методы обратного вызова, но фактически являются обычными задачами Task. 
Посмотрим на примере:

*/

static void Example()
{
    Task task1 = new Task(() =>
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
    });
    
    // задача продолжения - task2 выполняется после task1
    Task task2 = task1.ContinueWith(PrintTask);
    
    task1.Start();
    
    // ждем окончания второй задачи
    task2.Wait();
    Console.WriteLine("Конец метода Main");
    
    
    void PrintTask(Task t)
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
        Console.WriteLine($"Id предыдущей задачи: {t.Id}");
        Thread.Sleep(3000);
    }
}

Example();

/*
Первая задача задается с помощью лямбда-выражения, которое просто выводит id этой задачи. Вторая задача - задача 
продолжения задается с помощью метода ContinueWith, который в качестве параметра принимает делегат Action<Task>. 
То есть метод PrintTask, который передается в вызов ContinueWith, должен принимать параметр типа Task.

Благодаря передачи в метод параметра Task, мы можем получить различные свойства предыдущей задачи, как например, 
в данном случае получает ее Id.

И после завершения задачи task1 сразу будет вызываться задача task2. Консольный вывод программы:

Id задачи: 1
Id задачи: 2
Id предыдущей задачи: 1
Конец метода Main

Также мы можем передавать конкретный результат работы предыдущей задачи:
*/

static void Example2()
{
    Task<int> sumTask = new Task<int>(() => Sum(4, 5));
    
    // задача продолжения
    Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));
    
    sumTask.Start();
    
    // ждем окончания второй задачи
    printTask.Wait();
    Console.WriteLine("Конец метода Main");
    
    int Sum(int a, int b) => a + b;
    void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");
}

Example2();

/*
В данном случае задача sumTask выполняет метод Sum и возвращает его результат. Задача printTask является 
задачей продолжения, выполняется сразу после sumTask и получает ее результат. Так, в вызове
	
Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));

Параметр task в лямбда-выражении фактически представляет задачу sumTask, из которой извлекается результат.

Подобным образом можно построить целую цепочку последовательно выполняющихся задач:
*/

static void Example3()
{
    Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));
    
    // задача продолжения
    Task task2 = task1.ContinueWith(t =>
        Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
    
    Task task3 = task2.ContinueWith(t =>
        Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
    
    
    Task task4 = task3.ContinueWith(t =>
        Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));
    
    task1.Start();
    
    task4.Wait();   //  ждем завершения последней задачи
    Console.WriteLine("Конец метода Main");
}

Example3();
/*
здесь друг за другом выполняются задачи task1, task2, task3, task4. Консольный вывод программы:

Current Task: 1
Current Task: 2  Previous Task: 1
Current Task: 3  Previous Task: 2
Current Task: 4  Previous Task: 3
Конец метода Main



*/


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */