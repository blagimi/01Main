/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Делегаты Action, Predicate и Func.
 * В .NET есть несколько встроенных делегатов, которые используются в различных 
 * ситуациях. И наиболее используемыми, с которыми часто приходится сталкиваться, 
 * являются Action, Predicate и Func.
 */
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Action.
 * Делегат Action представляет некоторое действие, которое ничего не возвращает, то есть
 * в качестве возвращаемого типа имеет тип void. Данный делегат имеет ряд перегруженных 
 * версий. Каждая версия принимает разное число параметров: от Action<in T1>до Action
 * <in T2,... in T16>Таким образом можно передать до 16 значений в метод. 
 * Как правило этот делегат передается в качестве параметра метода и предусматривает
 * вызов определенных действий в ответ на произошедшие действия.
 */
DoOperation(10, 6, Add);        //  10+6=16
DoOperation(10, 6, Multiply);   //  10*6=60
void DoOperation(int a, int b, Action<int, int> op) => op(a, b);
void Add(int x, int y) => Console.WriteLine($"{x}+{y}={x + y}");
void Multiply(int x, int y) => Console.WriteLine($"{x}*{y}={x * y}");
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Predicate.
 * Принимает один параметр и возвращает значение типа bool. 
 * Как правило, используется для сравнения, сопоставления некоторого объекта T
 * определенному условию. В качестве выходного результата возвращается значение
 * true, если условие соблюдено, и false, если не соблюдено. 
 */
Predicate<int> isPositive = (int x) => x > 0;
Console.WriteLine(isPositive(20));      //  True
Console.WriteLine(isPositive(-20));     //  False

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Func.
 * Возвращает результат действия и может принимать параметры. Так же имеет различные
 * формы: от Func<out T> где T тип возвращаемого значения, до Func<in T1, in T2...in T16
 * ,out TResult>(). т.е тоже может принимать до 16 параметров. Данный делегат часто 
 * используется в качестве параметра в методах.
 */
int result1 = DoOperation2(6, DoubleNumber);    //  12
Console.WriteLine(result1);
int result2 = DoOperation2(6, SquareNumber);     //  36
Console.WriteLine(result2);
/*
 * Метод DoOperation2() в качестве параметра принимает делегат Func<int,int> то есть 
 * ссылку на метод, который принимает число int и возвращает так же значение int.
 * При первом вызове метода DoOperation2() ему передается ссылку на метод DoubleNumber
 * который увеличивает число в 2 раза. Во втором случае передается метод SquareNumber
 * опять же метод, который принимает параметр типа int и возвращает результат в виде 
 * значения int.
 */
int DoOperation2(int n, Func<int,int> operation) => operation(n);
int DoubleNumber(int n) => n * 2;
int SquareNumber(int n) => n * n;
/*
 * Еще один пример.
 * Тут переменная createString представляет лямбда-выражение, которое принимает 2 
 * числа int и возвращает string, т.е представляет делегат Func<int,int,out string>
 */
Func<int, int, string> createString = (a, b) => $"{a}{b}";
Console.WriteLine(createString(1,5));   //  15
Console.WriteLine(createString(3,5));   //  35

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Список используемых делегатов.
 */
public delegate void Action();
public delegate void Action<in T>(T obj);
public delegate bool Predicate<in T>(T obj);
public delegate TResult Func<out TResult>();
public delegate TResult Func<in T, out TResult>(T arg);
public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
public delegate TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

