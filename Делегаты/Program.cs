﻿using static Делегаты.Operation;
/*
 * Делегаты.
 * Делегаты представляют такие объекты, которые указывают на методы. 
 * То есть делегаты - это указатели на методы и с помощью делегатов мы можем
 * вызвать данные методы.
 */

/*
 * Определение делегатов.
 * Для объявления делегата используется ключевое слово delegate, после которого идет 
 * возвращаемый тип, название и параметры.
 * delegate void Message();
 * Делегат Message в качестве возвращаемого типа имеет тип void (то есть ничего не возвращает)
 * и не принимает никаких параметров. Это значит, что этот делегат может указывать на 
 * любой метод, который не принимает никаких параметров и ничего не возвращает.
 */

using System.ComponentModel;
using Делегаты;

Message mes;                                // 3) Создание переменной для делегата
mes = Hello;                                // 4) Присваиваем переменной адрес метода
mes();                                      // 5) Вызываем метод через делегат
void Hello() => Console.WriteLine("Hello"); // 1) Метод
// delegate void Message();                 // 2) Обьяление делегата для работы с методом
HelloMessage message1 = Welcome.Print;      // Присваивание делегату метод из класса Welcome
HelloMessage message2 = new Hello().Display;// Присваивание делегату метод из класса Hello
message1();                                 // Вызов метода из делегата
message2();                                 // Вызов метода из делегата
/*
 * В данном случае делегат Operation возвращает значение типа int и имеет два параметра типа 
 * int. Поэтому этому делегату соответствует любой метод, который возвращает значение типа
 * int и принимает два параметра типа int. В данном случае это методы Add и Multiply. 
 * То есть мы можем присвоить переменной делегата любой из этих методов и вызывать.
 * Поскольку делегат принимает два параметра типа int, то при его вызове 
 * необходимо передать значения для этих параметров: operation(4,5).
 */
MathOperation mathOperation = Operation.Add;// Делегат указывает на метод Add
int result = mathOperation(4, 5);           
Console.WriteLine(result);                  // 9
mathOperation = Operation.Multiply;         // Делегат указывает на метод Multiply
result = mathOperation(4, 5);
Console.WriteLine(result);                  // 20
MathOperation mathConstruct = new(Operation.Add); // Так же можно присваивать с помощью конструктора
/*
 * Методы соответствуют делегату, ЕСЛИ ОНИ ИМЕЮТ ОДИН И ТОТ ЖЕ НАБОР ПАРАМЕТРОВ И МОДИФИКАТОРОВ. 
 */

/*
 * Добавление методов в делегат;
 * Делегат может указывать на множество методов, которые имеют ту же сигнатуру и возвращаемые
 * тип. Все методы в делегате попадают в специальный список - список вызова или invocation list.
 * И при вызове делегата все методы из этого списка последовательно вызываются. И мы можем
 * добавлять в этот список не один, а несколько методов. Для добавления методов в делегат 
 * применяется операция +=:
 * Однако стоит отметить, что в реальности будет происходить создание нового объекта делегата, 
 * который получит методы старой копии делегата и новый метод, и новый созданный объект 
 * делегата будет присвоен переменной message.
 * При добавлении делегатов следует учитывать, что мы можем добавить ссылку на 
 * один и тот же метод несколько раз, и в списке вызова делегата тогда будет несколько
 * ссылок на один и то же метод. Соответственно при вызове делегата добавленный метод
 * будет вызываться столько раз, сколько он был добавлен:
 */
void HowAreYou() => Console.WriteLine("How are you?");
Message? message = Hello;
message += HowAreYou;
message += Hello;
/*
 * Подобным образом мы можем удалять методы из делегата с помощью операций -=:
 * При удалении методов из делегата фактически будет создаваться новый делегат,
 * который в списке вызова методов будет содержать на один метод меньше.
 * Стоит отметить, что при удалении метода может сложиться ситуация, что в делегате не 
 * будет методов, и тогда переменная будет иметь значение null. Поэтому в данном случае 
 * переменная определена не просто как переменная типа Message, а именно Message?, то есть
 * типа, который может представлять как делегат Message, так и значение null.
 */
message -= Hello;
/*
 * При удалении следует учитывать, что если делегат содержит несколько ссылок на один и
 * тот же метод, то операция -= начинает поиск с конца списка вызова делегата и удаляет
 * только первое найденное вхождение. Если подобного метода в списке вызова делегата нет,
 * то операция -= не имеет никакого эффекта.
 */
if (message != null) message();

/*
 * Обьеденение делегатов.
 * Делегаты можно обьеденять в другие делегаты.
 */
Message mes1 = Hello;
Message mes2 = HowAreYou;
Message mes3 = mes1 + mes2; // Обьеденение делегатов
/*
 * В данном случае объект mes3 представляет объединение делегатов mes1 и mes2. 
 * Объединение делегатов значит, что в список вызова делегата mes3 попадут все методы
 * из делегатов mes1 и mes2. И при вызове делегата mes3 все эти методы одновременно
 * будут вызваны.
 */
mes3();    // Вызываются все методы из mes1 и mes2

/*
 * Другой способ вызова делегата представляет метод Invoke();
 */
mes.Invoke();   // Hello
Message? nullMessage = null;
//nullMessage();        // ошибка Null
nullMessage?.Invoke();  // Ошибки нет, делегат просто не вызывается.
/*
 * Если делегат должен возвращать некоторое значение то возвращается значение ТОЛЬКО ПОСЛЕДНЕГО
 * метода из списка вызова.
 */
MathOperation multiplyOperation = new(Operation.Substract);
multiplyOperation += Operation.Multiply;
multiplyOperation += Operation.Add;
Console.WriteLine(multiplyOperation(7,2));  // Add (7,2) = 9

/*
 * Обобщенные делегаты.
 * Делегаты, как и другие типы, могут быть обобщенными. 
 */
GenericDelegate<decimal, int> squareOperation = new(Operation.Sqare);
decimal squareResult = squareOperation(5);
Console.WriteLine(squareResult);    // 25
GenericDelegate<int, int> doubleOperation = new(Operation.Double);
int doubleResult = doubleOperation(5);
Console.WriteLine(doubleResult);    // 10

/*
 * Делегаты как параметры методов.
 * Благодаря этому один метод в качестве параметров может получать действия - другие методы. 
 */
/*
 * Здесь метод DoOperation в качестве параметров принимает два числа и некоторое 
 * действие в виде делегата Operation. В внутри метода вызываем делегат Operation,
 * передавая ему числа из первых двух параметров.
 * При вызове метода DoOperation мы можем передать в него в качестве третьего 
 * параметра метод, который соответствует делегату Operation.
 */
void DoOperation(int x, int y, MathOperation paramsDelegate)
{
    Console.WriteLine(paramsDelegate(x,y));
}
DoOperation(5, 4, Add);             // 9

/*
 * Возвращение делегатов из метода.
 * Также делегаты можно возвращать из методов. То есть мы можем возвращать из метода 
 * какое-то действие в виде другого метода.
 */
MathOperation switchMathOperation = SelectOperation(OperationType.Add);
Console.WriteLine(switchMathOperation(10,4));   // 14
switchMathOperation = SelectOperation(OperationType.Substract);
Console.WriteLine(switchMathOperation(10,4));   // 6
switchMathOperation = SelectOperation(OperationType.Multiply);
Console.WriteLine(switchMathOperation(10,4));   // 40

/*
 * В данном случае метод SelectOperation() в качестве параметра принимает перечисление 
 * типа OperationType. Это перечисление хранит три константы, каждая из которых 
 * соответствует определенной арифметической операции. И в самом методе в зависимости 
 * от значения параметра возвращаем определенный метод. Причем поскольку возвращаемый
 * тип метода - делегат Operation, то метод должен возвратить метод, который соответствует 
 * этому делегату - в нашем случае это методы Add, Subtract, Multiply. То есть если 
 * параметр метода SelectOperation равен OperationType.Add, то возвращается метод Add,
 * который выполняет сложение двух чисел:
 */
MathOperation SelectOperation(OperationType enumOperationType)
{
    switch (enumOperationType)
    {
        case OperationType.Add: return Add;
        case OperationType.Substract: return Substract;
        default: return Multiply;
    }
}

/*
 * Здесь делегат Operation типизируется двумя параметрами типов. Параметр T представляет
 * тип возвращаемого значения. А параметр K представляет тип передаваемого в делегат
 * параметра. Таким образом, этому делегату соответствует метод, который принимает параметр
 * любого типа и возвращает значение любого типа.
 */
delegate T GenericDelegate<T, K>(K val);
delegate void Message();

/*
 * При этом делегаты необязательно могут указывать только на методы, которые определены в 
 * том же классе, где определена переменная делегата. Это могут быть также методы из
 * других классов и структур.
 */
delegate void HelloMessage();
enum OperationType
{
    Add, Substract, Multiply
}
class Welcome
{
    public static void Print() => Console.WriteLine("Welcome");
}
class Hello
{
    public void Display() => Console.WriteLine("Привет");
}