﻿// See https://aka.ms/new-console-template for more information
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
