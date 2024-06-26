﻿using System.Diagnostics;
using Обобщения;
Stopwatch startTime = new();
startTime.Start();
/*
 * Обобщения (generics).
 * Нередко для идентификатора используются и строковые значения. И у числовых, 
 * и у строковых значений есть свои плюсы и минусы. И на момент написания класса
 * мы можем точно не знать, что лучше выбрать для хранения идентификатора - 
 * строки или числа. И что бы не сталкиваться с такими явлениями как упаковка 
 * (boxing) и распаковка (unboxing).
 */

/*
 * Упаковка (boxing) предполагает преобразование объекта значимого типа 
 * (например, типа int) к типу object. При упаковке общеязыковая среда
 * CLR обертывает значение в объект типа System.Object и сохраняет его в 
 * управляемой куче (хипе). Распаковка (unboxing), наоборот, предполагает 
 * преобразование объекта типа object к значимому типу. Упаковка и распаковка 
 * ведут к снижению производительности, так как системе надо осуществить 
 * необходимые преобразования.Кроме того, существует другая проблема - проблема
 * безопасности типов. Мы можем не знать, какой именно объект представляет Id, 
 * и при попытке получить число в данном случае мы столкнемся с исключением 
 * InvalidCastException. Причем с исключением мы столкнемся на этапе 
 * выполнения программы.
 */

/*
 * Для решения этих проблем в язык C# была добавлена поддержка обобщенных типов
 * (также часто называют универсальными типами). Обобщенные типы позволяют
 * указать конкретный тип, который будет использоваться. Поэтому определим класс 
 * Person как обощенный:
 */

/*
 * Например, вместо параметра T можно использовать объект int, то есть число,
 * представляющее номер пользователя. Это также может быть объект string, 
 * либо или любой другой класс или структура. Поскольку класс Person является 
 * обобщенным, то при определении переменной после названия типа в угловых 
 * скобках необходимо указать тот тип, который будет использоваться вместо
 * универсального параметра T. В данном случае объекты Person типизируются 
 * типами int и string.
 * Поэтому у первого объекта tom свойство Id будет иметь тип int, а у объекта 
 * bob - тип string. И в случае с типом int упаковки происходить не будет.При 
 * попытке передать для параметра id значение другого типа мы получим ошибку 
 * компиляции. А при получении значения из Id нам больше не потребуется операция
 * приведения типов и распаковка тоже применяться не будет.
 */
Person<int,string> tom = new(546,"qwerty", "Tom");
Person<string,string> bob = new("abc123","qwerty", "Bob");
/*
 * Тем самым мы избежим проблем с типобезопасностью. Таким образом, используя 
 * обобщенный вариант класса, мы снижаем время на выполнение и количество 
 * потенциальных ошибок.
 */
Console.WriteLine(tom.Id);              // 546
Console.WriteLine(bob.Id);              // abc123
/*
 * При этом универсальный параметр также может представлять обобщенный тип.
 * Здесь класс компании определяет свойство CEO, которое хранит президента 
 * компании. И мы можем передать для этого свойства значение типа Person, 
 * типизированного каким-нибудь типом:
 */
Company<Person<int,string>> microsoft = new(tom);
Console.WriteLine(microsoft.CEO.Id);    //  546
Console.WriteLine(microsoft.CEO.Name);  //  Tom

/*
 * Статические поля обобщенных классов.
 * При типизации обобщенного класса определенным типом будет создаваться свой 
 * набор статических членов. Например в Person поле code которое в программе типизируется
 * двумя типами int и string. В итоге для каждого типа будет созадана своя переменная
 * code
 */
Person<int,string>.code = 1234;
Person<string,string>.code = "meta";
Console.WriteLine(Person<int,string>.code);    // 1234
Console.WriteLine(Person<string,string>.code); //  meta
startTime.Stop();
var time = startTime.Elapsed;
string elapsedTime = string.Format($"часов:{time.Hours},минут:{time.Minutes},секунд:{time.Seconds},милисекунд{time.Milliseconds}");
Console.WriteLine($"Выполнение заняло\n" + elapsedTime); ;

/*
 * Использование нескольких универсальных параметров.
 * Обобщения могут использовать несколько универсальных параметров одновременно, которые
 * могут представлять одинаковые или различные типы.
 * Тут класс Person использует два универсальных параметра: один параметр для идентификатора
 * другой параметр - для свойства-пароля. Объект Person типизируется int и string. В качестве
 * универсального параметра T используется int, а для параметра K тип string
 */
Person<int, string> tim = new(123, "qwerty", "Tim");
Console.WriteLine($"{tim.Id},{tim.Password},{tim.Name}");

/*
 * Обобщенные методы.
 * Так же можно создавать обобщенные методы, которые будут использовать универсльные параметры.
 * Метод Swap, принимает параметры по ссылке и меняет их значения. При этом неважно, какой тип
 * представляют эти параметры. При вызове метода Swap типизируем его определенным типом и 
 * передаем ему соответсвующее этому типу значение. 
 */
int x = 7;
int y = 25;
Swap<int>(ref x, ref y);
Console.WriteLine($"x={x} y={y}");  // x = 25 y = 7

static void Swap<T>(ref T x, ref T y)
{
    (y, x) = (x, y);
}

ObjectsHolder<int> massive = new();