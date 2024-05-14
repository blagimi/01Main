/*
 * Лямбда-выражения представляют упрощенную запись анонимных методов.
 * Лямбда выражения позволяют создать ёмкие лаконичные методы, которые могут возвращать
 * некотрое значение и которые можно передать в качестве параметров в другие методы.
 * Лямбда-выражения имеют следующий синтаксис: слева от лямбда-оператора => определяется список
 * параметров, а с право блок выражений, использующие эти параметры.
 * (Список параметров) => выражение
 * С точки зрениятипа данных лямбда-выражение представляет делегат.
 */

/*
 * В данном случае переменная hello представляет делегат Message-то есть некоторое действие,
 * которое ничего не возвращает и не принимает никаких параметров. В качестве значения этой переменной
 * присваивается лямбда-выражение. Это лямбда-выражение должно соответствовать делегату Message - оно
 * тоже не принимает никаких параметров, поэтому слева от лямбда-оператора идут пустые скобки. А справа
 * от лямбда-оператора идет выполняемое выражение Console.WriteLine("Hello"); Затем в программе можно
 * вызвать эту переменную как метод.
 */

Message hello = () => Console.WriteLine("Hello");
hello();
hello();
hello();
/*
 * Если лямбда-выражение содержит несколько действий, то они помещаются в фигурные скобки
 */
Message helloWorld = () =>
{
    Console.Write("Hello ");
    Console.WriteLine("World");
};
helloWorld();
/*
 * Лямбда-выражение так же поддерживают неявную типизацию. При неявной типизации компилятор сам 
 * пытается сопоставить лямбда-выражение на основе его определения с каким-нибудь делегатом.
 * В примере по умолчанию компилятор будет рассматривать как переменную встроенного делегата
 * Action, который не принимает никаких параметров и ничего не возвращает.
 */
var helloUndef = () => Console.WriteLine("Hello undef");
helloUndef();
/*
 * Параметры лямбды.
 * При определении списка параметров можно не указывать для них тип данных. В данном случае компилятор
 * видит, что лямбда-выражение sum представляет тип Operation, а значит оба параметра лямбды представляют
 * тип int. Однако если будет использована неявная типизация, то у компилятора могут возникнуть трудности,
 * что бы вывести тип делегата для лямбда-выражения(sum2). В таком случаем можно указать тип параметров
 * (sum3)
 */
Operation sum = (x, y) => Console.WriteLine($"{x}+{y}={x + y}");
//var sum2 = (x,y) => Console.WriteLine($"{x}+{y}={x + y}");  // Ошибка, не удалось вывести тип делегата
var sum3 = (int x,int y) => Console.WriteLine($"{x}+{y}={x + y}");
sum(1, 2);      //  1+2=3
sum(22, 14);    //  22+14=36
sum3(10, 20);   //  10+20=30
/*
 * Если лямбда имеет один параметр, для которого не требуется указывать тип данных, то скобки можно опустить.
 * Так же можно указать значение по умолчанию. (print2)
 */
PrintHandler print = message => Console.WriteLine(message);
var print2 = (string message = "Hello") => Console.WriteLine(message);
print("hello");
print("Welcome");
print2();                   //  Hello
print2("Hello World");      //  Hello World
/*
 * Возвращение результата.
 * Лямбда-выражение может возвращать результат. Возвращаемый результат можно указать после лямбда-оператора.
 */
var resultSum = (int x, int y) => x + y;
int sumResult = resultSum(4, 5);
Console.WriteLine(sumResult);   //  9

Operation2 multiply = (x, y) => x * y;
int multiplyResult = multiply(4, 5);    //  20
Console.WriteLine(multiplyResult);
/*
 * Если лямбда-выражение содержит несколько выражений(или одно в фигурных скобках), то нужно использовать
 * оператор return, как в обычных методах.
 */
var substract = (int x, int y) =>
{
    if (x > y) return x - y;
    else return y - x;
};
int sustractResult1 = substract(10, 6);
Console.WriteLine(sustractResult1);     //  4
int substractResult2 = substract(-10, 6);
Console.WriteLine(substractResult2);    //  16
/*
 * Добавление и удаление действий в лямбда-выражении.
 * Поскольку лямбда-выражение являются делегатом, то как и делегат, в переменную, которая представляет
 * лямбда-выражение можно добавлять методы и другие лямбды.
 */
var hi = () => Console.WriteLine("Hi");
var hiMessage = () => Console.WriteLine("Hello");
hiMessage += () => Console.WriteLine("World");  // Добавляем анонимное лямбда-выражение
hiMessage += hi;    // Добавляем лямбда-выражение из hi
hiMessage += Print; // Добавляем метод
hiMessage();    // Вызываем Hello World Hi Welcome
Console.WriteLine("--------------------");
hiMessage -= Print; // Удаляем метод
hiMessage -= hi; // Удаляем лямбда-выражение
hiMessage?.Invoke(); // invoke на случай если в hiMessage больше нет действий Hello World
static void Print() => Console.WriteLine("Welcome");

/*
 * Лямбда-выражения как аргумент метода.
 * Как и делегаты, лямбда выражения можно передавать параметрам метода, которые представляют делегат.
 * Метод MassSum принимает в качестве параметра массив чисел и делегат IsEqual и возвращает сумму чисел
 * массива в виде объекта int. В цикле проходим по всем числам и складываем их. При этом сложение только
 * для тех числе, для которых делегат возвращает true. Делегат IsEqual тут задает условаие, которому
 * должны соответствовать значения массива. Но на момент написания метода MassSum неизвестно, что это за
 * условие. При вызове метода MassSum ему передается массив и лямбда-выражение. Параметр x представляет 
 * число которое передается в делегат а выражение x>5 представляет условие, которому должно соответствовать
 * число и тогда выражение возвращает true и происхоит сложение.
 */
int[] masIntegers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
// Поиск числе выше 5 и нахождение их суммы
int masResult = MassSum(masIntegers, x => x > 5);
Console.WriteLine(masResult);
// Поиск суммы четных чисел
int masResult2 = MassSum(masIntegers, x => x % 2 == 0);
Console.WriteLine(masResult2);  //  20
static int MassSum(int[] numbers, IsEqual func)
{
    int result = 0;
    foreach (int i in numbers)
    {
        if (func(i))
            result += i;
    }
    return result;
}

/*
 * Лямбда-выражение как результат метода.
 * Метод также может возвращать лямбда-выражение. В этом случае возвращаемым типом метода выступает
 * делегат, которому соотвествует лямбда-выражение.
 */
Operation2 enumOperation1 = SelectOperation(OperationType.Add);
Console.WriteLine(enumOperation1(10,4));    //  14
Operation2 enumOperation2 = SelectOperation(OperationType.Substract);
Console.WriteLine(enumOperation2(10,4));    //  6
Operation2 enumOperation3 = SelectOperation(OperationType.Multiply);
Console.WriteLine(enumOperation3(10,4));    //  40

/*
 * В данном случае метод SelectOperation() в качетве параметра принимает перечисление enum типа OperationType.
 * Оно хранит 3 константы, каждая из которых соответсвует арифметической операции. В самом методе в зависимости
 * от значения параметра возвращается определенное лямбда-выражение.
 */
static Operation2 SelectOperation(OperationType opType)
{
    switch (opType)
    {
        case OperationType.Add: return (x, y) => x + y;
        case OperationType.Substract: return (x, y) => x - y;
        default: return (x, y) => x * y;
    }
}
enum OperationType
{
    Add,Substract,Multiply
}
delegate bool IsEqual(int x);
delegate void PrintHandler(string message);
delegate void Operation(int x,int y);
delegate int  Operation2(int x, int y);
delegate void Message();
