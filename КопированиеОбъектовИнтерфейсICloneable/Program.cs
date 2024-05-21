using КопированиеОбъектовИнтерфейсICloneable;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* 
 * Копирование объектов. Интерфейс ICloneable.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */



var tom = new Person("Tom", 23);
var bob = tom;
bob.Name = "Bob";
Console.WriteLine(tom.Name); // Bob

var tom2 = new Person2("Tom", 23);
var bob2 = (Person2)tom2.Clone();
bob2.Name = "Bob";
Console.WriteLine(tom2.Name); // Tom