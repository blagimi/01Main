/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

#region Вложенные задачи

/*

Одна задача может запускать другую - вложенную задачу. При этом эти задачи выполняются независимо друг от друга.
Например:

*/

static void FirstEx()
{
    var outer = Task.Factory.StartNew(() =>      // внешняя задача
    {
        Console.WriteLine("Outer task starting...");
        var inner = Task.Factory.StartNew(() =>  // вложенная задача
        {
            Console.WriteLine("Inner task starting...");
            Thread.Sleep(2000);
            Console.WriteLine("Inner task finished.");
        });
    });
    outer.Wait(); // ожидаем выполнения внешней задачи
    Console.WriteLine("End of Main");
}

FirstEx();

/*

Несмотря на то, что здесь мы ожидаем выполнения внешней задачи, но вложенная задача может завершить выполнение 
даже после завершения метода Main:

Outer task starting...
End of Main

При этом внутренняя задача может даже не начать свое выполнение к завершению работы основного потока программы. 
То есть в данном случае внешняя и вложенная задачи выполняются независимо друг от друга.

Если необходимо, чтобы вложенная задача выполнялась как часть внешней, необходимо использовать значение 
TaskCreationOptions.AttachedToParent:

*/

static void FirstEx2()
{
    var outer = Task.Factory.StartNew(() =>      // внешняя задача
    {
        Console.WriteLine("Outer task starting...");
        var inner = Task.Factory.StartNew(() =>  // вложенная задача
        {
            Console.WriteLine("Inner task starting...");
            Thread.Sleep(2000);
            Console.WriteLine("Inner task finished.");
        }, TaskCreationOptions.AttachedToParent);
    });
    outer.Wait(); // ожидаем выполнения внешней задачи
    Console.WriteLine("End of Main");
}

FirstEx2();

/*

Консольный вывод:

Outer task starting...
Inner task starting...
Inner task finished.
End of Main

В данном случае вложенная задача прикреплена к внешней и выполняется как часть внешней задачи. И внешняя задача 
завершится только когда завершатся все прикрепленные к ней вложенные задачи.

*/

#endregion

#region Массив задач

/*
Также как и с потоками, мы можем создать и запустить массив задач. Можно определить все задачи в массиве 
непосредственно через объект Task:

*/
static void SecondEx()
{
    Task[] tasks1 = new Task[3]
    {
        new Task(() => Console.WriteLine("First Task")),
        new Task(() => Console.WriteLine("Second Task")),
        new Task(() => Console.WriteLine("Third Task"))
    };
    // запуск задач в массиве
    foreach (var t in tasks1)
        t.Start();
}

SecondEx();
/*

Либо также можно использовать методы Task.Factory.StartNew или Task.Run и сразу запускать все задачи:
*/
static void SecondEx2()
{
    Task[] tasks2 = new Task[3];
    int j = 1;
    for (int i = 0; i < tasks2.Length; i++)
        tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));
}

SecondEx2();
/*
Но в любом случае мы опять же можем столкнуться с тем, что все задачи из массива могут завершиться после того 
как отработает метод Main, в котором запускаются эти задачи:
*/

static void SecondEx3()
{
    Task[] tasks = new Task[3];
    for(var i = 0; i < tasks.Length; i++)
    {
        tasks[i] = new Task(() =>
        {
            Thread.Sleep(1000); // эмуляция долгой работы
            Console.WriteLine($"Task{i} finished");
        });
        tasks[i].Start();   // запускаем задачу
    }
    Console.WriteLine("Завершение метода Main");
}

SecondEx3();
/*

Один из возможных консольных выводов программы:

Завершение метода Main

Если необходимо завершить выполнение программы или вообще выполнять некоторый код лишь после того, 
как все задачи из массива завершатся, то применяется метод Task.WaitAll(tasks):

*/
static void SecondEx4()
{
    Task[] tasks = new Task[3];
    for(var i = 0; i < tasks.Length; i++)
    {
        tasks[i] = new Task(() =>
        {
            Thread.Sleep(1000); // эмуляция долгой работы
            Console.WriteLine($"Task{i} finished");
        });
        tasks[i].Start();   // запускаем задачу
    }
    Console.WriteLine("Завершение метода Main");
    
    Task.WaitAll(tasks); // ожидаем завершения всех задач
}

SecondEx4();
/*
В этом случае сначала завершатся все задачи, и лишь только потом будет выполняться последующий код из метода 
Main:

Завершение метода Main
Task3 finished
Task3 finished
Task3 finished

В то же время порядок выполнения самих задач в массиве также недетерминирован.

Также мы можем применять метод Task.WaitAny(tasks). Он ждет, пока завершится хотя бы одна из массива задач.

*/

#endregion
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */