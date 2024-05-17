﻿using РеализацияИнтерфейсовВБазовыхИПроизводныхКлассах;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Если класс применяет интерфейс, то этот класс должен реализовать все методы и
 * свойства интерфейса, которые не имеют реализации по умолчанию. Однако можно и не
 * реализовывать методы, сделав их абстрактными, переложив право их реализации на 
 * производные классы.
 *                                                      |Driver,Person,IMovable
 */


Driver driver = new();
driver.Move();                          //  Шофер ведет машину

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * При реализации интерфейса учитываются так же методы и свойства, унаследованные от
 * базового класса. Здесь класс HeroAction реализиет интрефейс IAction, однако для 
 * реализации метода Move из интерфейса применяется метод Move, унаследованный от
 * базового класса BaseAction. Таким образом, класс HeroAction может не реализовать
 * метод Move, так как этот метод уже определен в базовом классе BaseAction. Классы
 * при наследовании должны быть указны ДО интерфейсов при такой реализации.
 *                                                      |BaseAction,HeroAction,IAction
 */

IAction action = new HeroAction();
action.Move();                          //  Move in BaseAction

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Изминение реализации интерфейсов в производных классах.
 * Базовый класс может реализовать интерфейс, но в классе наследнике необходимо
 * изменить реализацию этого интерфейса. В этом случае можно использовать
 * переопределение либо скрытие метода или свойства интерфейса.
 * Первый вариант - переопределение виртуальных,абстрактных методов:
 *                                                     |BaseAction2,HeroAction2,IAction
 */
BaseAction2 action2 = new HeroAction2();
action2.Move();                         //  Move in HeroAction2
/* При вызове метода через переменную интерфейса, если она ссылается на объект
 * производного класса, будет использоваться реализация из произовдного класса.*/
IAction action3 = new HeroAction2();
action3.Move();                         //  Move in HeroAction2
HeroAction2 action4 = new();
action4.Move();                         //  Move in HeroAction2
/*
 * Второй вариант - скрытие метода в производном классе:
 * Так как интерфейс реализован в классе BaseAction2 то через переменную action 
 * можно обратиться только к реализации метода Move из базового класса BaseAction2.
 *                                                      |BaseActino2,HeroAction3,IAction
 */
BaseAction2 action5 = new HeroAction3();
action5.Move();                         //  Move in BaseAction2
IAction action6 = new HeroAction3();
action6.Move();                         //  Move in BaseAction2
HeroAction3 action7 = new();
action7.Move();                         //  Move in HeroAction3

/*
 * Третий вариант - повторная реализация интерфейса в классе-наследнике. В этом
 * случае реализация метода из базового класса будет игнорироваться. Так же
 * стоит отметить что в случае с переменной action8 по прежнему действует 
 * ранее связывание, в силу которого через нее можно вызвать только реализацию
 * из базового класса, который эта переменная и представляет.
 *                                                       |BaseAction3,HeroAction4,IAction         
 */
BaseAction3 action8 = new HeroAction4();
action8.Move();                         //  Move in BaseAction3
IAction action9 = new HeroAction4();
action9.Move();                         //  Move in HeroAction4
HeroAction4 action10 = new();
action10.Move();                        //  Move in HeroAction4

/*
 * Четверный вариант - явная реализация интерфейса. В этом случае для переменной
 * IAction будет использоваться явная реализация интерфейса IAction, а для 
 * переменной HeroAction5 по прежнему будет использоваться неявная реализация.
 *                                                       |BaseAction3,HeroAction5,IAction
 */
BaseAction3 action11 = new HeroAction5();
action11.Move();                        // Move in BaseAction3
IAction action12 = new HeroAction5();
action12.Move();                        // Move in IAction
HeroAction5 action13 = new();
action13.Move();                        // Move in HeroAction5
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */