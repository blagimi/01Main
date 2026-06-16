using System.Xml.Linq;

#region Изменение документа в LINQ to XML

/*
 * Возьмем xml-файл people.xml из прошлых тем:
 * 
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
</people>
 */


#endregion

#region Добавление данных

/*
 * Для добавления данных в документ xml у объекта XElement применяется метод Add(), в который передается добавляемый объект:
 */

XDocument xdoc = XDocument.Load("people.xml");
XElement? root = xdoc.Element("people");

if (root != null)
{
    // добавляем новый элемент
    root.Add(new XElement("person",
                new XAttribute("name", "Sam"),
                new XElement("company", "JetBrains"),
                new XElement("age", 28)));

    xdoc.Save("people.xml");
}

// выводим xml-документ на консоль
Console.WriteLine(xdoc);

/*
 * В результате сформируется и сохранится на диск новый документ:

<people>
  <person name="Tom">
    <company>Microsoft</company>
    <age>37</age>
  </person>
  <person name="Bob">
    <company>Google</company>
    <age>41</age>
  </person>
  <person name="Sam">
    <company>JetBrains</company>
    <age>28</age>
  </person>
</people>
 */

#endregion