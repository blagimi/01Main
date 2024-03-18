/*
Перечисление - набор логически связанных констант.
Обьявление происходит с помощью оператора enum
enum название перечисления
{
    //значения перечисления
    значение 1,
    значение 2,
    ...
    значение n
}
*/

/*
Здесь определено перечисление DayTime которое имеет четыре значения
Каждое перечисление фактически определяет новый тип данных с помощью которых, можно определять переменные
константы, параметры методов и т.д. В качестве значения переменной, константы и параметра метода, которые 
представляют перечисление, должна выступать одна из констант этого перечисления*/

/*
Хранение состояния.
Зачастую переменная перечисления выступает в качестве хранилища состояния,
в зависимости от которого производятся некоторые действия.
*/

DayTime now = DayTime.Evening;
PrintMessage(now);                  // Добрый вечер
PrintMessage(DayTime.Afternoon);    // Добрый день
PrintMessage(DayTime.Night);        // Доброй ночи

MathOperation(10,5,Operation.Add);      //  15
MathOperation(10,5,Operation.Subtract); //  5
MathOperation(10,5,Operation.Multiply); //  50
MathOperation(10,5,Operation.Divide);   //  2
Console.ReadKey();

void PrintMessage(DayTime dayTime)
{
    switch (dayTime)
    {
        case DayTime.Morning:
        System.Console.WriteLine("Доброе утро");
        break;
        case DayTime.Afternoon:
        System.Console.WriteLine("Добрый день");
        break;
        case DayTime.Evening:
        System.Console.WriteLine("Добрый вечер");
        break;
        case DayTime.Night:
        System.Console.WriteLine("Доброй ночи");
        break;
    }
}

void MathOperation(double x, double y, Operation operation)
{
    double result = operation switch
    {
        Operation.Add => x + y,
        Operation.Subtract => x - y,
        Operation.Multiply => x * y,
        Operation.Divide => x / y,
        _ => throw new NotImplementedException()
    };
    System.Console.WriteLine(result);
}

enum DayTime    //  Время суток
{
    Morning,    //  Утро
    Afternoon,  //  День
    Evening,    //  Вечер
    Night       //  Ночь
}

enum Operation  //  Математические операции
{
    Add,        //  Сложение
    Subtract,   //  Вычитание
    Multiply,   //  Умножение
    Divide      //  Деление
}

/*
Константы перечисления могут иметь тип.
Тип указывается после названия перечисления через двоеточие.
Тип перечисления ОБЯЗАТЕЛЬНО должен представлять целочисленный тип
byte,sbyte,short,ushort,int,uint,long,ulong. По умолчанию int.
Тип влияет на значения которые могут иметь константы. По умолчанию каждому элементу перечисления присваивается
целочисленное значение, первый элемент которого будет 0, второго 1.
DayTime now = Daytime.Morning;
Console.WriteLine((int)now);            //  0
Console.WriteLine((int)DayTime.Night);  //  3

Enum DayTime
{
    Morning,
    Afternoon,
    Evening,
    Night
}
Можно использовать операцию приведения что бы получить целочисленное значение константы
(int) DayTime.Night //  3
В то же время несмотря на это мы не можем присвоить ей числовое значение
DayTime now = 2;    // Ошибка
Но можно указать их значения при инициализации
enum DayTime
{
    Morning = 3,    // каждый следующий элемент по умолчанию увеличивается на единицу
    Afternoon,      // этот элемент равен 4
    Evening,        // 5
    Night           // 6
}
Но можно и для всех элементов явным образом указать значения:
enum DayTime
{
    Morning = 2,
    Afternoon = 4,
    Evening = 8,
    Night = 16
}
При этом константы перечисления могут иметь одинаковые значения
либо даже можно присваивать одной константе значение другой константы:
enum DayTime
{
    Morning = 1,
    Afternoon = Morning,
    Evening = 2,
    Night = 2
}
*/


enum Time : byte
{
    Morning,
    Afternoon,
    Evening,
    Night
}
