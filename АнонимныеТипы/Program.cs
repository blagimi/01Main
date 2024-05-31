﻿using АнонимныеТипы;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */  

/*
Анонимные типы позволяют создать объект с некоторым набором свойств без определения
класса. Анонимный тип определеяется с помощью ключевого слова var и инициализатора 
объектов.
*/
var user = new {Name = "Tom", Age = 34};
Console.WriteLine(user.Name);

/*
В данном случае user - это объект анонимного типа, у которого определены два свойства
Name и Age. Так же можно использовать его свойства как и у обычных объектов класса.
Ограничением является что свойства анонимных типов доступны только для чтения.
При этом во время компиляции компилятор сам будет создавать для него имя типа и 
использовать это имя при обращении к объекту. Нередко анонимные типы имеют имя
"<>f_AnonymousType0'2" 
Для исполняющей среды CLR анонимные типы будут так же как и классы представлять
ссылочный тип.
Если в программе используется несколько объектов анонимных типов с одинаковым 
набором свойств, то для них компилятор создаст одного определение анонимного типа.
*/
var student = new { Name = "Alice", Age = 21};
var manager = new { Name = "Bob", Age = 26, Company = "Microsoft"};

Console.WriteLine(user.GetType().Name);             //  <>f__AnonymousType1'2
System.Console.WriteLine(student.GetType().Name);   //  <>f__AnonymousType1'2
System.Console.WriteLine(manager.GetType().Name);   //  <>f__AnonymousType1'3

/*
Здесь user и student будут иметь одно и то же определение анонимного типа. Однако
подобные объекты нельзя преобразовать к какому-нибудь другому типу. Например,
классу, даже если он имеет подобный набор свойств.
Следует учитывать что свойства анонимного объекта доступны для установки только
в инициализаторе. Вне инициализатора присвоить им значение нельзя.
//student.Age = 32;                                 //  Ошибка
Кроме использованной выше формы инициализации, когда присваивается значение можно 
использовать инициализаторы с проекцией (project initializers) когда можно передать
в инициализатор некоторые индентификаторы, имена которых будут использоваться как
названия свойств.
*/
Person tom = new("Tom");
int age = 34;
var worker = new {tom.Name, age};   // Инициализатор с проекцией
System.Console.WriteLine(worker.Name);
System.Console.WriteLine(worker.age);    

/*
В данном случае определение анонимного объекта фактически будет идентично 
var worker = new {Name = tom.Name, age = age};
Названия свойств и переменных (Name и age) будут использовать в качестве
названий свойств объекта.
*/
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */  
/*
Так же можно определять массивы объектов анонимных типов. 
*/
var people = new[]
{
    new {Name = "Tom"},
    new {Name = "Bob"}
};
foreach (var p in people)
{
    System.Console.WriteLine(p.Name);
}

/*
Зачем нужны анонимные типы? Иногда возникает задача использовать один тип в одном
узком контексте или даже раз. Создание класса для подобного типа может быть избыточным.
Если нужно добавить свойство,то можно сразу на месте анонимного объекта это и сделать.
В случае с классом придется изменять еще и класс, который может больше нигде не
использоваться. Типичная ситуация - получение результата выборки из базы данных. 
Объекты используются только для получения выборки, часто больше нигде не используются,
и создание классов для них избыточно. А вот анонимный объект прекрасно подходит для
временного хранения выборки.
*/


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */  

Console.ReadLine();