// С помощью ключевого слова params можно передавать неопределенное количество параметров
static void Sum (params int[] numbers)
{
    int result = 0;
    foreach (var n in numbers)
    {
        result += n;
    }
    System.Console.WriteLine(result);
}
int[] nums = {1,2,3,4,5};  
Sum(nums);      // 15
Sum(1,2,3,4);   // 10
Sum(1,2,3);     // 6
Sum();          // 0
/*
Передавать таким образом можно либо одномерный массив, либо отдельные значения либо ничего.
Записывать его ВСЕГДА нужно вконце остальных параметров иначе будет ошибка. 
*/

// Нужно отличать от передачи массива вместо параметра.
void Sum2 (int[] numbers, int initialValue)
{
    int result = initialValue;
    foreach (int n in numbers)
    {
        result += n;
    }
    System.Console.WriteLine(result);
} 
Sum2(nums,10); // 25
//Sum2(1,2,3,4); Должен передаваться массив
// Параметры можно указывать как обычно, типизация на ввод. 
Console.ReadKey();