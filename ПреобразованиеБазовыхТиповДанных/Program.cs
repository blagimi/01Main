// See https://aka.ms/new-console-template for more information
// Значение типа byte помещается в int 
byte a = 4;
int b = a + 70;
Console.WriteLine(b);
//Явное преобразование используемого типа в byte
byte a2 = 4;
byte b2 =(byte)(a2 + 70);
Console.WriteLine(b2);