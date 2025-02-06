Console.WriteLine("Введите своё имя: ");
string? name = Console.ReadLine();
if(!string.IsNullOrEmpty(name))
    Console.WriteLine("Значение отсутсвует");
else
    Console.WriteLine($"Привет {name}");