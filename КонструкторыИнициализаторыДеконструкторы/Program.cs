/*
 * Конструкторы выполняют инициализацию объекта.
 * Если в классе определяются свои конструкторы, то он лишается конструктора по умолчанию.
 */

// Создание объектов класса Person с помощью конструктора
using КонструкторыИнициализаторыДеконструкторы;

Person tom = new ();          // Вызов 1го конструктора без параметров 
Person bob = new ("Bob");     // Вызов 2го конструктора с одним параметром
Person sam = new ("Sam", 25); // Вызов 3го конструктора с двумя параметрами
// Вызов метода класса для вывода содержимого объектов
tom.Print();    // Имя: Неивестно Возраст: 18
bob.Print();    // Имя: Bob Возраст: 18
sam.Print();    // Имя: Sam Возраст: 25
DefaultPerson tom3 = new();
DefaultPerson bob3 = new("Bob");
DefaultPerson sam3 = new("Sam", 25);

tom3.Print();
bob3.Print();
sam3.Print();

ThisPerson sam2 = new("Sam", 25);
sam2.Print();

// Вызов инициализатора
Employee alex = new() { name = "Alex", company = { title = "Microsoft" } };
alex.Print();


//Деконструкт
DePerson tomas = new("Tom", 33);
string name;
int age;
tomas.DecPerson(out name, out age);
Console.WriteLine(name);
Console.WriteLine(age);



// Создание класса Person
class Person
{
    // Описание полей класса
    public string name;
    public int age;
    // Создание конструкторов класса
    public Person() { name = "Неизвестно"; age = 18; }      // 1 Конструктор
    public Person(string n) { name = n; age = 18; }         // 2 Конструктор
    public Person(string n, int a) { name = n; age = a; }   // 3 Конструктор
    
    // Создание метода класса для вывода содержимого обьектов класса
    public void Print()
    {
        Console.WriteLine($"Имя: {name} Возраст: {age}");
    }
}
/*
 * Ключевое слово this.
 * Представляет ссылку на текущий экземпляр объекта класса.
 */
class ThisPerson
{
    public string name;
    public int age;
    public ThisPerson() { name = "Неизвестно"; age = 18; }
    public ThisPerson(string name) { this.name = name; age = 18; }
    public ThisPerson(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"Имя: {name} Возраст: {age}");
}
/*
 * Во втором и третьем конструкторе параметры называются также, как и поля класса.
 * Чтобы разграничить параметры и поля класса, к полям класса обращение идёт через ключевое слово this.
 * Так в выражении: this.name = name;
 * первая часть this.name означает что name это поле текущего класса, а не название параметра name.
 * Так же через ключевое слово this можно обращаться к любому полю или методу.
 */

/*
 * Цепочка вызова конструкторов.
 * В этом классе все 3 конструктора выполняют однотипные действия - устанавливают значение
 * полей name и age. Можно не дублировать функциональность конструкторов а обращаться от одного 
 * к другому через ключевое слово this.
 * class Person 
{
    public string name;
    public int age;
    public Person() : this("Неизвестно")    // первый конструктор
    { }
    public Person(string name) : this(name, 18) // второй конструктор
    { }
    public Person(string name, int age)     // третий конструктор
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}
 */

/*
 * В данном примере все конструкторы не определяют других действий кроме как передачи значений
 * третьему конструктору. Поэтому в данном случае проще оставить один конструктор, определив для его 
 * параметров значение по умолчанию.
 */
/*
 * var tom = new Person("Tom", 38);
Console.WriteLine(tom);
 
public class Person(string name, int age)
{
    public Person(string name) : this(name, 18) { }
    public void Print() => Console.WriteLine($"name: {name}, age: {age}");
}
*/

class DefaultPerson(string name = "Неизвестно", int age = 18)
{
    public string name = name;
    public int age = age;

    public void Print() => Console.WriteLine($"Имя: {name} Возраст:{age}");

}
/*
 * Первичные/основные конструкторы.
 * В C#12 добавлена поддержа основных конструкторов. Они позволяют добавлять параметры
 * к определению класса и использовать эти параметры внутри класса.
 */

/*
 * Инициализаторы объектов.
 * Для инициализации объектов можно применять инициализаторы. Они представляют
 * передачу в фигурных скобках значений доступным полям и свойствам объекта.
 */
/*
 * Person tom = new Person { name = "Tom", age = 31 }; или так
 * Person tom = new() {name = "Tom", age = 31};
 * tom.Print(); // Имя: Tom Возраст: 31
 * 
 * С помощью инициализатора можно присваивать значения всем доступным полям и свойствам объкта
 * в момент создания. С помощью инициализатора можно установить значения только доступных
 * из вне класса полей и свойств объекта.
 * Инициализатор выполняется после конструктора, поэтому значения устанавливаемые в конструкторе
 * заменяются значениями из инициализатора. Инициализаторы удобно применять когда поле
 * или свойство класса представляет другой класс.
 * */

/*
 * Деконструкторы позволяют выполнить декомпозицию объекта на отдельные части.
 */
