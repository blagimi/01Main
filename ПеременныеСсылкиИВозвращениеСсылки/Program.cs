﻿
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Переменные-ссылки и возвращение ссылки.
Кроме параметров метода, которые с помощью модификатора ref позволяют передавать
значение по ссылке C# так же позволяет с помощью ключевого слова ref возвращать ссылку из
метода и определять переменную, которая будет хранить ссылку.
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Переменная-ссылка.
Для определения локальной переменной-ссылки (ref local) перед её типом ставиться 
ключевое слово ref: Здесь переменная xRef указывает не просто на значение переменной x
а на область в памяти, где распологается эта переменная. Для этого перед х так же 
указывается ref.
При этом нельзя просто определить переменную-ссылку, нужно обязательно присвоить ей
какое-то значение.
*/

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

int x = 5;
ref int xRef = ref x;
//ref int yRef;                             //  Ошибка

/*
Получив ссылку, можно манипулировать значением по этой ссылке.
*/
Console.WriteLine(x);                       //  5
xRef = 125;
Console.WriteLine(x);                       //  125
x = 625;
Console.WriteLine(xRef);                    //  625                                        

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Ссылка как результат функции.
Для возвращения из функции ссылки в сигнатуре функции перед возвращаемым типом, а также
после оператора return следует указать ключевое слово ref:
В методе Find ищем число в массиве, но вместо самого значения числа возвращаем ссылку на
него в памяти. Для этого в сигнатуре метода в качестве типа результата функции указывается
не просто int а ref int, кроме того в самом методе после слова return ставится ref.
Тем самым получаем не просто значение а ссылку на объект в памяти.
В методе Main для определения переменной, которая будет содержать ссылку, используется
ключевое слово ref. При вызове метода так же указывается слово ref.
ref int numberRef = ref Find(7, numbers);
В итоге переменная numberRef будет содержать ссылку на объект int и через данную 
переменную в последствии можно изменить объект по этой ссылке.
*/

int[] numbers = {1,2,3,4,5,6,7};
ref int numbersRef = ref Find(4,numbers);   //  Ищем число 4 в массиве
numbersRef = 9;                             //  Заменяем 4 на 9
Console.WriteLine(numbers[3]);              //  9

ref int Find (int number, int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] == number)
        {
            return ref numbers[i];          //  Возвращение ссылки на адрес а не само значение
        }
    }
    throw new Exception("Число не найдено");
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */    

/*
Другой пример возвращение ссылку на максимальное число из двух.
Стоит обратить внимание, что параметры метода в этом случае определены с ключевым 
словом ref. При определении метода, который возвращает ссылку, следует учитывать, что 
такой метод естественно не может иметь тип void. Кроме того, такой метод не может возвращать:
- Значение null
- Константу
- Значение перечисления enum
- Свойство класса или структуры
- Поле для чтения (которое имеет модификатор read-only)
*/

int a = 5;
int b = 8;
ref int pointer = ref Max(ref a, ref b);
pointer = 34;
Console.WriteLine($"a={a}, b={b}");

ref int Max(ref int n1, ref int n2)
{
    if (n1>n2) return ref n1;
    else return ref n2;
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */    



Console.ReadLine();