/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 Класс Queue<T> представляет обычную очередь, которая работает по алгоритму FIFO 
 ("первый вошел - первый вышел").
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Создание очереди
Для создания очереди можно использовать один из трех ее конструкторов.
Прежде всего можно создать пустую очередь:
 */
 Queue<string> people = new Queue<string>();
 /* При создании пустой очереди можно указать емкость очереди: */

Queue<string> people2 = new Queue<string>(16);

/* Также можно инициализировать очередь элементами из другой коллекции или массивом: */

var employees = new List<string> { "Tom", "Sam", "Bob" };
Queue<string> people3 = new Queue<string>(employees);
foreach (var person in people3) Console.WriteLine(person);
 
Console.WriteLine(people3.Count); // 3

/* Для перебора очереди можно использовать стандартный цикл foreach.
Для получения количества элементов в очереди в классе определено свойство Count. */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Методы Queue
У класса Queue<T> можно отметить следующие методы:
void Clear(): очищает очередь
bool Contains(T item): возвращает true, если элемент item имеется в очереди
T Dequeue(): извлекает и возвращает первый элемент очереди
void Enqueue(T item): добавляет элемент в конец очереди
T Peek(): просто возвращает первый элемент из начала очереди без его удаления
Посмотрим применение очереди на практике: */

var people4 = new Queue<string>();
 
// добавляем элементы
people4.Enqueue("Tom");  // people = { Tom }
people4.Enqueue("Bob");  // people = { Tom, Bob }
people4.Enqueue("Sam");  // people = { Tom, Bob, Sam }
 
// получаем элемент из самого начала очереди 
var firstPerson = people4.Peek();
Console.WriteLine(firstPerson); // Tom
 
// удаляем элементы
var person1 = people4.Dequeue();  // people = { Bob, Sam  }
Console.WriteLine(person1); // Tom
var person2 = people4.Dequeue();  // people = { Sam  }
Console.WriteLine(person2); // Bob
var person3 = people4.Dequeue();  // people = {  }
Console.WriteLine(person3); // Sam

/* Стоит отметить, что если с помощью методов Peek или Dequeue мы попытаемся 
получить первый элемент очереди, которая пуста, то программа выдаст исключение.
Соответственно перед получением элемента мы можем проверять количество элементов
в очереди: */

if(people4.Count > 0)
{
    var person = people4.Peek();
    people4.Dequeue();
}

/*
Либо можно использовать пару методов:
bool TryDequeue(out T result): передает в переменную result первый элемент очереди
с его удалением из очереди, возвращает true, если очередь не пуста и элемент 
успешно получен.
bool TryPeek(out T result): передает в переменную result первый элемент очереди без
его извлечения из очереди, возвращает true, если очередь не пуста и элемент успешно 
получен.
*/

var people5 = new Queue<string>();
 
// добавляем элементы
people5.Enqueue("Tom");  // people = { Tom }
 
// удаляем элементы
var success1 = people5.TryDequeue(out var person5);  // success1 = true
if (success1) Console.WriteLine(person5); // Tom
 
var success2 = people5.TryPeek(out var person6);  // success2 = false
if (success2) Console.WriteLine(person6); 

/*
Очереди - довольно часто встречаемая стуктура в реальной жизни. 
Например, очередь пациентов на прием к врачу. Реализуем данную ситуацию:
Здесь класс врача - класс Doctor в методе TakePatients принимает очередь пациентов в 
виде объектов Person. И пока в очереди есть объекты извлекает по одному объекту.
Консольный вывод:
Осмотр пациента Tom
Осмотр пациента Bob
Осмотр пациента Sam
Доктор закончил осматривать пациентов
*/

var patients = new Queue<Person>();
patients.Enqueue(new Person("Tom"));
patients.Enqueue(new Person("Bob"));
patients.Enqueue(new Person("Sam"));
 
var practitioner = new Doctor();
practitioner.TakePatients(patients);
 
class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}
 
class Doctor
{
    public void TakePatients(Queue<Person> patients)
    {
        while(patients.Count > 0)
        {
            var patient = patients.Dequeue();
            Console.WriteLine($"Осмотр пациента {patient.Name}");
        }
        Console.WriteLine("Доктор закончил осматривать пациентов");
    }
}


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */