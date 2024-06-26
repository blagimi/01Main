﻿/*
 * Null и ссылочные типы.
 * Кроме стандартных значений типа числе, строк C# имеет специальное значение null.
 * Которое указывает на отсутсвие значения или отсуствия данных. Null значение
 * по умолчанию для всех для всех ссылочных типов.
 */
//string name = null;
//Console.WriteLine(name);

/* 
 * Но начиная с версии C# 8.0 в язык была введена концепция ссылочных nullable-типов 
 * (nullable reference types) и nullable aware context - nullable-контекст, в котором можно использовать ссылочные nullable-типы.
 */

/*
 * Что бы определить переменную/параметр ссылочного типа, как переменную/параметр
 * котором можно присваивать значение null, после названия указывается знак вопроса ?
 */
string? name = null;
Console.WriteLine(name);    // ничего не выведет
/*
 * Зачем нужно это значение null? В различных ситуациях бывает удобно, чтобы объекты могли принимать значение null, то есть были бы не определены. 
 * Стандартный пример - работа с базой данных, которая может содержать значения null. И мы можем заранее не знать, что мы получим из базы данных - какое-то определенное значение или же null.
 * При этом подобные ссылочные типы, которые допускают присвоение значения null, доступно только в nullable-контексте. Для nullable-контекста характерны следующие особенности:
 * Переменную ссылочного типа следует инициализировать конкретным значением, ей не следует присваивать значение null
 * Переменной ссылочного nullable-типа можно присвоить значение null, но перед использование необходимо проверять ее на значение null.
 */

/* Оператор ! (null-forgiving operator)
 * Оператор ! (null-forgiving operator) позволяет указать, что переменная ссылочного типа не равна null:
 */

/* Здесь если бы мы не использовали оператор !, а написали бы PrintUpper(name), то компилятор высветил бы нам предупреждение. 
 * Но в самом методе мы итак проверяем на null, поэтому даже если в метод передается null, то мы не столкнемся ни с какими проблемами. 
 * И чтобы убрать ненужное предупреждение, применяется данный оператор. То есть данный оператор не оказывает никакого влияния во время 
 * выполнения кода и предназначен только для статического анализа компилятора. Во время выполнения выражение name! будет аналогично значению name
 * */
string? name2 = null;
PrintUpper(name2!);

static void PrintUpper(string? text)
{
    if (text == null) Console.WriteLine("null");
    else Console.WriteLine(text.ToUpper());
}