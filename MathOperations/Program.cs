int x1 = 5;
int z1 = --x1; // z1=4; x1=4
Console.WriteLine($"{x1} - {z1}");

int x2 = 5;
int z2 = x2--; // z2=5; x2=4
Console.WriteLine($"{x2} - {z2}");

int a = 3;
int b = 5;
int c = 40;
int d = c-- - b * a;    // a=3  b=5  c=39  d=25
Console.WriteLine($"a={a}  b={b}  c={c}  d={d}");

int a2 = 3;
int b2 = 5;
int c2 = 40;
int d2 = (c2 - (--b2)) * a2;    // a=3  b=4  c=40  d=108
Console.WriteLine($"a={a2}  b={b2}  c={c2}  d={d2}");