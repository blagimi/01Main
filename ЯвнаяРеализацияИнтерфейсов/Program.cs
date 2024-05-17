/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Явная реализация интерфейсов.
 * При явной реализации указывается название метода или свойства вместе с названием
 * интерфейса. При этом при реализации нельзя использовать какие-либо модификаторы.
 */
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * При явной реализации интерфейса его методы и свойства НЕ ЯВЛЯЮТСЯ частью интерфейса
 * класса.Поэтому напрямую через объект класса к ним обратиться нельзя.
 */

BaseAction baseAction1 = new();
//baseAction1.Move(); Ошибка, Move не определен в BaseAction
// Небезопастное приведение
((IAction)baseAction1).Move();
// Безопастное приведение
if (baseAction1 is IAction action) action.Move();
//или так
IAction baseAction2 = new BaseAction();
baseAction2.Move();
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Явная реализация интерфейса может понадобиться если класс применяет несколько 
 * интерфейсов имеющих один и тот же метод и возвращают тот же результат с тем же
 * набором параметров. Класс Person определяет один метод Study(), создавая одну 
 * общую реализацию для обоих интерфейсов. Вне зависимости от интерфейса результат
 * будет один и тот же. Что бы разграничить реализуемые интерфейсы, надо явным
 * образом применить интерфейс.
 */

Person2 person2 = new();
((ISchool)person2).Study();
((IUniversity)person2).Study();

/*
 * Либо когда в базовом классе уже реализован интерфейс, но необходимо в 
 * производном классе реализовать его иначе.
 */

HeroAction heroAction1 = new();
heroAction1.Move();             // Move In BaseAction
((IAction2)heroAction1).Move(); // Move in Hero Action

IAction2 heroAction2 = new HeroAction();
heroAction2.Move();             // Move in Hero Action

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Модификаторы доступа.
 * Члены интерфейса могут иметь разные модификаторы доступа. Если модификатор доступа
 * не public то при реализации метода, свойства или события интерфейса в классах и
 * структурах можно применять 2 способа.
 * Первый это использование явной реализации интерфейса, реализовав всё необходимое
 * без модификаторов доступа.Опять же надо учитывать что напрямую к пододбным свойствам
 * и событиям можно обратиться только через переменную интерфейса, но не класса.
 */
IMovable3 tim = new Person3("Tim");
tim.MoveEvent += () => Console.WriteLine($"{tim.Name} is moving");
tim.Move();
/*
 * Второй это неявная реализация с помощью модификатора public.
 * В этом случае к методам, свойствам и событиям интерфейса можно обращаться через
 * переменную класса.
 */

Person4 jack = new("Jack");
// Подписываемся на событие
jack.MoveEvent += () => Console.WriteLine($"{jack.Name} is moving");
jack.Move();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

class Person4 : IMovable3
{
    string name;
    // Явная реализация события - дополнительно создаётся переменная
    MoveHandler? moveEvent;
    // Неявная реализация события с модификатором public
    public event MoveHandler MoveEvent
    {
        add => moveEvent += value;
        remove => moveEvent -= value;
    }
    // Неявная реализаця свойства - в виде автосвойства, но public
    public string Name { get => name; }
    public Person4(string name) => this.name = name;
    // неявная реализация метода, но с модификатором public
    public void Move()
    {
        Console.WriteLine($"{name} is walking");
        moveEvent?.Invoke();
    }
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
delegate void MoveHandler();    // Делега перемещения
interface IMovable3
{
    protected internal void Move();
    protected internal string Name { get; }
    protected internal event MoveHandler MoveEvent;
}
class Person3 : IMovable3
{
    string name;
    // Явная реализация события - дополнительно создается переменная.
    MoveHandler? moveEvent;
    event MoveHandler IMovable3.MoveEvent
    {
        add => moveEvent += value;
        remove => moveEvent -= value;
    }
    // Явная реализация свойства - в виде автосвойства
    string IMovable3.Name { get => name; }
    public Person3(string name) => this.name = name;
    // Явная реализация метода
    void IMovable3.Move()
    {
        Console.WriteLine($"{name} is walking");
        moveEvent?.Invoke();
    }
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
interface IAction2
{
    void Move();
}
class BaseAction2: IAction2
{
    public void Move() => Console.WriteLine("Move in BaseAction");
}
class HeroAction: BaseAction2, IAction2
{
    void IAction2.Move() => Console.WriteLine("Move in HeroAction");
}
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
class Person : ISchool, IUniversity
{
    public void Study() => Console.WriteLine("Учеба в школе или университете");
}
class Person2 : ISchool, IUniversity
{
    void ISchool.Study() => Console.WriteLine("Учеба в школе");
    void IUniversity.Study() => Console.WriteLine("Учеба в университете");
}
interface ISchool
{
    void Study();
}
interface IUniversity
{
    void Study();
}
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

interface IAction
{
    void Move();
}
class BaseAction: IAction
{
    void IAction.Move() => Console.WriteLine("Move in base class");
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */