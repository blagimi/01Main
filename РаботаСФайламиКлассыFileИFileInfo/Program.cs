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

Console.ReadLine();