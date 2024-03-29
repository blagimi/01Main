﻿/* Поиск количества положительных чисел в массиве
 * Здесь создаем вспомогательную переменную result, которая будет содержать количество положительных чисел. 
 * В цикле прохожим по массиву и, если его элемент больше нуля, добавляем к переменной result единицу.
 */
int[] numbers = [-4, -3, -2, -1, 0, 1, 2, 3, 4];
int result = 0;
foreach(int number in numbers)
{
    if (number>0)
    {
        result++;
    }
}
Console.WriteLine($"Количество положительных чисел {result}");

/* Инверсия массива
 * Поскольку нам надо изменять элементы массива, то для этого используется цикл for. Алгоритм решения задачи подразумевает перебор элементов до середины массива,
 * которая в программе представлена переменной k, и обмен значений элемента, который имеет индекс i, и элемента с индексом n-i-1.
 */
int[] nums = [-4, -3, -2, -1, 0, 1, 2, 3, 4];
int n = nums.Length;    // Длина массива
int k = n / 2;          // Середина массива
int temp;               // Вспомогальный элемент для обмена значениями

for (int i = 0; i < k; i++)
{
    temp = nums[i];
    nums[i] = nums[n - i - 1];
    nums[n-i-1] = temp;
}
foreach (int i in nums)
{
    Console.Write($"{i} \t");
}
Console.WriteLine();
/* Сортировка массива 
* Для сортировки массива выполняем проходы по массиву и сравниваем элементы. 
* Поскольку нам надо последовательно сравнивать каждый элемент массива с каждым (за исключением сравния с самим собой), то здесь применятся вложенный цикл.
* Во внешнем цикле мы берем элемент, который будем сравнивать:
* for (int i = 0; i < nums.Length - 1; i++)
* Далее запускаем вложенный цикл, который начинается, со следующего элемента, и из которого извлекаем элементы, с которыми будем сравнивать тот элемент, 
* которые берется из массива во внешнем цикле:
* for (int j = i + 1; j < nums.Length; j++)
* Если элемент с меньшим индексом больше элемента с большим индексом, то меняем элементы местами.
*
* if (nums[i] > nums[j])
* {
*    temp = nums[i];
*    nums[i] = nums[j];
*    nums[j] = temp;
}*/
int[] sortMass = [54, 7, -41, 2, 4, 2, 89, 33, -5, 12];
int sortTemp;
for (int i = 0; i < sortMass.Length-1; i++)
{
    for (int j = i+1; j < sortMass.Length; j++)
    {
        if (sortMass[i] > sortMass[j])
        {
            sortTemp = sortMass[i];
            sortMass[i] = sortMass[j];
            sortMass[j] = sortTemp;
        }
    }
}
for (int i = 0; i < sortMass.Length; i++)
{
    Console.Write($"{sortMass[i]} \t");
}