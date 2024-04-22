using System.ComponentModel.Design;
using System.Threading.Channels;
using ПреобразованиеОбъектовКлассов;
/*
 * В этой иерархии классов мы можем проследить следующую цепь наследования: 
 * Object (все классы неявно наследуются от типа Object) -> Person -> Employee|Client.
 */

/* 
 * Восходящее преобразование.Upcasting
 * Объекты производного типа (который находится внизу иерархии) в то же время представляют 
 * и базовый тип. Например, объект Employee в то же время является и объектом класса Person. 
 * Что в принципе естественно, так как каждый сотрудник (Employee) является человеком (Person)
 */
/*
 * В данном случае переменной person, которая представляет тип Person, присваивается ссылка на объект 
 * Employee. Но чтобы сохранить ссылку на объект одного класса в переменную другого класса, 
 * необходимо выполнить преобразование типов - в данном случае от типа Employee к типу Person. 
 * И так как Employee наследуется от класса Person, то автоматически выполняется неявное восходящее 
 * преобразование - преобразование к типу, которые находятся вверху иерархии классов, то есть 
 * к базовому классу.
 * В итоге переменные employee и person будут указывать на один и тот же объект в памяти, но переменной 
 * person будет доступна только та часть, которая представляет функционал типа Person.
 */
Employee employee = new("Tom", "Microsoft");
Person person = employee;
Console.WriteLine(person.Name);
/* Подобным образом поизводятся и другие восходящие преобразования: 
 * Здесь переменная bob, которая представляет тип Person, хранит ссылку на объект Client, 
 * поэтому также выполняется восходящее неявное преобразование от производного класса 
 * Client к базовому типу Person.
 */
Person _1 = new Client("Bob", "ContosoBank");  // Преобразование от Clien к Person
/* Восходящее неявное преобразование будет происходить и в следующем случае: 
 * Тип object - базовый для всех остальных типов, преобразование к нему будет производиться автоматически.
 */
object _2 = new Employee("Tom", "Microsoft");  // От Employee к object
object _3 = new Client("Bob", "Contosobank");  // От Client к object
object _4 = new Person("Sam");                 // от Person к object

/*
 * Низходящее преобразование. Downcasting 
 * Может возникнуть вопрос, можно ли обратиться к функционалу типа Employee через переменную типа Person. 
 * Но автоматически такие преобразования не проходят, ведь не каждый человек (объект Person) является 
 * сотрудником предприятия (объектом Employee). И для нисходящего преобразования необходимо применить 
 * явное преобразование, указав в скобках тип, к которому нужно выполнить преобразование:
 */
Employee employee1 = new("Tom", "Microsoft");
Person person1 = employee1;             //  Восходящее преобразование от Employee к Person
//Employee employee2 = person1;             Ошибка, необходимо явное преобразование
Employee employee2 = (Employee)person1; //  Низходящее преобразование от Person к Employee
employee2.PrintPerson();
/* Еще несколько примеров */
object obj = new Employee("Bill", "Microsoft");
Employee employee3 = (Employee)obj;     //  Низходящее преобразование от Object к Employee
employee3.PrintPerson();
Person person2 = new Client("Sam", "ContosoBank");
Client client = (Client)person2;        //  Низходящее преобразование от Person к Client
client.PrintPerson();
/* 
 * В первом случае переменной obj присвоена ссылка на объект Employee, поэтому мы 
 * можем преобразовать объект obj к любому типу который располагается в иерархии 
 * классов между типом object и Employee.
 */

/* 
 * Если нам надо обратиться к каким-то отдельным свойствам или методам объекта, 
 * то нам необязательно присваивать преобразованный объект переменной: 
 */
// Преобразование к типу Person для вызова метода Print
((Person)obj).PrintPerson();
// или так ((Employee)obj).PrintPerson();

// Преобразование к типу Employee, что бы получить свойство Company
string company = ((Employee)obj).Company;
Console.WriteLine(company); // Microsoft

/*
 * Необходимо помнить при подобных преобразованиях о наследовании.
 * В данном примере будет ошибка так как переменная obj хранит ссылку на объект
 * Employee. Он так же является объектом типов Object и Person, поэтому можно
 * преобразовать его к этим типам. Но к типу Client его не преобразовать.
*/
// object obj = new Employee("Bill","Microsoft"); // Ранее описан выше
/* Попытка преобразовать его к типу Client для получения названия Банка */
// string bank = ((Client)obj.Bank; // Ошибка
// Еще пример

// Employee employee4 = new Person("Tom"); Ошибка
//Employee employee5 = (Employee)person2;  Ошибка
/* В данном случае мы пытаемся преобразовать объект типа Person к типу Employee, 
 * а объект Person не является объектом Employee. Причем в последнем случае 
 * Visual Studio не подскжет, что в данной строке ошибка, и данная строка даже 
 * нормально скомилируется, тем не менее в процессе выполнения программы 
 * мы получим ощибку. В этом в том числе и кроектся коварство преобразований, 
 * поэтому в подобных ситуациях надо проявлять осторожность.
 * Существует ряд способов, чтобы избежать подобных ошибок преобразования.
*/

/*
 * Способы преобразований.
 * Ключевое слово as.
 * С помощью него программа пытается преобразовать выражение к определенному типу
 * при этом не выбрасывает исключения. В случае неудачи выражение становится null
 */

Person person3 = new("Tom");
Employee? employee4 = person3 as Employee;
if (employee4 == null)  { Console.WriteLine("Преобразование прошло неудачно");}
else                    { Console.WriteLine(employee4.Company); }
/*
 * Переменная employee здесь определяется не просто как переменная Employee, а 
 * именно Employee? - после названия типа ставится вопросительный знак. Что 
 * указывает, что переменная может хранить как значение null, так и значение Employee.
 */

/*
 * Ключевое слово is.
 * Если значение слева от оператора представляет тип указанный справа от оператора
 * то оператор is возвращает true иначе false.
 * При этом оператор is позволяет автоматически преобразовать значение к типу, если
 * это значение представляет данный тип.
 */
Person person4 = new("Sam");
if (person4 is Employee employee5)  { Console.WriteLine(employee5.Company); }
else                                { Console.WriteLine("Преобразование недопустимо"); }
/*
 * Выражение if (person is Employee employee) проверяет является ли переменная
 * person объектом типа Employee. Если да то автоматически преобразует значение
 * переменной person в тип Employee. И преобразованное значение сохраняет в
 * переменную employee. Далее в блоке if мы может использовать объект employee
 * как значение типа Employee. Однако если person не является объектом Employee 
 * то такая проверка вернет false и преобразование не срабоатает.
 * Оператор is так же можно применять и без преобразования, просто проверяя 
 * на соответсвие типу.
 */
Employee employee6 = new("Tom", "Subway");
Person person5 = employee6;
Person person6 = new("Tom");
if (person6 is Employee)
{
    Console.WriteLine("Представляет тип Employee");
}
else { Console.WriteLine("НЕ является объектом типа Employee"); }
Employee employee7 = (Employee)person6;
if (employee7 is Employee)
{
    Console.WriteLine("Представляет тип Employee");
}
else { Console.WriteLine("НЕ является объектом типа Employee"); }

if (employee7 is Employee) { Console.WriteLine("Представляет тип Employee"); }
else { Console.WriteLine("НЕ является объектом типа Employee"); }