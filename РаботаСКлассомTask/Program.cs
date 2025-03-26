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

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */