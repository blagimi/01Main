/*
Конструкция switch/case оценивает некотрое выражениеи сравнивает его значение с набором значений.
При совпадении вызывает опредленный код.

switch (выражение)
{
    case значение 1:
    код, который выполняется если выражение имеет значение 1
    break
    case значение n:
    код
    break;
    default:
    код выполняемый если значение не имеет ни одно из выше указанных значений
    break;
}
В конце каждого блока case должен ставиться один из операторов перехода:
break, goto case, return, throw
*/
using System.Security.Cryptography;

string name = "Alex";
switch (name)
{
    case "Bob":
    System.Console.WriteLine("Ваше имя - Bob");
    break;
    case "Tom":
    System.Console.WriteLine("Ваше имя - Tom");
    break;
    case "Sam":
    System.Console.WriteLine("Ваше имя - Sam");
    break;
    default:
    System.Console.WriteLine("Неизвестное имя");
    break;
}
int number = 1;
switch (number)
{
    case 1:
        Console.WriteLine("case 1");
        goto case 5; // переход к case 5
    case 3:
        Console.WriteLine("case 3");
        break;
    case 5:
        Console.WriteLine("case 5");
        break;
    default:
        Console.WriteLine("default");
        break;
}

/*
Возвращение значение из switch.
Для возвращение значения может применяться оператор return;
*/
int DoOperation(int op, int a, int b)
{
    switch(op)
    {
        case 1: return a+b;
        case 2: return a-b;
        case 3: return a*b;
        default: return 0;
    }
}
int result1 = DoOperation(1,10,5);  //15
System.Console.WriteLine(result1);
int result2 = DoOperation(3,10,5);  //50
System.Console.WriteLine(result2);

/* 
Модифицируем код выше для получения результата из switch
*/
int DoOperation2(int op, int a, int b)
{
    int result = op switch 
    {
        1 => a+b,
        2 => a-b,
        3 => a*b,
        _ => 0
    };
    return result1;
}
/*
Можно так же сразу возврать результат без присвоения переменной результата switch 
*/
int DoOperation3(int op, int a, int b)
{
    return op switch
    {
        1 => a+b,
        2 => a-b,
        3 => a*b,
        _ => 0
    };
}

/* 
Либо еще укоротить
*/
int DoOperation4(int op, int a, int b) => op switch
{
    1 => a+b,
        2 => a-b,
        3 => a*b,
        _ => 0
};
/* 
Такие упрощения касаются только конструкций switch которые возвращают значения
*/
DoOperation2(1,10,10);
DoOperation3(1,10,10);
DoOperation4(1,10,10);
Console.ReadKey();