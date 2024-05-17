﻿using НаследованиеИнтерфейсов;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Наследование интерфейсов.
 * В отличае от классов к интерфейсам нельзя применять модификатор sealed, что бы
 * запретить наследование интерфейсов. Так же нельзя применять модификатор abstract,
 * поскольку фактически интерфейс представляет абстрактный функционал, который должен
 * быть реализован в классе или структуре (кроме тех что определенны по умолчанию).
 * Однако методы интерфейсов могут использовать ключевое слово new для скрытия методов
 * из базвого интерфейса.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Здесь метод Move из IRunAction скрывает метод Move из базового интерфейса IAction.
 * Это имеет смысл если в базовм интерфейса определена реализация по умолчанию, которую
 * нужно переопределить. В этом случае переменная представляет тип IRunAction то для
 * метода Move вызывается реализация этого интерфейса. Если же переменная представляет
 * тип IAction то для метода Move применяется реализация её интерфейса.
 *                                                        |RunAction,IRunAction,IAction
 */

IRunAction action1 = new RunAction();
action1.Move();                         //  I am moving
IAction action2 = new RunAction();
action2.Move();                         //  I am running 

/*
 * Но класс RunAction может переопределись метод Move сразу для обоих интерфейсов.
 *                                                        |RunAction2,IRunAction,iAction
 */

IAction action3 = new RunAction2();
action3.Move();                         //  I am tired
IRunAction action4 = new RunAction2();
action4.Move();                         //  I am tired

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * При наследовании интерфейсов следует учитывать, что, как и при наследовании классов,
 * производный интерфейс должен иметь тот же уровень доступа или более строгий, чем
 * базовый интерфейс.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */