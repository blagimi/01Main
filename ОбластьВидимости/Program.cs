﻿Person tom = new();
tom.PrintName();
tom.PrintSurname();

class Person                            // начало контекста класса
{
    readonly string type = "Person";             // переменная уровня класса
    public void PrintName()             // начало контекста метода PrintName
    {
        string name = "Tom";            // переменная уровня метода

        {                               // начало контекста блока кода
            string shortName = "Tomas"; // переменная уровня блока кода
            Console.WriteLine(type);    // в блоке доступна переменная класса
            Console.WriteLine(name);    // в блоке доступна переменная окружающего метода
            Console.WriteLine(shortName);// в блоке доступна переменная этого же блока
        }                               // конец контекста блока кода, переменная shortName уничтожается

        Console.WriteLine(type);        // в методе доступна переменная класса
        Console.WriteLine(name);        // в методе доступна переменная этого же метода
                                        //Console.WriteLine(shortName); //так нельзя, переменная c определена в блоке кода
                                        //Console.WriteLine(surname);     //так нельзя, переменная surname определена в другом методе

    }       // конец контекста метода PrintName, переменная name уничтожается

    public void PrintSurname()      // начало контекста метода PrintSurname
    {
        string surname = "Smith";   // переменная уровня метода

        Console.WriteLine(type);        // в методе доступна переменная класса
        Console.WriteLine(surname);     // в методе доступна переменная этого же метода 
    }       // конец конекста метода PrintSurname, переменная surname уничтожается

}   // конец контекста класса, переменная type уничтожается