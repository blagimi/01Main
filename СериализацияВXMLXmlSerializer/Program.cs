using System.Xml.Serialization;

#region Сериализация в XML. XmlSerializer

/*
 * Для удобного сохранения и извлечения объектов из файлов xml может использоваться класс XmlSerializer из пространства имен 
 * System.Xml.Serialization. Данный класс упрощает сохранение сложных объектов в формат xml и последующее их извлечение.

Для создания объекта XmlSerializer можно применять различные конструкторы, но почти все они требуют указания типа данных, 
которые будут сериализоваться и десериализоваться:

XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
 
//[Serializable]
class Person { }
В данном случае XmlSerializer будет работать только с объектами класса Person.

Следует учитывать, что XmlSerializer предполагает некоторые ограничения. Например, класс, подлежащий сериализации, должен 
иметь стандартный конструктор без параметров и должен иметь модификатор доступа public. Также сериализации подлежат только 
открытые члены. Если в классе есть поля или свойства с модификатором private, то при сериализации они будут игнорироваться. 
Кроме того, свойства должны иметь общедоступные геттеры и сеттеры.
 */

#endregion

#region Сериализация

/*
 * Для сериализации (то есть сохранения в форма xml) применяется метод Serialize(). Данный метод имеет ряд версий. Возьмем самую простую из них:

void Serialize (Stream stream, object? o);
В качестве первого параметра передается поток Stream (например, объект FileStream), в который будет идти сериализация. А второй параметр представляет собственно тот объект, который будет сохраняться в формат xml. Например:
 */

// объект для сериализации
Person person = new Person("Tom", 37);

// передаем в конструктор тип класса Person
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

// получаем поток, куда будем записывать сериализованный объект
using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
{
xmlSerializer.Serialize(fs, person);

Console.WriteLine("Object has been serialized");
}

//[Serializable]

/*
 * Итак, класс Person общедоступный, имеет общедоступные свойства и конструктор без параметров, поэтому объекты этого класса подлежат сериализации. При создании объекта XmlSerializer передаем в конструктор тип класса Person.

В метод Serialize передается файловый поток для сохранения данных в файл person.xml и сохраняемый в этот файл объект Person. И если по завершению программы мы откроем файл person.xml, то увидим содержание нашего объекта:


<?xml version="1.0"?>
<Person xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Name>Tom</Name>
  <Age>37</Age>
</Person>
 */

#endregion

#region Десериализация

/*
 * Для десериализации данных xml в объект кода C# применяется метод Deserialize(). Отметим одну из версий этого метода:

object? Deserialize (Stream stream);
В качестве параметра в метод передается объект Stream, который содержит данные в формате xml. Результатом метода является десериализованный объект.

Например, десериализуем данные из выше созданного файла person.xml:
 */

static async void Ex2()
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

    // десериализуем объект
    using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
    {
        Person? person = xmlSerializer.Deserialize(fs) as Person;
        Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
    }
}

Ex2();

#endregion

public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;

    public Person() { }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}