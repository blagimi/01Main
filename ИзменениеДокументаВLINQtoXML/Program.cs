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


#region Изменение данных

//Для изменения данных в документ xml необходимо получить элемент, который надо изменить, и затем можно отредактировать значения его отдельных атрибутов или вложенных элементов. Изменим элемент person, в котором атрибут name = "Tom":

static async void Ex2()
{
    XDocument xdoc = XDocument.Load("people.xml");

    // получим элемент person с name = "Tom"
    var tom = xdoc.Element("people")?
        .Elements("person")
        .FirstOrDefault(p => p.Attribute("name")?.Value == "Tom");

    if (tom != null)
    {
        //  меняем атрибут name
        var name = tom.Attribute("name");
        if (name != null) name.Value = "Tomas";


        //  меняем вложенный элемент age
        var age = tom.Element("age");
        if (age != null) age.Value = "22";

        xdoc.Save("people.xml");
    }

    // выводим xml-документ на консоль
    Console.WriteLine(xdoc);

}

Ex2();
/*
В результате сформируется и сохранится на диск новый документ:

< people >
  < person name = "Tomas" >
    < company > Microsoft </ company >
    < age > 22 </ age >
  </ person >
  < person name = "Bob" >
    < company > Google </ company >
    < age > 41 </ age >
  </ person >
  < person name = "Sam" >
    < company > JetBrains </ company >
    < age > 28 </ age >
  </ person >
</ people >
*/

#endregion