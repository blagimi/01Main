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



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */ 

Console.ReadKey();
