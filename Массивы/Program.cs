// See https://aka.ms/new-console-template for more information
//Массив набор однотипных данных
// тип [] название;
int[] nums = new int[4];
string[] people = [ " Tom", "Sam", "Bob" ];
/*
 * Так же можно записать как
 * int[] nums2 = new int[4] { 1, 2, 3, 5 };
 
 * int[] nums3 = new int[] { 1, 2, 3, 5 };
 
 * int[] nums4 = new[] { 1, 2, 3, 5 };
 
 * int[] nums5 = { 1, 2, 3, 5 };
 */
Console.WriteLine("1) --- ");
Console.WriteLine(nums.Length);     // 4 элемента
Console.WriteLine("2) --- ");
Console.WriteLine(people.Length);   // 3 элемента
int[] numbers = [ 1, 2, 3, 5 ];
Console.WriteLine("3) --- ");
Console.WriteLine(numbers[3]);      // 5 Получение элемента массива. Нумерация начинается с 0
var n = numbers[1];                 // Получение элемента массива в переменную
Console.WriteLine("4) --- ");
Console.WriteLine(n);               // 2
Console.WriteLine("5) --- ");
numbers[1] = 505;                   // Замена значения элемента массива по инденксу
Console.WriteLine(numbers[1]);      // 505
//Console.WriteLine(numbers[7]);    // При выходе за границы массива выводится ошибка
Console.WriteLine("6) --- ");
Console.WriteLine(numbers[^1]);     // Получение элемента массива с конца ^ - номер с конца
Console.WriteLine("Циклы --- ");
// Перебор массивов можно осуществляется с помощью циклов, например foreach
foreach (int i in numbers)          // Вывод элементы в виде только для чтения
{
    Console.Write($"{i} ");         // Вывод всех элементов массива в строку
}
Console.WriteLine();
// for
for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"{numbers[i]} ");         // Вывод всех элементов массива в строку
}
Console.WriteLine();
// while
int j = 0;
while (j < numbers.Length)
{
    Console.Write($"{numbers[j]} ");
    j++;
}
Console.WriteLine();
// Многомерные массивы
int[] nums1 = [0, 1, 2, 3, 4, 5];               // Одномерный массив
// [0][1][2][3][4][5][6]
int[,] nums2 = { { 0, 1, 2 }, { 3, 4, 5 } };    // Двумерный массив
Console.WriteLine(nums1.Length);
Console.WriteLine(nums2.Length);
// [0][1][2]
// [3][4][5]
/* 
 * Возможные описания двумерных массивов
 * int[,] nums1;
 * int[,] nums2 = new int[2, 3];
 * int[,] nums3 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
 * int[,] nums4 = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
 * int[,] nums5 = new [,]{ { 0, 1, 2 }, { 3, 4, 5 } };
 * int[,] nums6 = { { 0, 1, 2 }, { 3, 4, 5 } };
 */
//Определенную сложность может представлять перебор многомерного массива. Прежде всего надо учитывать, что длина такого массива - это совокупное количество элементов.
int[,] numbers3 = { { 1, 2, 3 }, { 4, 5, 6 } };
foreach (int i in numbers3)
    Console.Write($"{i} "); // 1 2 3 4 5 6
Console.WriteLine();
//В данном случае длина массива numbers равна 6. И цикл foreach выводит все элементы массива в строку
/*У каждого массива есть метод GetUpperBound(номер_размерности), который возвращает индекс последнего элемента в определенной размерности.
*И если мы говорим непосредственно о двухмерном массиве, то первая размерность (с индексом 0) по сути это и есть таблица. И с помощью выражения
*numbers.GetUpperBound(0) + 1
*можно получить количество строк таблицы, представленной двухмерным массивом. А через numbers.Length / количество_строк
*можно получить количество элементов в каждой строке
*/
int rows = numbers3.GetUpperBound(0) + 1;               // Количество строк
int columns = numbers3.Length / rows;                   // Количество столбцов
Console.WriteLine($"Количество строк: {rows}");         // 2
Console.WriteLine($"Количество столбцов: {columns}");   // 3
for  (int i2 = 0; i2 < rows; i2++)
{
    for (int j2 = 0; j2 < columns; j2++)
    {
        Console.Write($"{numbers3[i2, j2]} \t");
    }
    Console.WriteLine();               // 1 2 3
}                                      // 4 5 6
Console.WriteLine();
// Зубчатый массив или массив массивов
int[][] mMass =
[
    [1,2],                  // Выделение памяти для первого подмассива
    [1,2,3],                // Выделение памяти для второго подмассива
    [1,2,3,4,5],            // Выделение памяти для третьего подмассива
];
/*
 * Алтернативная запись 
 * int[][] nums = new int[3][];
 * nums[0] = new int[2] { 1, 2 };          
 * nums[1] = new int[3] { 1, 2, 3 };       
 * nums[2] = new int[5] { 1, 2, 3, 4, 5 };
 * или
 * int[][] mMass = new int[3][];
 * mMass[0] = [1,2];                
 * mMass[1] = [1,2,3];          
 * mMass[2] = [1,2,3,4,5];
 */
// Для перебора зубчатых массивов используются вложенные циклы foreach
foreach (int[] row in mMass)
{
    foreach (int number in row)
    {
        Console.Write($"{number} \t");
    }
    Console.WriteLine();
}
// for
Console.WriteLine();
for (int i3 = 0; i3<mMass.Length;i3++)
{
    for (int j3 = 0; j3 < mMass[i3].Length; j3++)
    {
        Console.Write($"{mMass[i3][j3]} \t");
    }
    Console.WriteLine();
}