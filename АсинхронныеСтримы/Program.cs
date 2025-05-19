﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Начиная с версии C# 8.0 в C# были добавлены асинхронные стримы, которые упрощают работу с потоками данных 
в асинхронном режиме. Хотя асинхронность в C# существует уже довольно давно, тем не менее асинхронные 
методы до сих пор позволяли получать один объект, когда асинхронная операция была готова предоставить 
результат. Для возвращения нескольких значений в C# могут применяться итераторы, но они имеют синхронную 
природу, блокируют вызывающий поток и не могут использоваться в асинхронном контексте. Асинхронные стримы 
обходят эту проблему, позволяя получать множество значений и возвращать их по мере готовности в асинхронном 
режиме.

По сути асинхронный стрим представляет метод, который обладает тремя характеристиками:

метод имеет модификатор async

метод возвращает объект IAsyncEnumerable<T>. Интерфейс IAsyncEnumerable определяет метод GetAsyncEnumerator, 
который возвращает IAsyncEnumerator:
*/


/*
метод содержит выражения yield return для последовательного получения элементов из асинхронного стрима

Фактически асинхронный стрим объединяет асинхронность и итераторы. Рассмотрим простейший пример:
*/

await foreach (var number in GetNumbersAsync())
{
    Console.WriteLine(number);
}

async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}


/*


Итак, метод GetNumbersAsync() фактически и представляет асинхронный стрим. Этот метод является асинхронным. 
Его возвращаемый тип - IAsyncEnumerable<int>. А его суть сводится к тому, что он возвращает с помощью 
yield return каждые 100 миллисекунд некоторое число. То есть фактически метод должен вернуть 10 чисел 
от 0 до 9 с промежутком в 100 миллисекунд.

Для получения данных из стрима в методе Main используется цикл foreach:

await foreach (var number in GetNumbersAsync())
Важно отметить, что он предваряется оператором await. В итоге, каждый раз когда асинхронный стрим 
будет возвращать очередное число, цикл будет его получать и выводить на консоль.

Где можно применять асинхронные стримы? Асинхронные стримы могут применяться для получения данных 
из какого-нибудь внешнего хранилища. Например, пусть имеется следующий класс некоторого хранилища:
*/


/*
Для упрощения примера данные здесь представлены в виде простого внутреннего массива строк. Для 
имитации задержки в получении применяется метод Task.Delay.

Получим эти данные в программе:

*/

async static void Example()
{
    Repository repo = new Repository();
    IAsyncEnumerable<string> data = repo.GetDataAsync();
    await foreach (var name in data)
    {
        Console.WriteLine(name);
    }
}

 
Example();



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

class Repository
{
    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"Получаем {i + 1} элемент");
            await Task.Delay(500);
            yield return data[i];
        }
    }
}

class Repository2
{
    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"Получаем {i + 1} элемент");
            await Task.Delay(500);
            yield return data[i];
        }
    }
}

public interface IAsyncEnumerable2<out T>   // был конфликт названий с классом поэтому в 
// вызове используется неправильная версия
{
    IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
}
 
public interface IAsyncEnumerator<out T> : IAsyncDisposable
{
    T Current { get; }
    ValueTask<bool> MoveNextAsync();
}
public interface IAsyncDisposable
{
    ValueTask DisposeAsync();
}