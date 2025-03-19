using System;

namespace Семафоры;

public class Reader
{
    // создаем семафор
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;// счетчик чтения
 
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель {i}";
        myThread.Start();
    }
 
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();  // ожидаем, когда освободиться место
 
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
 
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
 
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
 
            sem.Release();  // освобождаем место
 
            count--;
            Thread.Sleep(1000);
        }
    }
}
