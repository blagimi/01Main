using Индексаторы;
/*
Индексаторы позволяют индексировать объекты и обращаться к 
данным по индексу. Фактически с помощью индексаторов мы можем работать
 с объектами как с массивами. По форме они напоминают свойства со стандартными
  блоками get и set, которые возвращают и присваивают значение.
*/
var microsoft = new Company(
[
    new Person ("Tom", new Person("Bob"), new Person("Sam"), new Person("Alice"))
]);
// Получение объекта из индексатора
Person firstPerson = microsoft[0];
Console.WriteLine(firstPerson.Name);
// Переустановка объекта
microsoft[0] = new Person("Mike");
Console.WriteLine(microsoft[0].Name);

Console.ReadLine();