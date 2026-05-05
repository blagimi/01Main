#region Работа с файлами. Классы File и FileInfo  

/*
Подобно паре Directory/DirectoryInfo для работы с файлами предназначена пара классов 
File и FileInfo. С их помощью мы можем создавать, удалять, перемещать файлы, получать 
их свойства и многое другое.
*/

#endregion

#region FileInfo

/*
Некоторые полезные методы и свойства класса FileInfo:

CopyTo(path): копирует файл в новое место по указанному пути path

Create(): создает файл

Delete(): удаляет файл

MoveTo(destFileName): перемещает файл в новое место

Свойство Directory: получает родительский каталог в виде объекта DirectoryInfo

Свойство DirectoryName: получает полный путь к родительскому каталогу

Свойство Exists: указывает, существует ли файл

Свойство Length: получает размер файла

Свойство Extension: получает расширение файла

Свойство Name: получает имя файла

Свойство FullName: получает полное имя файла

Для создания объекта FileInfo применяется конструктор, который получает в качестве параметра путь к файлу:

FileInfo fileInf = new FileInfo(@"C:\app\content.txt");
*/

#endregion

#region File

/*
Класс File реализует похожую функциональность с помощью статических методов:

Copy(): копирует файл в новое место

Create(): создает файл

Delete(): удаляет файл

Move: перемещает файл в новое место

Exists(file): определяет, существует ли файл
*/

#endregion

#region Пути к файлам

/*

Для работы с файлами можно применять как абсолютные, так и относительные пути:

*/

// абсолютные пути
string path1 = @"C:\Users\blagi\Documents\content.txt";  // для Windows
string path2 = "C:\\Users\\blagi\\Documents\\content.txt";  // для Windows
//string path3 = "/Users/blagi/Documents/content.txt";  // для MacOS/Linux
 
// относительные пути
string path4 = "MyDir\\content.txt";  // для Windows
//string path5 = "MyDir/content.txt";  // для MacOS/Linux

#endregion

#region Получение информации о файле

string path = @"C:\Users\blagi\Documents\content.txt";
// string path = "/Users/blagi/Documents/content.txt";  // для MacOS/Linux
FileInfo fileInfo = new FileInfo(path);
if (fileInfo.Exists)
{
    Console.WriteLine($"Имя файла: {fileInfo.Name}");
    Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
    Console.WriteLine($"Размер: {fileInfo.Length}");
}
else
{
    System.Console.WriteLine("Файл не найден");
}

#endregion

#region Удаление файла

string path3 = @"C:\Soft\content.txt";
FileInfo fileInf = new FileInfo(path3);
if (fileInf.Exists)
{
   fileInf.Delete();
   // альтернатива с помощью класса File
   // File.Delete(path);
}
else
{
    System.Console.WriteLine("Файл не найден");
}

#endregion

#region Перемещение файла

string path5 =  @"C:\Soft\content.txt";
string newPath = @"C:\Soft\index.txt";
FileInfo fileInf2 = new FileInfo(path5);
if (fileInf2.Exists)
{
   fileInf.MoveTo(newPath);       
   // альтернатива с помощью класса File
   // File.Move(path, newPath);
}
else
{
    Console.WriteLine("Файл не найден");
}

/*
Если файл по новому пути уже существует, то с помощью дополнительного параметра можно указать, 
надо ли перезаписать файл (при значении true файл перезаписывается)


string path =  @"C:\OldDir\content.txt";
string newPath = @"C:\NewDir\index.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
   fileInf.MoveTo(newPath, true);       
   // альтернатива с помощью класса File
   // File.Move(path, newPath, true);
}

*/

#endregion

#region Копирование файла

static void TCopy()
{
    string path =  @"C:\Soft\content.txt";
    string newPath = @"C:\Soft\index2.txt";
    FileInfo fileInf = new FileInfo(path);
    if (fileInf.Exists)
    {
    fileInf.CopyTo(newPath, true);      
    // альтернатива с помощью класса File
    // File.Copy(path, newPath, true);
    }
    else
    {
        Console.WriteLine("Файл не найден");
    }
}

TCopy();

/*
Метод CopyTo класса FileInfo принимает два параметра: путь, по которому файл будет копироваться, 
и булевое значение, которое указывает, надо ли при копировании перезаписывать файл (если true, 
как в случае выше, файл при копировании перезаписывается). Если же в качестве последнего параметра 
передать значение false, то если такой файл уже существует, приложение выдаст ошибку.

Метод Copy класса File принимает три параметра: путь к исходному файлу, путь, по которому файл 
будет копироваться, и булевое значение, указывающее, будет ли файл перезаписываться.
*/

#endregion

#region Чтение и запись файлов

/*
В дополнение к вышерассмотренным методам класс File также предоставляет ряд методов для 
чтения-записи текстовых и бинарных файлов:

AppendAllLines(String, IEnumerable<String>) / AppendAllLinesAsync(String, IEnumerable<String>, 
CancellationToken)

добавляют в файл набор строк. Если файл не существует, то он создается

AppendAllText(String, String) / AppendAllTextAsync(String, String, CancellationToken)

добавляют в файл строку. Если файл не существует, то он создается

byte[] ReadAllBytes (string path) / Task<byte[]> ReadAllBytesAsync (string path, 
CancellationToken cancellationToken)

считывают содержимое бинарного файла в массив байтов

string[] ReadAllLines (string path) / Task<string[]> ReadAllLinesAsync (string path, 
CancellationToken cancellationToken)

считывают содержимое текстового файла в массив строк

string ReadAllText (string path) / Task<string> ReadAllTextAsync (string path, 
CancellationToken cancellationToken)

считывают содержимое текстового файла в строку

IEnumerable<string> ReadLines (string path)

считывают содержимое текстового файла в коллекцию строк

void WriteAllBytes (string path, byte[] bytes) / Task WriteAllBytesAsync 
(string path, byte[] bytes, CancellationToken cancellationToken)

записывают массив байт в бинарный файл. Если файл не существует, он создается. Если существует, 
то перезаписывается

void WriteAllLines (string path, string[] contents) / Task WriteAllLinesAsync (string path, 
IEnumerable<string> contents, CancellationToken cancellationToken)

записывают массив строк в текстовый файл. Если файл не существует, он создается. Если существует, 
то перезаписывается

WriteAllText (string path, string? contents) / Task WriteAllTextAsync (string path, 
string? contents, CancellationToken cancellationToken)

записывают строку в текстовый файл. Если файл не существует, он создается. Если существует, то 
перезаписывается

Как видно, эти методы покрывают практически все основные сценарии - чтение и запись текстовых и 
бинарных файлов. Причем в зависимости от задачи можно применять как синхронные методы, так и их 
асинхронные аналоги.

Например, запишем и считаем обратно в строку текстовый файл:
*/

static async void TRead()
{
    string path = @"c:\Test\content.txt";
 
string originalText = "Hello";
// запись строки
await File.WriteAllTextAsync(path, originalText);
// дозапись в конец файла
await File.AppendAllTextAsync(path, "\nHello work");
 
// чтение файла
string fileText = await File.ReadAllTextAsync(path);
Console.WriteLine(fileText);
}

TRead();

/*
Консольный вывод:

Hello 
Hello work
Стоит отметить, что при добавлении текста я добавил в строку последовательность "\n", 
которая выполняет перевод на следующую строку. Благодаря этому добавляемый текст располагается 
в файле на новой строке.

Если мы хотим, что в файле изначально шло добавление на новую строку, то для записи стоит 
использовать метод WriteAllLines/ WriteAllLinesAsync, а для добавления - AppendAllLines 
/ AppendAllLinesAsync

1
await File.WriteAllLinesAsync(path, new[] { "Hello", "Hello work" });
Аналогично при чтении файла если мы хотим каждую строку файла считать отдельно, то вместо 
ReadAllText / ReadAllTextAsync применяется ReadAllLines / ReadAllLinesAsync.
*/

#endregion

Console.ReadLine();