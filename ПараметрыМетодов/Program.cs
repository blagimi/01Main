/* Параметры позволяют передать в метод некоторые входные данные. Параметры определяются 
 * через заятую в скобках после названия метода в виде:
*  тип_метода имя_метода(тип_параметра1 параметр1, тип_параметра2 параметр2, ...)
*  {
*    // действия метода
*  } 
*/
using System.Security.AccessControl;

static void PrintMessage (string message)
{
    Console.WriteLine(message);
}
PrintMessage("HelloWorld");
// Метод складывающий 2 числа
static void Sum(int x, int y)   // Передача методу 2х чисел в качестве параметров
{
    int result = x + y;   // Сложение аргументов 2х параметров
    System.Console.WriteLine($"{x}+{y} = {result}");    // Вывод на экран аргументы и результат сложения
}
Sum(10,15); // 10 + 15 = 25

/* Укороченная запись методов
*  void Sum (int x, int y) => Console.WriteLine($"{x}+{y}={x+y}") 
*/

/*
* Передаваемые параметру значения могут представлять значения переменных
* или результат работы сложных выражений, которые возвращают значение.
*/
int a = 10, b = 15, c = 6;
Sum (a,b);      // 10 + 15 = 25
Sum (3,c);      //  3 + 6 = 9
Sum (14, 4+c);  //  14 + 10 = 24

// При передачи параметров нужно учитывать тип параметров между аргументами и параметрами, они должны быть равны.
static void PrintPerson (string name, int age)
{
    System.Console.WriteLine($"Name: {name} Age: {age}");
}

PrintPerson ("Tom", 24);    // Name: Tom Age: 24

// Необязательные параметры
// Параметры значение которые присвоенно по умолчанию и использует их при остуствии передачи аргументов
static void PrintEmploye (string name, int age = 1, string company = "Undefined")
{
    System.Console.WriteLine($"Name: {name} Age: {age} Company: {company}");
}

PrintEmploye("Tom", 37, "Microsoft");   //  Tom 37  Microsoft
PrintEmploye("Tom",37);                 //  Tom 37  Undefined
PrintEmploye("Tom");                    //  Tom 1   Undefined

//  Именованные параметры
//  Используются для передачи аргументов по имени а не по порядку
PrintEmploye(age: 41, name: "Bob");                 // Bob 41 Undefined
PrintEmploye("Tom",company:"Microsoft", age: 37);   // Tom 37 Microsoft
PrintEmploye(company:"Google", name:"Sam");         // Sam 1  Google

