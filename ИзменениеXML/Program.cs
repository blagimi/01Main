using System.Xml;


#region Изменение XML-документа

/*
Для редактирования xml-документа (изменения, добавления, удаления элементов) мы можем воспользоваться методами класса XmlNode:

AppendChild: добавляет в конец текущего узла новый дочерний узел

InsertAfter: добавляет новый узел после определенного узла

InsertBefore: добавляет новый узел до определенного узла

RemoveAll: удаляет все дочерние узлы текущего узла

RemoveChild: удаляет у текущего узла один дочерний узел и возвращает его

Класс XmlDocument добавляет еще ряд методов, которые позволяют создавать новые узлы:

CreateNode: создает узел любого типа

CreateElement: создает узел типа XmlDocument

CreateAttribute: создает узел типа XmlAttribute

CreateTextNode: создает узел типа XmlTextNode

CreateComment: создает комментарий

Возьмем xml-документ people.xml из прошлой темы:

<? xml version = "1.0" encoding = "utf-8" ?>
< people >
  < person name = "Tom" >
    < company > Microsoft </ company >
    < age > 37 </ age >
  </ person >
  < person name = "Bob" >
    < company > Google </ company >
    < age > 41 </ age >
  </ person >
</ people >
Добавим в этот xml - документ новый элемент <person>:
*/

XmlDocument xDoc = new();

//C:\Users\blagi\source\repos\blagimi\01Main\ИзменениеXML\people.xml
xDoc.Load("people.xml");
XmlElement? xRoot = xDoc.DocumentElement;

// Создаём новый элемент person
XmlElement personElem = xDoc.CreateElement("person");
// Создаём атрибут name
XmlAttribute nameAttr = xDoc.CreateAttribute("name");
// Создаём элементы company и age
XmlElement companyElem = xDoc.CreateElement("company");
XmlElement ageElem = xDoc.CreateElement("age");
// Создаём текстовые значения для элементов и атрибута
XmlText nameText = xDoc.CreateTextNode("Mark");
XmlText companyText = xDoc.CreateTextNode("Facebook");
XmlText ageText = xDoc.CreateTextNode("30");
// Добавляем узлы
nameAttr.AppendChild(nameText);
companyElem.AppendChild(companyText);
ageElem.AppendChild(ageText);
// Добавляем атрибут name
personElem.Attributes.Append(nameAttr);
// Добавляем элементы company и Age
personElem.AppendChild(companyElem);
personElem.AppendChild(ageElem);
// Добавляем в корневой элемент новый элемент person
xRoot?.AppendChild(personElem);
// Сохраняем изминения xml-документа в файл
//xDoc.Save("people.xml");
xDoc.Save("people.xml");

/*
 * Добавление элементов происходит по одной схеме. Сначала создаем элемент (xDoc.CreateElement("person")). Если элемент сложный, то есть содержит в себе другие элементы, то создаем эти элементы. Если элемент простой, содержащий внутри себя некоторое текстовое значение, то создаем этот текст (XmlText companyText = xDoc.CreateTextNode("Facebook");).

Затем все элементы добавляются в основной элемент person, а тот добавляется в корневой элемент (xRoot.AppendChild(personElem);).

Чтобы сохранить измененный документ на диск, используем метод Save: xDoc.Save("people.xml")

После этого в xml-файле появится следующий элемент:

<?xml version="1.0" encoding="utf-8"?>
<people>
  <person name="Tom">
    <company>Microsoft</company>
    <age>37</age>
  </person>
  <person name="Bob">
    <company>Google</company>
    <age>41</age>
  </person>
  <people name="Mark">
    <company>Facebook</company>
    <age>30</age>
  </people>
</people>
 */

#endregion


#region Удаление узлов

/*
 * Удалим первый ухел xml-документа
 */

XmlNode? firstNode = xRoot?.FirstChild;
if (firstNode is not null) xRoot?.RemoveChild(firstNode);
xDoc.Save("People.xml");

#endregion