/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Обработка ошибок в асинхронных методах, использующих ключевые слова async и await, имеет свои особенности.

Для обработки ошибок выражение await помещается в блок try:

*/

async static void  Example()
{
    try
    {
        await PrintAsync("Hello METANIT.COM");
        await PrintAsync("Hi");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
    async Task PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(100);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example();

/*

В данном случае асинхронный метод PrintAsync генерирует исключение ArgumentException, если методу передается 
строка с длиной меньше 3 символов.

Для обработки исключения в методе Main выражение await помещено в блок try. В итоге при выполнении вызова 
await PrintAsync("Hi") будет сгенерировано исключение, что привет к генерации исключения. Однако программа 
не остановит аварийно свою работу, а обработает исключение и продолжит дальнейшие вычисления.

Консольный вывод программы:

Hello METANIT.COM
Invalid string length: 2
Следует учитывать, что если асинхронный метод имеет тип void, то в этом случае исключение во вне не 
передается, соответственно мы не сможем обработать исключение при вызове метода:

*/

async static void Example2()
{
    try
    {
        PrintAsync("Hello METANIT.COM");
        PrintAsync("Hi");       // здесь программа сгенерирует исключение и аварийно остановится
        await Task.Delay(1000); // ждем завершения задач
    }
    catch (Exception ex)    // исключение НЕ будет обработано
    {
        Console.WriteLine(ex.Message);
    }
    
    async void PrintAsync(string message)
    {
        // если длина строки меньше 3 символов, генерируем исключение
        if (message.Length < 3)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(100);     // имитация продолжительной операции
        Console.WriteLine(message);
    }
}

Example2();

/*

В данном случае, не смотря на то, что асинхронные методы вызываются в блоке try, исключение не будет перехвачено 
и обработано. В этом один из минусов применения асинхронных void-методов. Правда, в этом случае мы можем 
определить обработку исключения в самом асинхронном методе:

*/

async static void Example3()
{
    PrintAsync("Hello METANIT.COM");
    PrintAsync("Hi");
    await Task.Delay(1000); // ждем завершения задач
    
    async void PrintAsync(string message)
    {
        try
        {
            // если длина строки меньше 3 символов, генерируем исключение
            if (message.Length < 3)
                throw new ArgumentException($"Invalid string length: {message.Length}");
            await Task.Delay(100);     // имитация продолжительной операции
            Console.WriteLine(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
    }
}

Example3();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */