﻿using ЧастичныеКлассыИМетоды;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
Частичные классы и методы.
Классы могут быть частичными. То есть можно иметь несколько файлов с определением
одного и того же класса, при компиляции все эти определения будут скомпилированы 
в одно.
Таким образом, два файла в проекте содержит определение одного и того же класса Person, 
которые содержат два разных метода. И оба определенных здесь класса являются частичными. 
Для этого они определяются с ключевым словом partial.
Затем мы можем использовать все методы класса Person:
*/


Person tom = new();
tom.Move();
tom.Eat();

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */   

/*
Частичные методы.
Частичные классы могут содержать частичные методы. Такие методы так же определяются с
ключевым словом partial. Причем определение частичного метода без тела метода находится
в одном частичном классе, а реализация этого же метода - в другом.
В первом классе определен метод Read(). Причем на момент определения первого класса
неизвестно, что представляет собой этот метод, какие действия он будет выполнять.
Тем не менее мы знаем список его параметров и можем вызвать в первом классе.
Второй класс уже непосредственно определяет тело метода Read().
*/

tom.ReadSomething();

/*
Стоит отметить, что по умолчанию к частичным методам применяется ряд ограничений:
- Они не могут иметь модификаторы доступа
- Они имеют тип void
- Они не могут иметь out-параметры
- Они не могут иметь модификаторы virtual, override, sealed, new или extern
Если же они не соответствуют какому-то из этих ограничений, то для них должна быть 
предоставлена реализация. Как, например, в следующем примере частичные методы применяют
 модификатор public:
*/
//public partial void Read(); должно быть указано в обоих классах.


Console.ReadLine();