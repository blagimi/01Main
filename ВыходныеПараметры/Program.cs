// Выходные параметры. Модификатор out
/* 
Параметры помимо входных, которые передаются методу. Так же могут быть и выходными. 
Что бы сделать параметр выходным, перед ним ставится модификатор out
*/

static void Sum (int x, int y, out int result)
{
    // При указании выходного параметров он обязательно должен быть указан в методе
    result = x + y; 
}
int number;
Sum(10,15, out number);
System.Console.WriteLine(number);   // 25
// Возвращение из метода нескольких значений
/*
Метод GetRectangleData который получает ширину и высоту прямоугольника (параметры width и height)
Выходные параметры мы используем для подсчёта площади и периметра прямоугольника
*/
static void GetRectangleData(int width, int height, out int rectArea, out int rectPerimetr)
{
    rectArea = width * height;          // Площадь прямоугольника - произвидение ширины на высоту
    rectPerimetr = (width+height)*2;    // Периметр прямоугольника - сумма длин всех сторон
}
int area;
int perimetr;
GetRectangleData(10,20, out area, out perimetr);
System.Console.WriteLine($"Площадь прямоугольника: {area}");        //  200
System.Console.WriteLine($"Периметр прямоугольника: {perimetr}");   // 60
/*
При этом можно опеределять переменные которые передаются out-параметрам при вызове метода.
GetRectangleData(10,20, out int area, out int perimetr);
Так же если неизвестен тип который будет присвоен параметрам то можно их определить используя var
GetRectangleData(10,20, out var area, out var perimetr);
*/
// Входные параметры.
// Модификатор In
static void GetRectangleData2(in int width, in int height, out int rectArea, out int rectPerimetr)
{
    //width = 25; Невозможно изменить передаваемоё значение, аргумент передаётся в параметр только для чтения
    rectArea = width * height;
    rectPerimetr = (width+height)*2;
}
int w = 10;
int h = 20;
GetRectangleData2(w,h, out var area2, out var perimetr2);
System.Console.WriteLine($"Площадь прямоугольника: {area2}");        //  200
System.Console.WriteLine($"Периметр прямоугольника: {perimetr2}");   // 60
/*
Передаа по ссылке в некоторых случаях может увеличить производительность а использование оператора in
гарантирует что значение переменных которые передаются параметрам нельзя будет изменить в этом методе. 
*/
// ref-параметры только для чтения
/*
Передача по ссылке имеет возможность изменять значение ref- параметра. Однако иногда это может быть нежелательно.
Что бы гарантировать что ref-параметр не изменит своего значения можно применять ref-параметр только для чтения.
Такие параметры описываются ключевым словом readonly
*/
void ReadonlyIncrement (ref readonly int n)
{
    // n++; Невозможно провести операцию инкремента, параметр только для чтения
    System.Console.WriteLine($"Число в методе ReadonlyIncrement: {n}");                 //  5
}
int readonlyNumber = 5;
Console.WriteLine($"Число до метода Increment: {readonlyNumber}");                      //  5
ReadonlyIncrement (ref readonlyNumber);
System.Console.WriteLine($"Число после метода ReadonlyIncrement: {readonlyNumber}");    //  5
/*
В данном случае в метод ReadonlyIncrement параметр n передаётся по ссылке только для чтения.
При попытке изменить его значение мы получим ошибку. 
*/


Console.ReadKey();