﻿using ВозвращениеРезультатаИзАсинхронногоМетода;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

В качестве возвращаемого типа в асинхронном методе должны использоваться типы void, Task, Task<T> или ValueTask<T>

*/

#region void 

/*

При использовании ключевого слова void асинхронный метод ничего не возвращает:

*/
async static void Example()
{
    PrintAsync("Hello World");
    PrintAsync("Hello METANIT.COM");
    
    Console.WriteLine("Main End");
    await Task.Delay(3000); // ждем завершения задач
    
    // определение асинхронного метода
    async void PrintAsync(string message)
    {
        await Task.Delay(1000);     // имитация продолжительной работы
        Console.WriteLine(message);
    }   
}

Example();

/*

Однако асинхронных void-методов следует избегать и следует использовать только там, где эти подобные методы 
представляют единственный возможный способ определения асинхронного метода. Прежде всего, мы не можем 
применить к подобным методам оператор await. Также потому что исключения в таких методах сложно обрабатывать, 
так как они не могут быть перехвачены вне метода. Кроме того, подобные void-методы сложно тестировать.

Тем не менее есть ситуации, где без подобных методов не обойтись - например, при обработке событий:

*/

async static void Example2()
{
    Account account = new Account();
    account.Added += PrintAsync;
    
    account.Put(500);
    
    await Task.Delay(2000); // ждем завершения
    
    // определение асинхронного метода
    async void PrintAsync(object? obj, string message)
    {
        await Task.Delay(1000);     // имитация продолжительной работы
        Console.WriteLine(message);
    }

}

Example2();

/*

В данном случае событие Added в классе Account представляет делегат EventHandler, который имеет тип void. 
Соответственно под это событие можно определить только метод-обработчик с типом void.

*/

#endregion

#region Task

/*

Возвращение объекта типа Task:

*/

async static void Example3()
{
    await PrintAsync("Hello Metanit.com");
    
    // определение асинхронного метода
    async Task PrintAsync(string message)
    {
        await Task.Delay(1000);     // имитация продолжительной работы
        Console.WriteLine(message);
    }
}

Example3();

/*

Здесь формально метод PrintAsync не использует оператор return для возвращения результата. Однако если в 
асинхронном методе выполняется в выражении await асинхронная операция, то мы можем возвращать из метода 
объект Task.

Для ожидания завершения асинхронной задачи можно применить оператор await. Причем его необязательно 
использовать непосредственно при вызове задачи. Его можно применить лишь там, где нам нужно гарантировано 
получить результат задачи или удостовериться, что задача завершена.

*/

async static void Example4()
{
    var task = PrintAsync("Hello Metanit.com"); // задача начинает выполняться
    Console.WriteLine("Main Works");
    
    await task; // ожидаем завершения задачи
    
    // определение асинхронного метода
    async Task PrintAsync(string message)
    {
        await Task.Delay(0);
        Console.WriteLine(message);
    }
}

Example4();

#endregion

#region Task<T>

/*

Метод может возвращать некоторое значение. Тогда возвращаемое значение оборачивается в объект Task, а 
возвращаемым типом является Task<T>:

*/

async static void Example5()
{
    int n1 = await SquareAsync(5);
    int n2 = await SquareAsync(6);
    Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36
    
    async Task<int> SquareAsync(int n)
    {
        await Task.Delay(0);
        return n * n;
    }
}

Example5();

/*

В данном случае метод Square возвращает значение типа int - квадрат числа. Поэтому возвращаемым типом в 
данном случае является типа Task<int>.

Чтобы получить результат асинхронного метода применяем оператор await при вызове SquareAsync:

int n1 = await SquareAsync(5);
Подобным образом можно получать данные других типов:

*/

async static void Example6()
{
    Person person = await GetPersonAsync("Tom");
    Console.WriteLine(person.Name); // Tom
    // определение асинхронного метода
    async Task<Person> GetPersonAsync(string name)
    {
        await Task.Delay(0);
        return new Person(name);
    }

}

Example6();


/*

Опять же получение непосредственных результатов асинхронной задачи можно отложить до того момента, когда они 
непосредственно нужны:

*/

async static void Example7()
{
    var square5 = SquareAsync(5);
    var square6 = SquareAsync(6);
    
    Console.WriteLine("Остальные действия в методе Main");
    
    int n1 = await square5;
    int n2 = await square6;
    Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36
    
    async Task<int> SquareAsync(int n)
    {
        await Task.Delay(0);
        var result = n * n;
        Console.WriteLine($"Квадрат числа {n} равен {result}");
        return result;
    }
}

Example7();

/*

Пример работы программы (ввывод не детерминирован):

Квадрат числа 5 равен 25
Квадрат числа 6 равен 36
Остальные действия в методе Main
n1=25  n2=36

*/


#endregion

#region ValueTask<T>

/*

Использование типа ValueTask<T> во многом аналогично применению Task<T> за исключением некоторых различий в 
работе с памятью, поскольку ValueTask - структура, которая содержит большее количество полей. Поэтому 
применение ValueTask вместо Task приводит к копированию большего количества данных и соответственно 
создает некоторые дополнительные издержки.

Преимуществом ValueTask перед Task является то, что данный тип позволяет избежать дополнительных выделений 
памяти в хипе. Например, иногда требуется синхронно возвратить некоторое значение. Так, возьмем следующий пример:

*/

async static void Example8()
{
    var result = await AddAsync(4, 5);
    Console.WriteLine(result);
    
    Task<int> AddAsync(int a, int b)
    {
        return Task.FromResult(a + b);
    }
}

Example8();

/*

Здесь метод AddAsync синхронно возвращает некоторое значение - в данном случае сумму двух чисел. С помощью 
статического метода Task.FromResult можно синхронно возвратить некоторое значение. Однако использование 
типа Task приведет к выделению дополнительной задачи с сопутствующими выделениями памяти в хипе. ValueTask 
решает эту задачу:

*/

async static void Example9()
{
    var result = await AddAsync(4, 5);
    Console.WriteLine(result);
    
    ValueTask<int> AddAsync(int a, int b)
    {
        return new ValueTask<int>(a + b);
    }
}

Example9();

/*

В данном случае дополнительный объект Task не будет создаваться и соответственно дополнительная память не 
будет выделяться. Поэтому ValueTask обычно применяется, когда результат асинхронной операции уже имеется.

При необходимости также можно преобразовать ValueTask в объект Task с помощью метода AsTask():

*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
record class Person(string Name);