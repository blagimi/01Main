/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Приминение интерфейсов.
 * Интерфейс представляет описание типа, набор компонентов, который должен иметь тип
 * данных. Создать объекты интерфейса напрямую с помощью конструктора нельзя. Он 
 * предназначен для реализации в классах и структурах. Если методы и свойства интерфейса
 * не имеют модификатора доступа, то по умолчанию они являются public, при реализации
 * в классе и структуре к ним применяется модификатор public.
 */
Person person = new();
Car car = new();
DoAction(person);       // Человек идет
DoAction(car);          // Машина едет

IMovable2 tom = new Person2();  // Использование метода по умолчанию из интерфейса
Car tesla = new();
tom.Move();             // Walking
tesla.Move();           // Машина едет
//Person2 tim = new();
//tim.Move();              Ошибка метод Move не определен в классе Person2
/*
 * Метод DoAction() который в качестве параметра принимает объект интерфейса. На момент
 * написания кода можно не знать что это будет за объект, класс или структура. Он
 * должен быть обязательно реализован что бы его можно было вызвать. Иными словами
 * Интерфейс - это контракт, что какой-то определенный тип обязательно реализует
 * некоторый функционал.
 */
static void DoAction(IMovable movable) => movable.Move();

/*
 * В данном случае определены 2 интерфейса. IMessage определяет Text, который
 * представляет текст сообщения. А интерфейсы IPrintable определяет метод
 * Print. Класс Message реализует оба интерфейса и замем применяет их.
 */
Message hello = new("Hello world");
hello.Print();  // Hello world

/*
 * Интерфейсы в преобразованиях типов.
 * Интерфейсы полностью поддерживают преобразования. Поскольку класс Message 
 * реализует IMessage, то переменная типа IMessage может хранить ссылку на 
 * объект типа Message.
 */
IMessage hello2 = new Message("Hello");
Console.WriteLine(hello2.Text);
// Не все объекты IMessage являются объектами Message, необходимо явное приведение
// Message someMessage = hello; // ! Ошибка

// Интерфейс IMessage не имеет свойства Print, необходимо явное приведение
// hello.Print();  // ! Ошибка

// если hello представляет класс Message, выполняем преобразование
if (hello2 is Message someMessage) someMessage.Print();

interface IMovable
{
    void Move();
}
interface IMovable2
{
    void Move() // Реализация интерфейса значением по умолчанию
    {
        Console.WriteLine("Walking");
    }
}
class Person : IMovable
{
    public void Move()
    {
        Console.WriteLine("Человек идёт");
    }
}
class Person2 : IMovable2 { }
class Car : IMovable
{
    public void Move()
    {
        Console.WriteLine("Машина едет");
    }
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Множественная реализация интерфейсов.
 * Интерфейсы поддерживают множенственное наследование, все реализуемые интерфейсы 
 * указываюстся через запятую.
 */
interface IMessage
{
    string Text { get; set; }
}
interface IPrintable
{
    void Print();
}
class Message(string text): IMessage,IPrintable
{
    public string Text { get; set; } = text;
    public void Print() => Console.WriteLine(Text);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */