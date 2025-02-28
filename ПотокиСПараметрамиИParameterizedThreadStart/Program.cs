using System.Threading;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

В предыдущей статье было рассмотрено, как запускать в отдельных потоках методы без 
параметров. А что, если нам надо передать какие-нибудь параметры в поток?

Для этой цели используется делегат ParameterizedThreadStart, который передается в 
конструктор класса Thread:

public delegate void ParameterizedThreadStart(object? obj);

Применение делегата ParameterizedThreadStart во многом похоже на работу с 
ThreadStart. Рассмотрим на примере:

*/

// создаем новые потоки
Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
Thread myThread2 = new Thread(Print);
Thread myThread3 = new Thread(message => Console.WriteLine(message));
 
// запускаем потоки
myThread1.Start("Hello");
myThread2.Start("Привет");
myThread3.Start("Salut");
 
 
void Print(object? message) => Console.WriteLine(message);

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */