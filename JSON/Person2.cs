using System;
using JSON;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON;

public class Person2
{
    [JsonPropertyName("firstname")]
    public string Name { get;}
    [JsonIgnore]
    public int Age { get; set; }
    public Person2(string name, int age)
    {
        Name = name;
        Age = age;
    }
}