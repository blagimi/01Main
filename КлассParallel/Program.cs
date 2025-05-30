﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*

Класс Parallel также является частью TPL и предназначен для упрощения параллельного выполнения кода. Parallel 
имеет ряд методов, которые позволяют распараллелить задачу.

Одним из методов, позволяющих параллельное выполнение задач, является метод Invoke:
*/	
// метод Parallel.Invoke выполняет три метода


static void Example()
{
    Parallel.Invoke(
        Print,
        () =>
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        },
        () => Square(5)
    );
    
    void Print()
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
    }
    // вычисляем квадрат числа
    void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
        Console.WriteLine($"Результат {n * n}");
    }
}

Example();

/*
Метод Parallel.Invoke в качестве параметра принимает массив объектов Action, то есть мы можем передать в 
данный метод набор методов, которые будут вызываться при его выполнении. Количество методов может быть 
различным, но в данном случае мы определяем выполнение трех методов. Опять же как и в случае с классом 
Task мы можем передать либо название метода, либо лямбда-выражение.

И таким образом, при наличии нескольких ядер на целевой машине данные методы будут выполняться параллельно 
на различных ядрах. Пример консольного вывода программы:

Выполняется задача 1
Выполняется задача 3
Выполняется задача 2
Результат 25

*/


#region Parallel.For

/*

Метод Parallel.For позволяет выполнять итерации цикла параллельно. Он имеет следующее определение:

For(int, int, Action<int>)

Первый параметр метода задает начальный индекс элемента в цикле, а второй параметр - конечный индекс. 
Третий параметр - делегат Action - указывает на метод, который будет выполняться один раз за итерацию:
*/	
static void Example2()
{
    Parallel.For(1, 5, Square);
    
    // вычисляем квадрат числа
    void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
        Thread.Sleep(2000);
    }
}

Example2();

/*
В данном случае в качестве первого параметра в метод Parallel.For передается число 1, а в качестве второго - 
число 5. Таким образом, метод будет вести итерацию с 1 до 4 включительно. Третий параметр представляет метод, 
который вычисляет квадрат числа. Так как этот параметр представляет тип Action<int>, то этот метод в качестве 
параметра должен принимать объект int.

А в качестве значения параметра в этот метод передается счетчик, который проходит в цикле от 1 до 4 включительно.
И метод Square, таким образом, вызывается 4 раза. Пример консольного вывода:

Выполняется задача 1
Выполняется задача 2
Квадрат числа 4 равен 16
Выполняется задача 4
Квадрат числа 1 равен 1
Выполняется задача 3
Квадрат числа 3 равен 9
Квадрат числа 2 равен 4



*/

#endregion


#region Parallel.ForEach  

/*
Метод Parallel.ForEach осуществляет итерацию по коллекции, реализующей интерфейс IEnumerable, подобно 
циклу foreach, только осуществляет параллельное выполнение перебора. Он имеет следующее определение:
	
ParallelLoopResult ForEach<TSource>(IEnumerable<TSource> source,Action<TSource> body)

где первый параметр представляет перебираемую коллекцию, а второй параметр - делегат, выполняющийся 
один раз за итерацию для каждого перебираемого элемента коллекции.

На выходе метод возвращает структуру ParallelLoopResult, которая содержит информацию о выполнении цикла.

*/

static void Example3()
{
    ParallelLoopResult result = Parallel.ForEach<int>(
        new List<int>() { 1, 3, 5, 8 },
        Square
    );
    
    // вычисляем квадрат числа
    void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
        Thread.Sleep(2000);
    }

}

Example3();
/*

В данном случае поскольку мы используем коллекцию объектов int, то и метод, который мы передаем в качестве 
второго параметра, должен в качестве параметра принимать значение int. Пример консольного вывода:

Выполняется задача 1
Выполняется задача 3
Квадрат числа 8 равен 64
Выполняется задача 4
Квадрат числа 3 равен 9
Выполняется задача 2
Квадрат числа 5 равен 25
Квадрат числа 1 равен 1

*/
#endregion  


#region Выход из цикла

/*

В стандартных циклах for и foreach предусмотрен преждевременный выход из цикла с помощью оператора 
break. В методах Parallel.ForEach и Parallel.For мы также можем, не дожидаясь окончания цикла, 
выйти из него:

*/	

static void Example4()
{
    ParallelLoopResult result = Parallel.For(1, 10, Square);
    if (!result.IsCompleted)
        Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
    
    // вычисляем квадрат числа
    void Square(int n, ParallelLoopState pls)
    {
        if (n == 5) pls.Break();    // если передано 5, выходим из цикла
    
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
        Thread.Sleep(2000);
    }
}

Example4();

/*
Здесь метод Square, который обрабатывает каждую итерацию, принимает дополнительный параметр - объект 
ParallelLoopState. И если счетчик в цикле достигнет значения 5, вызывается метод Break. Благодаря чему 
система осуществит выход и прекратит выполнение метода Parallel.For при первом удобном случае.

Методы Parallel.ForEach и Parallel.For возвращают объект ParallelLoopResult, наиболее значимыми свойствами 
которого являются два следующих:

    IsCompleted: определяет, завершилось ли полное выполнение параллельного цикла

    LowestBreakIteration: возвращает индекс, на котором произошло прерывание работы цикла

Так как у нас на индексе равном 5 происходит прерывание, то свойство IsCompleted будет иметь значение false, 
а LowestBreakIteration будет равно 5.
*/

#endregion

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */