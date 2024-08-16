/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* 
Двухсвязный список LinkedList<T> 
Класс LinkedList<T> представляет двухсвязный список, в котором каждый
элемент хранит ссылку одновременно на следущий и на предыдущий элемент.
*/



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


/* Создание связанного списка */

/* Для создания связного списка можно принименять один из его конструктора. Например,
 создадим пустой связный список LinkedList<string> people = new LinkedList<string>();
В данном случае связанный список people предназначен для хранения строк.
Также можно в конструктор передать коллекцию элементов, например, список List, по 
которому будет создан связный список: */

var employees = new List<string> { "Tom", "Sam", "Bob" };
 
LinkedList<string> people = new LinkedList<string>(employees);
foreach (string person in people)
{
    Console.WriteLine(person);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* LinkedListNode 
Если в простом списке List<T> каждый элемент представляет объект типа T, то в 
LinkedList<T> каждый узел представляет объект класса LinkedListNode<T>. А добавляемые
в связанный список элементы T фактически обертываются в объект LinkedListNode.
Класс LinkedListNode имеет следующие свойства:
Value: возвращает или устанавливает само значение узла, представленное типом T
Next: возвращает ссылку на следующий элемент типа LinkedListNode<T> в списке. Если
следующий элемент отсутствует, то имеет значение null
Previous: возвращает ссылку предыдущий элемент типа LinkedListNode<T> в списке. 
Если предыдущий элемент отсутствует, то имеет значение null
*/
 
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */ 

/*Свойства LinkedList
Класс LinkedList определяет следующие свойства:

Count: количество элементов в связанном списке

First: первый узел в списке в виде объекта LinkedListNode<T>

Last: последний узел в списке в виде объекта LinkedListNode<T>

Используем эти свойства */
var employees2 = new List<string> { "Tom", "Sam", "Bob" };
 
LinkedList<string> people2 = new LinkedList<string>(employees2);
Console.WriteLine(people2.Count);            // 3
Console.WriteLine(people2.First?.Value);    // Tom
Console.WriteLine(people2.Last?.Value);    // Bob

/* Используя свойства LinkedList и LinkedListNode, можно пройтись по всем элементам списка в прямом или обратном порядке: */

LinkedList<string> people3 = new LinkedList<string>(new[] { "Tom", "Sam", "Bob" });
 
// от начала до конца списка
var currentNode = people3.First;
while(currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Next;
}
 
// с конца до начала списка
currentNode = people3.Last;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Previous;
}

/*
Методы LinkedList
Используя методы класса LinkedList<T>, можно обращаться к различным элементам, как в конце, так и в начале списка:
AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode): вставляет узел newNode в список после узла node.
AddAfter(LinkedListNode<T> node, T value): вставляет в список новый узел со значением value после узла node.
AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode): вставляет в список узел newNode перед узлом node.
AddBefore(LinkedListNode<T> node, T value): вставляет в список новый узел со значением value перед узлом node.
AddFirst(LinkedListNode<T> node): вставляет новый узел в начало списка
AddFirst(T value): вставляет новый узел со значением value в начало списка
AddLast(LinkedListNode<T> node): вставляет новый узел в конец списка
AddLast(T value): вставляет новый узел со значением value в конец списка
RemoveFirst(): удаляет первый узел из списка. После этого новым первым узлом становится узел, следующий за удаленным
RemoveLast(): удаляет последний узел из списка
Приминение некоторых
*/

var people4 = new LinkedList<string>();
people4.AddLast("Tom"); // вставляем узел со значением Tom на последнее место
                        //так как в списке нет узлов, то последнее будет также и первым
people4.AddFirst("Bob"); // вставляем узел со значением Bob на первое место
 
// вставляем после первого узла новый узел со значением Mike
if (people4.First != null) people.AddAfter(people4.First, "Mike");
 
// теперь у нас список имеет следующую последовательность: Bob Mike Tom
foreach (var person in people4) Console.WriteLine(person);

/* Подобным образом можно создавать связанные списки и других типов: */

var company = new LinkedList<Person>();
 
company.AddLast(new Person("Tom"));
company.AddLast(new Person("Sam"));
company.AddFirst(new Person("Bill"));
 
foreach (var person in company) Console.WriteLine(person.Name);
 
Console.ReadKey();

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */ 


