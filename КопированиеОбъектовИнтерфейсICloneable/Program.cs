﻿using КопированиеОбъектовИнтерфейсICloneable;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* 
 * Копирование объектов. Интерфейс ICloneable.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * В данном случае объекты tom и bob будут указывать на один и тот же объект в памяти, 
 * поэтому изменения свойств для переменной bob затронут также и переменную tom. Чтобы 
 * переменная bob указывала на новый объект, но при этом имела значения из переменной 
 * tom, мы  можем применить клонирование с помощью реализации интерфейса ICloneable:
 *                                                         | Person
 */

var tom = new Person("Tom", 23);
var bob = tom;
bob.Name = "Bob";
Console.WriteLine(tom.Name);            //  Bob

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Поверхностное копирование.
 * Теперь все нормально копируется, изменения в свойствах переменной bob не сказываются 
 * на свойствах из переменной tom.
 *                                                         | Person2, ICloneable
 */

var tom2 = new Person2("Tom", 23);
var bob2 = (Person2)tom2.Clone();
bob2.Name = "Bob";
Console.WriteLine(tom2.Name);           //  Tom

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Для сокращения кода копирования мы можем использовать специальный метод
 * MemberwiseClone(), который возвращает копию объекта:
 * Этот метод реализует поверхностное (неглубокое) копирование.
 * Однако данного копирования может быть недостаточно. В этом случае при копировании новая 
 * копия будет указывать на тот же объект Company:
 *                                                         | Person3, Company, ICloneable
 */

var tom3 = new Person3("Tom", 23, new Company("Microsoft"));
var bob3 = (Person3)tom3.Clone();
bob3.Work.Name = "Google";
Console.WriteLine(tom3.Work.Name);      // Google - а должно быть Microsoft

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Глубокое копирование.
 * Поверхностное копирование работает только для свойст, представляющих примитивные типы
 * но не для сложных объектов. В этом случае надо применять глубокое копирование.
 *                                                          | Person4, Company, ICloneable
 */

var tom4 = new Person4("Tom", 23, new Company("Microsoft"));
var bob4 = (Person4)tom4.Clone();
bob4.Work.Name = "Google";
Console.WriteLine(tom4.Work.Name);      //  Microsoft

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */