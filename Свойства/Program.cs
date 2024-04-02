Person person = new();

Console.WriteLine(person.Age);  // 1
// изменяем значение свойства
person.Age = 37;
Console.WriteLine(person.Age);  // 37
// пробуем передать недопустимое значение
person.Age = -23;               // Возраст должен быть в диапазоне от 1 до 120
Console.WriteLine(person.Age);  // 37 - возраст не изменился

Person2 person2 = new();

// свойство для чтения - можно получить значение
Console.WriteLine(person2.Name);  // Tom
                                 // но нельзя установить
                                 // person.Name = "Bob";    // ! Ошибка

// свойство для записи - можно устновить значение
person.Age = 37;
// но нелзя получить
// Console.WriteLine(person.Age);  // ! Ошибка

person2.Print();


Person3 tom = new("Tom", "Smith");
Console.WriteLine(tom.Name);    // Tom Smith


Person4 tom2 = new("Tom");

// Ошибка - set объявлен с модификатором private
//tom.Name = "Bob";
Console.WriteLine(tom2.Name);    // Tom

Person5 tom3 = new();

Console.WriteLine(tom3.Name);    // Tom
Console.WriteLine(tom3.Age);    // 37

Person6 person6 = new();
//person.Name = "Bob";    //! Ошибка - после инициализации изменить значение нельзя

Console.WriteLine(person6.Name); // Undefined

//Person8 bob = new Person8("Bob"); // ошибка - свойства Name и Age все равно надо установить в инициализаторе
class Person
{
    int age = 1;
    public int Age
    {
        set
        {
            if (value < 1 || value > 120)
                Console.WriteLine("Возраст должен быть в диапазоне от 1 до 120");
            else
                age = value;
        }
        get { return age; }
    }
}
class Person2
{
    readonly string name = "Tom";
    int age = 1;
    // свойство только для записи
    public int Age
    {
        set { age = value; }
    }
    // свойство только для чтения
    public string Name
    {
        get { return name; }
    }

    public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");
}
/*
 * Вычисляемые свойства
 * Свойства необязательно связаны с определенной переменной. Они могут вычисляться на основе различных выражений
 */
class Person3
{
    readonly string firstName;
    readonly string lastName;
    public string Name
    {
        get { return $"{firstName} {lastName}"; }
    }
    public Person3(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

class Person4
{
    string name = "";
    public string Name
    {
        get { return name; }

        private set { name = value; }
    }
    public Person4(string name) => Name = name;
}

/*
 * Автоматические свойства
 */
class Person5
{
    public string Name { get; set; } = "Tom";
    public int Age { get; set; } = 37;
}

/* 
 * Блок init
 * Начиная с версии C# 9.0 сеттеры в свойствах могут определяться с помощью оператора init 
 * (от слова "инициализация" - это есть блок init призван инициализировать свойство). 
 * Для установки значений свойств с init можно использовать только инициализатор, либо конструктор, либо при объявлении указать для него значение. 
 * После инициализации значений подобных свойств их значения изменить нельзя - они доступны только для чтения.
 */
public class Person6
{
    public string Name { get; init; } = "Undefined";
}

/*
 * Сокращенная запись свойств
 */
class Person7
{
    string name;
    public string Name
    {
        get => name;
        set => name = value;
    }
}
/*
 * модификатор required
 * Модификатор required (добавлен в C# 11) указывает, что поле или свойства с этим модификатором обязательно должны быть инициализированы.
 */
public class Person8(string name)
{
    public required string Name { get; set; } = name;
    public required int Age { get; set; } = 22;
}