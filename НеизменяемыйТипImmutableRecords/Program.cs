﻿using НеизменяемыйТипImmutableRecords;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Records.
Records представляют новый ссылочный тип, который появился в C#9. Ключевая особенность 
records состоит в том, что они могут представлять неизменяемый (immutable) тип, который 
по умолчанию обладает рядом дополнительных возможностей по сравнению с классами и 
структурами. Зачем нам нужны неизменяемые типы? Такие типы более безопасны в тех
 ситуациях, когда нам надо гарантировать, что данные объекта не будут изменяться. 
В .NET в принципе уже есть неизменяемые типы, например, String.
Стоит отметить, что начиная с версии C# 10 добавлена поддержка структур record, 
соответственно мы можем создавать record-классы и record-структуры.
Для определения records используется ключевое слово record. Если определяется класс
 record, то ключевое слово class можно неиспользовать при определении типа:
 public record Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}

или так

public record class Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}

При определении структуры record при объявлении типа надо использовать ключевое слово struct:

public record struct Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}
*/

/*
Хотя типы record предназначены для создания неизменяемых типов, однако одно только
применение ключевого слова record не гарантирует неизменяемость объектов record. 
Они являются неизменяемыми (immutable) только при определенных условиях. Например,
мы можем написать так:

var person = new Person("Tom");
person.Name = "Bob";
Console.WriteLine(person.Name); // Bob - данные изменились
 
public record Person
{
    public string Name { get; set; }
    public Person(string name) => Name = name;
}
При выполнении этого кода не возникнет никакой ошибки, мы спокойно сможем изменять
 значения свойств объекта Person. Чтобы сделать его действительно неизменяемым,
  для свойств вместо обычных сеттеров надо использовать модификатор init.

var person = new Person("Tom");
person.Name = "Bob";    // ! ошибка - свойство изменить нельзя
 
public record Person
{
    public string Name { get; init; }
    public Person(string name) => Name = name;
}

В данном случае мы получим ошибку при попытке изменить значение свойств 
объекта Person.
Во многим records похожи на обычные классы и структуры, например, они могут 
абстрактными, их также можно наследовать либо запрещать наследование с помощью 
оператора sealed. Тем не менее есть и ряд отличий. Рассмотрим некоторые основные 
отличия records от стандартных классов и структур.
*/


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Сравнение на равенство
При определении record компилятор генерирует метод Equals() для сравнения с другим
объектом. При этом сравнение двух records производится на основе их значений. В данном
случае при сравнении двух объектов record Person мы увидим что они равны, так как
значения (свойства Name) равны. В случае с объектами класса User которые имеют те же
одинаковые значения мы увидим что они не равны. Так как сравнение record происходит 
по значению. Кроме того в record по умолчанию реализованы операторы == и != которые 
так же сравнивают две record по значению.
.                                                           //  Person, User
*/
var person1 = new Person("Tom");
var person2 = new Person("Tom");
Console.WriteLine(person1.Equals(person2)); // true
// Console.WriteLine(person1 == person2);   // true
 
var user1 = new User("Tom");
var user2 = new User("Tom");
Console.WriteLine(user1.Equals(user2));     // false
// Console.WriteLine(user1 == user2);       // false


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/*
Оператор with.
В отличие от классов record поддерживают инициализацию с помощью оператора with. Он 
позволяет создать одну record на основе другой record. После record, значение которой
мы хотим скопировать, указывается оператор with, после которого в фигурных скобках 
указываются значения для тех свойств, которые мы хотим изменить. Так в данном случае
переменная sam получает для свойства Age значение из tom а свойство Name изменяется.
Эта возможность может быть особенно актуальна, если в record, которую мы хотим скопировать
множество свойств, из которых мы хотим поменять одно-два. Для копирования всех свойств
можно оставить пустые фигурные скобки.
                                                            //  Person2
*/
var tom = new Person2("Tom",37);
var sam = tom with {Name = "Sam"};
System.Console.WriteLine($"{sam.Name} - {sam.Age}"); // Sam - 37
var tim = tom with {};                      //  Копирование значения всех свойств.


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/*
Позиционные records.
Redord могут принимать данные для свойств через конструктор, и в этом случае можно
сократить их определение. Кроме конструктора здесь реализован деконструктор, который
позволяет разложить объект Person на кортеж значений которые можно применить следующим
образом. 
*/
var person3 = new Person3 ("Tom",37);
System.Console.WriteLine(person3.Name);         //  Tom

var (personName, personAge) = person3;

System.Console.WriteLine(personAge);            //  37
System.Console.WriteLine(personName);           //  Tom

/*
Выше определенную record Person можно сократить до позиционной record:
public record Person(string Name, int Age);
Это всё определение типа. Т.е мы говорим что для типа Person будет создаваться
конструктор, который принимает два параметра и присваивает их значения соответственно
свойствам Name и Age и что так же автоматически будет создаваться деконструктор. 
Использование будет аналогично

var person = new Person("Tom", 37);
Console.WriteLine(person); // Tom
 
var (personName, personAge) = person;
 
Console.WriteLine(personAge);     // 37
Console.WriteLine(personName);    // Tom
 
public record Person(string Name, int Age);
При необходимости также можно совмещать стандартное определение свойств и 
определение свойств через конструктор:
*/

var person4 = new Person4("Tom",37) {Company = "Google"};
System.Console.WriteLine(person4.Company);          //  Google
person4.Company = "Microsoft";
System.Console.WriteLine(person4.Company);          //  Microsoft

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Позиционные структуры для чтения.
Следует отметить различие между позиционные классами и структурами record. Свойства
класса record которые устанавливаются через параметры конструктора, по умолчанию будут
иметь модификатор init. Т.е после установки их значений через конструктор, они не 
меняются.

var person = new Person("Tom", 37);
person.Name = "Bob";    // ! Ошибка - значение нельзя изменить
public record Person(string Name, int Age);

Стоит отметить, что это относится только к тем свойствам, которые устанавливаются 
через конструктор.Однако для позиционных структур record свойства будут иметь 
стандартные сеттеры, которые позволят изменять значения свойств:

var person = new Person("Tom", 37);
person.Name = "Bob";
Console.WriteLine(person.Name); // Bob - значение изменилось
// структура record
public record struct Person(string Name, int Age);

Чтобы для подобных свойств структуры record использовался модификатор init вместо 
обычных сеттеров, такую структуру надо определить с ключевым словом readonly:

var person = new Person("Tom", 37);
person.Name = "Bob";    // ! Ошибка - значение свойства нельзя изменить
// структура record доступна только для чтения
public readonly record struct Person(string Name, int Age);

*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/*
ToString.
Небольшим преимущество типов record так же является что для них по умолчанию реализован
метод ToString() который выводит состояние объекта в отформатированном виде.
*/
var person11 = new Person3("Tom",37);
System.Console.WriteLine(person11);     // Person {Name = Tom, Age = 37}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Наследование.
Как и обычные классы record-классы могут наследоваться.
*/
var tomas = new Person3("Tomas", 35);
var bob = new Employee("Bob",41,"Microsoft");
System.Console.WriteLine(tomas);        // Person {Name = Tom, Age = 37}
System.Console.WriteLine(bob);          // Person {Name = Bob, Age = 41, Company = Microsoft}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


 
 Console.ReadLine();
