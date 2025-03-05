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

/*

При создании потока в конструктор класса Thread передается объект делегата 
ParameterizedThreadStart new Thread(new ParameterizedThreadStart(Print)),
либо непосредственно метод, который соответствует этому делегату 
(new Thread(Print)), в том числе в виде лямбда-выражения 
(new Thread(message => Console.WriteLine(message)))

Затем при запуске потока в метод Start() передается значение, которое передается 
параметру метода Print. И в данном случае мы получим следующий консольный вывод:

Salut
Hello
Привет

При использовании ParameterizedThreadStart мы сталкиваемся с ограничением: мы можем 
запускать во втором потоке только такой метод, который в качестве единственного 
параметра принимает объект типа object?. Поэтому если мы хотим использовать данные 
других типов, в самом методе необходимо выполнить приведение типов. Например:
*/

int number = 4;
// создаем новый поток
Thread myThread = new Thread(Print2);
myThread.Start(number);    // n * n = 16
 
 
// действия, выполняемые во втором потокке
void Print2(object? obj)
{
    // здесь мы ожидаем получить число
    if (obj is int n)
    {
        Console.WriteLine($"n * n = {n * n}");
    }
}


/*

в данном случае нам надо дополнительно привести переданное значение к типу int, 
чтобы его использовать в вычислениях.

Но что делать, если нам надо передать не один, а несколько параметров различного 
типа? В этом случае можно определить свои типы:

*/

Person tom = new Person("Tom", 37);
// создаем новый поток
Thread myThread4 = new Thread(Print3);
myThread4.Start(tom);
 
void Print3(object? obj)
{
    // здесь мы ожидаем получить объект Person
    if (obj is Person person)
    {
        Console.WriteLine($"Name = {person.Name}");
        Console.WriteLine($"Age = {person.Age}");
    }
}
 


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

record class Person(string Name, int Age);