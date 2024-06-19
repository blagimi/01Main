using System.Threading.Channels;
using ПаттернСвойств;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Паттерн свойств позволяет сравнивать со значениями определенных свойств объект. 
 * Например в зависимости от языка пользователя выведем ему определенное сообщение,
 * применив паттерн свойств.
 * Здесь метод SayHello в качестве параметра принимает объект Person и сопоставляет 
 * его с некоторым паттерном. В качестве парттерна выступает выражение проверки языка
 * т.е параметр person должен представлять объект Person, у которого значение свойства
 * Language равно "French". При этом можно добавить проверку по свойству Status
 */



Person tom = new() { Language = "English", Status = "User", Name = "Tom" };
Person pierre = new() { Language = "French", Status = "User", Name = "Pierre" };
Person admin = new () { Language = "English", Status = "Admin", Name = "Admin" };
Person germanAdmin = new() { Language = "German", Status = "Admin", Name = "germanAdmin" };

SayHello(tom);
SayHello(pierre);
SayHello(admin);

static void SayHello(Person person)
{
    if (person is Person { Language: "French" })
    {
        Console.WriteLine("Salut");
    }
    else if (person is Person { Language: "English", Status: "Admin" })
    {
        Console.WriteLine("Hello, Admin");
    }
    else
    {
        Console.WriteLine("Hello");
    }
}

/*
 * Подобным образом можно применять паттерн свойст в конструкции switch.
 * Паттерны свойств предполагают использование фигурных скобок, внутри которых 
 * указываются свойства и через двоеточие их значение {свойство: значение}. 
 * И со значением свойства в фигурных скобках сравнивается свойство передаваемого
 * объекта. При этом в фигурных скобках мы можем указать несколько свойств и их
 * значений { Language: "german", Status: "admin" } - тогда свойства передаваемого
 * объекта должны соответствовать всем этим значениям.
 * Кроме того, мы можем определять в паттерных свойств переменные, передавать этим 
 * переменным значения объекта и использовать при возвращении значения:
 *  { Language: "french", Name: var name } => $"Salut, {name}!",
 * Так подвыражение говорит что надо передать в переменную name значение свойства
 * Name. Затем ее можно применить при генерации выходного значения.
 *                                                      //  Person
 */
Console.WriteLine(GetMessage(tom));
Console.WriteLine(GetMessage(pierre));
Console.WriteLine(GetMessage(admin));
Console.WriteLine(GetMessage(germanAdmin));

static string GetMessage(Person? person) => person switch
{
    { Language: "English" } =>  "Hello",
    { Language: "German", Status: "Admin" } => "Hallo, admin",
    { Language: "french", Name: var name } => $"Salut, {name}!",
    { Language: var lang } => $"Unknown language: {lang}",
    null => "null"
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Начиная с C#10 было упрощено сопоставление со свойствами вложенных объектов.
 * Класс Company определяет свойство Title, которое хранит название компании. Класс 
 * Employee определяет сотрудниа компании и в свойстве Company хранит компанию.
 * Применим паттерн свойств на основе вложенного объекта Company.
 * В методе PrintCompany объект employee cопоставляется с паттерном Employee{Company:
 * Title:"Microsoft"}}. Т.е сотрудник компании должен представлять объект Employee,
 * у которого название компании равно "Microsoft", однако его можно сократить.
 * if (employee is Employee {Company.Title: "Microsoft"})
 *                                                      //  Company, Employee
 */

var microsoft = new Company("Microsoft");
var google = new Company("Google");
var tom2 = new Employee("Tom", microsoft);
var bob2 = new Employee("Bob", google);

PrintCompany(tom2);
PrintCompany(bob2);

static void PrintCompany (Employee employee)
{
    if (employee is Employee { Company: { Title: "Microsoft"} })
    {
        Console.WriteLine($"{employee.Name} work in Microsoft");
    }
    else
    {
        Console.WriteLine($"{employee.Name} work someware");
    }
}




/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */