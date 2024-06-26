﻿/*
 * Статические члены и модификатор static
 * Кроме обычных полей, методов, свойств классы и структуры могут иметь статические поля, методы, свойства. 
 * Статические поля, методы, свойства относятся ко всему классу/всей структуре и для обращения к подобным членам необязательно создавать экземпляр класса / структуры
 */

/* 
 * Статические поля
 * В данном случае класс Person имеет два поля: age (хранит возраст человека) и retirementAge (хранит пенсионный возраст). 
 * Однако поле retirementAge является статическим. Оно относится не к конкретному человеку, а ко всем людям. 
 * (В данном случае для упрощения пренебрежем тем фактом, что в зависимости от пола и профессии пенсионный возраст может отличаться.) 
 * Таким образом, поле retirementAge относится не к отдельную объекту и хранит значение НЕ отдельного объекта класса Person, 
 * а относится ко всему классу Person и хранит общее значение для всего класса.
 */
using СтатическиеЧлены;

Person bob = new(68);
bob.CheckAge();
Person tom = new(33);
tom.CheckAge();
Person.retirementAge = 67;  // Обращение к статическому полю и его изминение отражающееся на всех обьектах класса. 
Person tom2 = new(33);
tom2.CheckAge();

/*
 * Статические свойства
 * В данном случае доступ к статической переменной retirementAge опосредуется с помощью статического свойства RetirementAge.
 * Таким образом, переменные и свойства, которые хранят состояние, общее для всех объектов класса / структуры, следует определять как статические.
 */

PersonProp bob2 = new(70);
bob2.CheckAge();
PersonProp.RetirementAge = 101; // Значение вышло за пределы поэтому используется значение с инициализатора
Console.WriteLine(PersonProp.RetirementAge);    // 65

/* 
 * Нередко статические поля и свойства применяются для хранения счетчиков.
 * Например, мы хотим иметь счетчик, который позволял бы узнать, сколько объектов Person создано:
 * В данном случае в классе Person счетчик хранится в приватной переменной counter, 
 * значение которой увеличивается на единицу при создании объекта в конструкторе. 
 * А с помощью статического свойства Counter, которое доступно только для чтения, мы можем получить значение счетчика.
 */

PersonCounter _     = new ();
PersonCounter _1    = new ();
PersonCounter _2   = new ();
Console.WriteLine(PersonCounter.Counter);

/*
 * Статические методы
 * Статические методы определяют общее для всех объектов поведение, которое не зависит от конкретного объекта. 
 * Для обращения к статическим методам также применяется имя класса / структуры:
 * В данном случае в классе Person определен статический метод CheckRetirementStatus(), который в качестве параметра принимает объект Person и проверяет его пенсионный статус.
 * Следует учитывать, что статические методы могут обращаться только к статическим членам класса. 
 * Обращаться к нестатическим методам, полям, свойствам внутри статического метода мы не можем.
 */

PersonMethod jeff = new(50);
PersonMethod.CheckRetirementStatus(jeff);   // 15

/*
 * Статический конструктор
 * Статические конструкторы не должны иметь модификатор доступа и не принимают параметров
 * Как и в статических методах, в статических конструкторах нельзя использовать ключевое слово this для ссылки на текущий объект класса и можно обращаться только к статическим членам класса
 * Статические конструкторы нельзя вызвать в программе вручную. Они выполняются автоматически при самом первом создании объекта данного класса или при первом обращении к его статическим членам (если таковые имеются)
 * Статические конструкторы обычно используются для инициализации статических данных, либо же выполняют действия, которые требуется выполнить только один раз
 */
Console.WriteLine(PersonConstructor.RetirementAge); // 65

/*
 * Статические классы
 * Статические классы объявляются с модификатором static и могут содержать только статические поля, свойства и методы. Например, определим класс, который выполняет ряд арифметических операций:
 */
Console.WriteLine(Operations.Add(5,4));         // 9
Console.WriteLine(Operations.Substract(5,4));   // 1
Console.WriteLine(Operations.Multiply(5,4));    // 20