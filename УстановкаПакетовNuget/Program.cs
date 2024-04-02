using Newtonsoft.Json;

Person tom = new("Tom", 38);
string jsonInput = JsonConvert.SerializeObject(tom);
Console.WriteLine(jsonInput);
class Person(string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
}