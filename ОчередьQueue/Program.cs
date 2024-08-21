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





/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */