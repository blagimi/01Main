﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Класс ObservableCollection 
Кроме стандартных классов коллекций типа списков, очередей, словарей, стеков .NET также
предоставляет специальный класс ObservableCollection<T>. В отличие от ранее
рассмотренных коллекций данный класс определен в пространстве имен 
System.Collections.ObjectModel. По функциональности коллекция ObservableCollection
похожа на список List за тем исключением, что позволяет известить внешние объекты
о том, что коллекция была изменена.*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Создание и инициализация ObservableCollection 
Для создания объекта класс ObservableCollection предоставляет ряд конструкторов.
 Прежде всего мы можем создать пустую коллекцию:*/

 using System.Collections.ObjectModel;
 
ObservableCollection<string> people = new ObservableCollection<string>();

/* В данном случае коллекция people типизируется типом string, поэтому может хранить 
только строки.

Другая версия конструктора позволяет передать в ObservableCollection объекты из другой
 коллекции или массива: */

	
var people2 = new ObservableCollection<string>( new string[] {"Tom", "Bob", "Sam"});

/* Для инициализации можно через инициализатор в фигурных скобках передать значения */

var people3 = new ObservableCollection<string>
{
    "Tom", "Bob", "Sam"
};

/* Также можно сочетать предыдущие два способа: */

var people4 = new ObservableCollection<string>( new string[] {"Mike", "Alice", "Kate" })
{
    "Tom", "Bob", "Sam"
};


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Обращение к элементам коллекции 
Для обращения к элементам ObservableCollection можно применять индексы на манер массивов
 или списков List:*/

 var people5 = new ObservableCollection<string>
{
    "Tom", "Bob", "Sam"
};
 
// получаем первый элемент
Console.WriteLine(people5[0]);   // Tom
// изменяем первый элемент
people5[0] = "Tomas";
Console.WriteLine(people5[0]);   // Tomas


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Перебор коллекции 
Для перебора коллекции можно применять стандартные циклы: */

var people6 = new ObservableCollection<string>
{
    "Tom", "Bob", "Sam"
};
 
foreach(var person in people6)
{
    Console.WriteLine(person);
}
for (int i =0; i < people6.Count; i++)
{
    Console.WriteLine(people6[i]);
}

/* С помощью свойства Count можно получить количество элементов в коллекции. */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Методы ObservableCollection 
Среди методов класса ObservableCollection можно отметить следующие:
void Add(T item): добавление нового элемента в коллекцию
void CopyTo(T[] array, int index,): копирует в массив array элементы из коллекции 
начиная с индекса index
bool Contains(T item): возвращает true, если элемент item есть в коллекции
void Clear(): удаляет из коллекции все элементы
int IndexOf(T item): возвращает индекс первого вхождения элемента в коллекции
void Insert(int index, T item): вставляет элемент item в коллекцию по индексу index.
 Если такого индекса в коллекции нет, то генерируется исключение
bool Remove(T item): удаляет элемент item из коллекции, и если удаление прошло успешно,
 то возвращает true. Если в коллекции несколько одинаковых элементов, то удаляется 
 только первый из них
void RemoveAt(int index): удаление элемента по указанному индексу index. Если такого
 индекса в коллекции нет, то генерируется исключение
void Move(int oldIndex, int newIndex): перемещает элемент с индекса oldIndex на 
позицию по индексу newIndex
*/

var people7 = new ObservableCollection<string>();
 
// добавляем элемент
people7.Add("Bob");
// вставляем элемент по индексу 0
people7.Insert(0, "Tom");
 
// проверка наличия элемента 
bool bobExists = people7.Contains("Bob");     // true
Console.WriteLine($"Bob exists: {bobExists}");
bool mikeExists = people7.Contains("Mike");   // false
Console.WriteLine($"Mike exists: {mikeExists}");
 
// удаляем элемент
people7.Remove("Tom");
// удаляем элемент по индексу 0
people7.RemoveAt(0);


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */


Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */