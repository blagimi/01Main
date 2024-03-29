﻿/*
Метод может возвращать значение либо какой-то результат.
Методы типа Void не возвращают никакого значения, просто выполняют действия.
Для возвращения значений используется оператор return
*/
static string GetMessage()  // Метод имеет тип string поэтому должен вернуть строку
{
    return "Hello"; // Возвращаемая строка указывается после return
}
// Результат методов которые возвращают значения можно присвоить переменным
// либо использовать любым другим образом в программе
string message = GetMessage();      // Присваиваем переменной значение метода
System.Console.WriteLine(message);  // Hello
// Его так же можно передать в качестве значения в другой метод
void PrintMessage(string message)
{
    System.Console.WriteLine(message);
}
PrintMessage(GetMessage()); // Передача значения одного метода другому в качестве аргумента
// После оператора return можно указывать сложные выражения или вызовы других методов,
// возвращающих определенный результат
static int Sum (int x, int y)
{
    return x + y;
}
int result = Sum(10,15);            //  25
System.Console.WriteLine(result);   //  25
System.Console.WriteLine(Sum(5,6)); //  11
// Сокращенная версия записи int Sum(int x, int y) => x + y;

// Выход из метода
/*
Оператор return не только возвращает значение, но и производит выход из метода.
Поэтому он ставиться ПОСЛЕ выполнения всех инструкций, следующие за ним - НЕ выполнятся 
Поэтому его можно использовать и в методах с типом void для выхода из метода.
*/
static void PrintPerson (string name, int age)
{
    // Если введеный возраст не входит в диапазон
    if (age > 120 || age < 1)
    {
        System.Console.WriteLine("Недопустимый возраст");
        return; // Выходит из метода при неправильном вводе
    }
    System.Console.WriteLine($"Имя: {name} Возраст: {age}");
}

PrintPerson("Tom",37);      //  Tom 37
PrintPerson("Dunkan",1234); //  Недопустимый возраст