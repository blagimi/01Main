﻿using СписокListT;
/*
 * Хотя в языке C# есть массивы, которые хранят в себе наборы однотипных объектов
 * , но работать с ними не всегда удобно. Например, массив хранит фиксированное 
 * количество объектов, однако что если мы заранее не знаем, сколько нам потребуется
 * объектов. И в этом случае намного удобнее применять коллекции. Еще один плюс 
 * коллекций состоит в том, что некоторые из них реализует стандартные структуры 
 * данных, например, стек, очередь, словарь, которые могут пригодиться для решения 
 * различных специальных задач. Большая часть классов коллекций содержится в 
 * пространстве имен System.Collections.Generic.Класс List<T> из пространства 
 * имен System.Collections.Generic представляет простейший список однотипных 
 * объектов. Класс List типизируется типом, объекты которого будут хранится
 * в списке.Мы можем создать пустой список:
 */
List<string> people = new List<string>();

/*
 * В данном случае объект List типизируется типом string. А это значит, что хранить
 * в этом списке мы можем только строки.Можно сразу при создании списка инициализировать
 * его начальными значениями. В этом случае элементы списка помещаются после вызова
 * конструктора в фигурных скобках
 */

List<string> people2 = new List<string>() { "Tom", "Bob", "Sam" };

/*
 * В данном случае в список помещаются три строки Также можно при создании списка
 * инициализировать его элементами из другой коллекции, например, другого списка:
 */

var people3 = new List<string>() { "Tom", "Bob", "Sam" };
var employees = new List<string>(people3);


/* 
 * Можно совместить оба способа:
 */


var people4 = new List<string>() { "Tom", "Bob", "Sam" };
var employees2 = new List<string>(people) { "Mike" };

/*
 *  В данном случае в списке employees будет четыре элемента 
 *  ({ "Tom", "Bob", "Sam", "Mike" }) - три добавляются из списка people и один
 *  элемент задается при инициализации. Начиная с версии C# 12 для определения 
 *  списков можно использовать выражения коллекций, которые предполагают 
 *  заключение элементов коллекции в квадратные скобки:
 */

List<string> people5 = ["Tom", "Bob", "Sam"];
List<string> employees3 = [];// пустой список

/* Подобным образом можно работать со списками других типов, например: */

List<Person> people7 = new List<Person>()
{
    new Person("Tom"),
    new Person("Bob"),
    new Person("Sam")
};

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Установка начальной емкости списка.
 * Еще один конструктор класса List принимает в качестве параметра начальную емкость 
 * списка:Указание начальной емкости списка позволяет в будущем увеличить 
 * производительность и уменьшить издержки на выделение памяти при добавлении элементов. 
 * Поскольку динамическое добавление в список может приводить на низком уровне к 
 * дополнительному выделению памяти, что снижает производительность. Если же мы знаем, 
 * что список не будет превышать некоторый размер, то мы можем передать этот размер в 
 * качестве емкости списка и избежать дополнительных выделений памяти.
 * Также начальную емкость можно установить с помощью свойства Capacity, которое
 * имеется у класса List.
 */
List<string> people6 = new List<string>(16);

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Обращение к элементам списка.
 * Как и массивы, списки поддерживают индексы, с помощью которых можно обратиться к 
 * определенным элементам:
 */

var people8 = new List<string>() { "Tom", "Bob", "Sam" };

string firstPerson = people8[0]; // получаем первый элемент
Console.WriteLine(firstPerson); // Tom
people8[0] = "Mike";     // изменяем первый элемент
Console.WriteLine(people8[0]); // Mike

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Длина списка.
 * С помощью свойства Count можно получить длину списка:
 */

var people9 = new List<string>() { "Tom", "Bob", "Sam" };
Console.WriteLine(people9.Count);    // 3

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Перебор списка.
 * C# позволяет осуществить перебор списка с помощью стандартного цикла foreach 
 */

var people10 = new List<string>() { "Tom", "Bob", "Sam" };

foreach (var person in people10)
{
    Console.WriteLine(person);
}
// Вывод программы:
// Tom
// Bob
// Sam

/* Также можно использовать другие типы циклов и в комбинации с индексами перебирать списки */

var people11 = new List<string>() { "Tom", "Bob", "Sam" };

for (int i = 0; i < people11.Count; i++)
{
    Console.WriteLine(people11[i]);
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Методы списка.
Среди его методов можно выделить следующие:
void Add(T item): добавление нового элемента в список
void AddRange(IEnumerable<T> collection): добавление в список коллекции или массива
int BinarySearch(T item): бинарный поиск элемента в списке. Если элемент найден, то метод
 возвращает индекс этого элемента в коллекции. При этом список должен быть отсортирован.
void CopyTo(T[] array): копирует список в массив array
void CopyTo(int index, T[] array, int arrayIndex, int count): копирует из списка начиная 
с индекса index элементы, количество которых равно count, и вставляет их в массив array 
начиная с индекса arrayIndex
bool Contains(T item): возвращает true, если элемент item есть в списке
void Clear(): удаляет из списка все элементы
bool Exists(Predicate<T> match): возвращает true, если в списке есть элемент, который 
соответствует делегату match
T? Find(Predicate<T> match): возвращает первый элемент, который соответствует делегату
 match. Если элемент не найден, возвращается null
T? FindLast(Predicate<T> match): возвращает последний элемент, который соответствует 
делегату match. Если элемент не найден, возвращается null
List<T> FindAll(Predicate<T> match): возвращает список элементов, которые соответствуют
 делегату match
int IndexOf(T item): возвращает индекс первого вхождения элемента в списке
int LastIndexOf(T item): возвращает индекс последнего вхождения элемента в списке
List<T> GetRange(int index, int count): возвращает список элементов, количество 
которых равно count, начиная с индекса index.
void Insert(int index, T item): вставляет элемент item в список по индексу index.
 Если такого индекса в списке нет, то генерируется исключение
void InsertRange(int index, collection): вставляет коллекцию элементов collection 
в текущий список начиная с индекса index. Если такого индекса в списке нет, то 
генерируется исключение
bool Remove(T item): удаляет элемент item из списка, и если удаление прошло 
успешно, то возвращает true. Если в списке несколько одинаковых элементов, 
то удаляется только первый из них
void RemoveAt(int index): удаление элемента по указанному индексу index. Если
 такого индекса в списке нет, то генерируется исключение
void RemoveRange(int index, int count): параметр index задает индекс, с которого 
надо удалить элементы, а параметр count задает количество удаляемых элементов.
int RemoveAll((Predicate<T> match)): удаляет все элементы, которые соответствуют
 делегату match. Возвращает количество удаленных элементов
void Reverse(): изменяет порядок элементов
void Reverse(int index, int count): изменяет порядок на обратный для элементов, 
количество которых равно count, начиная с индекса index
void Sort(): сортировка списка
void Sort(IComparer<T>? comparer): сортировка списка с помощью объекта comparer, 
который передается в качестве параметра
*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Добавление в список*/
List<string> people12 = new List<string> () { "Tom" };
 
people12.Add("Bob"); // добавление элемента
// people = { "Tom", "Bob" };
 
people12.AddRange(new[] { "Sam", "Alice" });   // добавляем массив
// people = { "Tom", "Bob", "Sam", "Alice" };
// также можно было бы добавить другой список
// people.AddRange(new List<string>(){ "Sam", "Alice" });
 
people12.Insert(0, "Eugene"); // вставляем на первое место
// people = { "Eugene", "Tom", "Bob", "Sam", "Alice" };
 
people12.InsertRange(1, new string[] {"Mike", "Kate"}); // вставляем массив с индекса 1
// people = { "Eugene", "Mike", "Kate", "Tom", "Bob", "Sam", "Alice" };
 
// также можно было бы добавить другой список
// people.InsertRange(1, new List<string>(){ "Mike", "Kate" });

/* Удаление из списка */

var people13 = new List<string> () { "Eugene", "Mike", "Kate", "Tom", "Bob", "Sam", "Tom", "Alice" };
 
people13.RemoveAt(1); //  удаляем второй элемент
// people = { "Eugene", "Kate", "Tom", "Bob", "Sam", "Tom", "Alice" };
 
people13.Remove("Tom"); //  удаляем элемент "Tom"
// people = { "Eugene", "Kate", "Bob", "Sam", "Tom", "Alice" };
 
// удаляем из списка все элементы, длина строки которых равна 3
people13.RemoveAll(person => person.Length == 3);
// people = { "Eugene", "Kate", "Alice" };
 
// удаляем из списка 2 элемента начиная с индекса 1
people13.RemoveRange(1, 2);
// people = { "Eugene"};
 
// полностью очищаем список
people13.Clear();
// people = {  };


/* Поиск и проверка элемента */

var people14 = new List<string> () { "Eugene", "Mike", "Kate", "Tom", "Bob", "Sam" };
 
var containsBob = people14.Contains("Bob");     //  true
var containsBill = people14.Contains("Bill");    // false
 
// проверяем, есть ли в списке строки с длиной 3 символа
var existsLength3 = people14.Exists(p => p.Length == 3);  // true
 
// проверяем, есть ли в списке строки с длиной 7 символов
var existsLength7 = people14.Exists(p => p.Length == 7);  // false
 
// получаем первый элемент с длиной в 3 символа
var firstWithLength3 = people14.Find(p => p.Length == 3); // Tom
 
// получаем последний элемент с длиной в 3 символа
var lastWithLength3 = people14.FindLast(p => p.Length == 3);  // Sam
 
// получаем все элементы с длиной в 3 символа в виде списка
List<string> peopleWithLength3 = people14.FindAll(p => p.Length == 3);
// peopleWithLength3 { "Tom", "Bob", "Sam"}