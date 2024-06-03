﻿/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
Кортежи.
Кортежи предоставляют удобный способ для работы с набором значений, который был 
добавлен в версии C# 7.0. Кортеж представляет набор значений, заключенных в 
круглые скобки:
var tuple = (5, 10);
В данном случае определен кортеж tuple, который имеет два значения: 5 и 10. 
В дальнейшем мы можем обращаться к каждому из этих значений через поля с названиями:
Item[порядковый_номер_поля_в_кортеже]
*/

var tuple = (5, 10);
Console.WriteLine(tuple.Item1);         //  5
Console.WriteLine(tuple.Item2);         //  10
tuple.Item1 += 26;
Console.WriteLine(tuple.Item1);         //  31



/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

Console.ReadLine();