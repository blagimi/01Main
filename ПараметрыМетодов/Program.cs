﻿/* Параметры позволяют передать в метод некоторые входные данные. Параметры определяются 
 * через заятую в скобках после названия метода в виде:
*  тип_метода имя_метода(тип_параметра1 параметр1, тип_параметра2 параметр2, ...)
*  {
*    // действия метода
*  } 
*/
static void PrintMessage (string message)
{
    Console.WriteLine(message);
}
PrintMessage("HelloWorld");