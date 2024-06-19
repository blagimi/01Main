using System.Diagnostics;
using ПаттернТипов;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Pattern matching фактически выполняет сопоставление некоторого значения 
с некоторым шаблоном. И если сопоставление прошло успешно, то выполняются 
определенные действия. Язык C# позволяет выполнять различные типы сопоставлений.
Паттерн типов или type pattern позволяет проверить некоторое значение на 
соответствие некоторому типу:
*/

/*
 * Паттерн типов или type pattern позволяет проверить некоторое значение на соотвествие
 * некоторому типу
 * значение is тип переменная_типа
 * Класс Employee представляет работника а класс Manager - менеджера. Оба класса
 * реализуют метод Work. Кроме того, класс Manager определяет свойство IsOnVacation.
 * С помощью паттерна типов проверим, представляет ли объект Employee класс Manager.
 * Здесь в методе UseEmployee значение employee сопоставляется с типом Manager. То есть
 * в данном случае в качестве шаблона выступает тип Manager. Если сопоставление прошло
 * успешно (employee представляет тип Manager) в переменной manager оказывает объект 
 * employee. Далее можно вызвать его методы и свойства.
 */



Employee tom = new Manager();
UseEmployee(tom);
void UseEmployee(Employee employee)
{
    if (employee is Manager manager && manager.IsOnVacation == false)
    {
        manager.Work();
    }
    else { Console.WriteLine("Преобразование недопустимо");  }
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Так же можно использовать constant pattern - сопоставление с некоторой константой.
 */

var message = "hello";
if (message is "hello")
{
    Console.WriteLine("Hello");
}

/*
 * Подобным образом можно проверить значение на null
 */

Employee? bob = new();
Employee? tim = null;

UseEmployee2(bob);
UseEmployee2(tim);

void UseEmployee2(Employee? employee)
{
    if (employee is not null)
        employee.Work();

}

/*
 * Кроме конструкций if сопоставление паттернов может применяться в конструкции switch
 */

Employee bob2 = new();
Employee tom2 = new Manager();
UseEmployee3(bob2);
UseEmployee3(tom2);

void UseEmployee3(Employee? employee)
{
    switch (employee)
    {
        case Manager manager:
            manager.Work();
            break;
        case null:
            Console.WriteLine("Object is null");
            break;
        default:
            Console.WriteLine("Object is not manager");
            break;
    }
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */