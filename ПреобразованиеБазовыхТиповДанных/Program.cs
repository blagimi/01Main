// See https://aka.ms/new-console-template for more information
// Значение типа byte помещается в int 
byte a = 4;
int b = a + 70;
Console.WriteLine(b);
//Явное преобразование используемого типа в byte
byte a2 = 4;
byte b2 =(byte)(a2 + 70);
Console.WriteLine(b2);
//Сужающее преобразование до меньшей разрядности
ushort a3 = 4;
byte b3 =(byte)a3;
Console.WriteLine(b3);
//Неявные преобразования, последний разряд для знака 0 положительные
byte c4 = 4;    //  0000100
ushort b4 = c4; //  000000000000100 дополнительные нули
Console.WriteLine(b4);
// 1 для отрицательных
sbyte a5 = -4;   //  1111100
short b5 = a5;   //  11111111111100
Console.WriteLine(b5);
//Потеря точности данных
int a6 = 33;
int b6 = 600;
byte c6 = (byte)(a6 + b6);
Console.WriteLine(c6);  // 121
/* 
 * Результатом сложения является число 633 не входящее в диапозон для byte
 * поэтому старшие биты усеклись в итоге получилось число 121. 
 * Число не должно было превышать значение 255 иначе нужно выбрать другой тип данных
 */