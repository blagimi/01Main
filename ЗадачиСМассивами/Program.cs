// See https://aka.ms/new-console-template for more information
//Поиск количества положительных чисел в массиве
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

// Инверсия массива
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