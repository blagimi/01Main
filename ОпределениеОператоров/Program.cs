using ОпределениеОператоров;
Counter counter1 = new Counter { Value = 23 };
Counter counter2 = new Counter { Value = 45 };
bool result = counter1 > counter2;
Console.WriteLine(result); // false

Counter counter3 = counter1 + counter2;
Console.WriteLine(counter3.Value);  // 23 + 45 = 68

