/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Класс Array и массивы 
Все массивы в C# построены на основе класса Array из пространства имен System. Этот
 класс определяет ряд свойств и методов, которые мы можем использовать при работе 
 с массивами. Основные свойства и методы:

Свойство Length возвращает длину массива

Свойство Rank возвращает размерность массива

int BinarySearch (Array array, object? value) выполняет бинарный поиск в отсортированном
 массиве и возвращает индекс найденного элемента

void Clear (Array array) очищает массив, устанавливая для всех его элементов значение
 по умолчанию

void Copy (Array sourceArray, int sourceIndex, Array destinationArray, 
int destinationIndex, int length) копирует из массива sourceArray начиная с 
индекс sourceIndex length элементов в массив destinationArray начиная с индекса
 destinationIndex

bool Exists<T> (T[] array, Predicate<T> match) проверяет, содержит ли массив array
 элементы, которые удовлеворяют условию делегата match

void Fill<T> (T[] array, T value) заполняет массив array значением value

T? Find<T> (T[] array, Predicate<T> match) находит первый элемент, который удовлеворяет
 определенному условию из делегата match. Если элемент не найден, то возвращается null

T? FindLast<T> (T[] array, Predicate<T> match) находит последний элемент, который 
удовлеворяет определенному условию из делегата match. Если элемент не найден, то
 возвращается null

int FindIndex<T> (T[] array, Predicate<T> match) возвращает индекс первого вхождения
 элемента, который удовлеворяет определенному условию делегата match

int FindLastIndex<T> (T[] array, Predicate<T> match) возвращает индекс последнего 
вхождения элемента, который удовлеворяет определенному условию

T[] FindAll<T> (T[] array, Predicate<T> match) возвращает все элементы в виде
 массива, которые удовлеворяет определенному условию из делегата match

int IndexOf (Array array, object? value) возвращает индекс первого вхождения 
элемента в массив

int LastIndexOf (Array array, object? value) возвращает индекс последнего
 вхождения элемента в массив

void Resize<T> (ref T[]? array, int newSize) изменяет размер одномерного массива

void Reverse (Array array) располагает элементы массива в обратном порядке

void Sort (Array array) сортирует элементы одномерного массива

Разберем самые используемые методы.*/

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Сортировка массива
Отсортируем массив с помощью метода Sort(): */

string[] people =  { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };
 
Array.Sort(people);
 
foreach (var person in people) 
    Console.Write($"{person} ");
     
// Alice Bob Kate Sam Tom Tom

/* Этот метод имеет много перегрузок. Например, одна из версий позволяет отсортировать
 только часть массива: */


string[] people2 =  { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };
 
// сортируем с 1 индекса 3 элемента
Array.Sort(people2, 1, 3);
 
foreach (var person in people2) 
    Console.Write($"{person} ");
     
// Tom Bob Kate Sam Tom Alice


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */




Console.ReadLine();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */