
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

Console.WriteLine("Введите своё имя: ");
string? name = Console.ReadLine();
if(!string.IsNullOrEmpty(name))
    Console.WriteLine("Значение отсутсвует");
else
    Console.WriteLine($"Привет {name}");