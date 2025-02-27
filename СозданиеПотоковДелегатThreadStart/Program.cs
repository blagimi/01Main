﻿using System.Threading;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Язык C# позволяет запускать и выполнять в рамках приложения несколько потоков, которые 
будут выполняться одновременно.
Для создания потока применяется один из конструкторов класса Thread:
Thread(ThreadStart): в качестве параметра принимает объект делегата ThreadStart, 
который представляет выполняемое в потоке действие
Thread(ThreadStart, Int32): в дополнение к делегату ThreadStart принимает числовое 
значение, которое устанавливает размер стека, выделяемого под данный поток
Thread(ParameterizedThreadStart): в качестве параметра принимает объект делегата 
ParameterizedThreadStart, который представляет выполняемое в потоке действие
Thread(ParameterizedThreadStart, Int32): вместе с делегатом ParameterizedThreadStart 
принимает числовое значение, которое устанавливает размер стека для данного потока
Вне зависимости от того, какой конструктор будет применяться для создания, нам надо 
определить выполняемое в потоке действие. В этой статье рассмотрим использование 
делегата ThreadStart. Этот делегат представляет действие, которое не принимает 
никаких параметров и не возвращает никакого значения:
public delegate void ThreadStart();

*/


/*
То есть под этот делегат нам надо определить метод, который имеет тип void и не 
принимает никаких параметров. Примеры определения потоков:
*/


Thread myThread1 = new Thread(Print); 
Thread myThread2 = new Thread(new ThreadStart(Print));
Thread myThread3 = new Thread(()=>Console.WriteLine("Hello Threads"));
 
void Print() => Console.WriteLine("Hello Threads");

/*
Для запуска нового потока применяется метод Start класса Thread:
*/
 
// создаем новый поток
Thread myThread4 = new Thread(Print2); 
Thread myThread5 = new Thread(new ThreadStart(Print2));
Thread myThread6 = new Thread(()=>Console.WriteLine("Hello Threads"));
 
myThread4.Start();  // запускаем поток myThread1
myThread5.Start();  // запускаем поток myThread2
myThread6.Start();  // запускаем поток myThread3
 
static void Print2() => Console.WriteLine("Hello Threads");
/*Преимуществом потоком является то, что они могут выполняться одновременно. Например:*/

// создаем новый поток
Thread myThread = new Thread(Print3);
// запускаем поток myThread
myThread.Start();
 
// действия, выполняемые в главном потоке
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Главный поток: {i}");
    Thread.Sleep(300);
}
 
// действия, выполняемые во втором потокке
void Print3()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Второй поток: {i}");
        Thread.Sleep(400);
    }
}

/*
Здесь новый поток будет производить действия, определенные в методе Print, то есть 
выводить числа от 0 до 4 на консоль. Причем после каждого вывода производится задержка 
на 400 миллисекунд.

В главном потоке - в методе Main создаем и запускаем новый поток, в котором выполняется
метод Print:
Thread myThread = new Thread(Print);
myThread.Start();

Кроме того, в главном потоке производим аналогичные действия - выводим на консоль числа 
от 0 до 4 с задержкой в 300 миллисекунд.

Таким образом, в нашей программе будут работать одновременно главный поток, 
представленный методом Main, и второй поток, в котором выполняется метод Print. 
Как только все потоки отработают, программа завершит свое выполнение. В итоге 
мы получим следующий консольный вывод:

Главный поток: 0
Второй поток: 0
Главный поток: 1
Второй поток: 1
Главный поток: 2
Второй поток: 2
Главный поток: 3
Второй поток: 3
Главный поток: 4
Второй поток: 4

Подобным образом мы можем создать и запускать и три, и четыре, и целый набор новых 
потоков, которые смогут решать те или иные задачи.
*/



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
