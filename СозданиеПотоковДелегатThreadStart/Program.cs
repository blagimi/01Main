using System.Threading;

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
Thread myThread4 = new Thread(Print); 
Thread myThread5 = new Thread(new ThreadStart(Print));
Thread myThread6 = new Thread(()=>Console.WriteLine("Hello Threads"));
 
myThread4.Start();  // запускаем поток myThread1
myThread5.Start();  // запускаем поток myThread2
myThread6.Start();  // запускаем поток myThread3
 
void Print2() => Console.WriteLine("Hello Threads");
/*Преимуществом потоком является то, что они могут выполняться одновременно. Например:*/

public delegate void ThreadStart();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

//Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
