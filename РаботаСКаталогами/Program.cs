#region Работа с каталогами

/*
Для работы с каталогами в пространстве имен System.IO предназначены сразу два класса:
Directory и DirectoryInfo.
*/

#endregion

#region Класс Directory

/*
Статический класс Directory предоставляет ряд методов для управления каталогами. 
Некоторые из этих методов:

CreateDirectory(path): создает каталог по указанному пути path

Delete(path): удаляет каталог по указанному пути path

Exists(path): определяет, существует ли каталог по указанному пути path. Если существует, 
возвращается true, если не существует, то false

GetCurrentDirectory(): получает путь к текущей папке

GetDirectories(path): получает список подкаталогов в каталоге path

GetFiles(path): получает список файлов в каталоге path

GetFileSystemEntries(path): получает список подкаталогов и файлов в каталоге path

Move(sourceDirName, destDirName): перемещает каталог

GetParent(path): получение родительского каталога

GetLastWriteTime(path): возвращает время последнего изменения каталога

GetLastAccessTime(path): возвращает время последнего обращения к каталогу

GetCreationTime(path): возвращает время создания каталога
*/

#endregion

#region Класс DirectoryInfo

/*

Данный класс предоставляет функциональность для создания, удаления, перемещения и других операций 
с каталогами. Во многом он похож на Directory, но не является статическим.

Для создания объекта класса DirectoryInfo применяется конструктор, который в качестве параметра 
принимает путь к каталогу:

1
public DirectoryInfo (string path);
Основные методы класса DirectoryInfo:

Create(): создает каталог

CreateSubdirectory(path): создает подкаталог по указанному пути path

Delete(): удаляет каталог

GetDirectories(): получает список подкаталогов папки в виде массива DirectoryInfo

GetFiles(): получает список файлов в папке в виде массива FileInfo

MoveTo(destDirName): перемещает каталог

Основные свойства класса DirectoryInfo:

CreationTime: представляет время создания каталога

LastAccessTime: представляет время последнего доступа к каталогу

LastWriteTime: представляет время последнего изменения каталога

Exists: определяет, существует ли каталог

Parent: получение родительского каталога

Root: получение корневого каталога

Name: имя каталога

FullName: полный путь к каталогу

*/

#endregion

#region Directory или DirectoryInfo

/*

Как видно из функционала, оба класса предоставляют похожие возможности. Когда же и что 
использовать? Если надо совершить одну-две операции с одним каталогом, то проще использовать класс 
Directory. Если необходимо выполнить последовательность операций с одним и тем же каталогом, то 
лучше воспользоваться классом DirectoryInfo. Почему? Дело в том, что методы класса Directory 
выполняют дополнительные проверки безопасности. А для класса DirectoryInfo такие проверки не 
всегда обязательны.

Посмотрим на примерах применение этих классов

*/

#endregion

#region Получение списка файлов и подкаталогов

string dirName = "C:\\";
// если папка существует
if (Directory.Exists(dirName))
{
    Console.WriteLine("Подкаталоги:");
    string[] dirs = Directory.GetDirectories(dirName);
    foreach (string s in dirs)
    {
        Console.WriteLine(s);
    }
    Console.WriteLine();
    Console.WriteLine("Файлы:");
    string[] files3 = Directory.GetFiles(dirName);
    foreach (string s in files3)
    {
        Console.WriteLine(s);
    }
}

/*

Обратите внимание на использование слешей в именах файлов. Либо мы используем двойной слеш: 
"C:\\", либо одинарный, но тогда перед всем путем ставим знак @: @"C:\Program Files"

Аналогичный пример с DirectoryInfo:

*/

string dirName2 = @"C:\";
 
var directory = new DirectoryInfo(dirName2);
 
if (directory.Exists)
{
    Console.WriteLine("Подкаталоги:");
    DirectoryInfo[] dirs = directory.GetDirectories();
    foreach (DirectoryInfo dir in dirs)
    {
        Console.WriteLine(dir.FullName);
    }
    Console.WriteLine();
    Console.WriteLine("Файлы:");
    FileInfo[] files2 = directory.GetFiles();
    foreach (FileInfo file in files2)
    {
        Console.WriteLine(file.FullName);
    }
}

#endregion

#region Фильтрация папок и файлов

/*

Методы получения папок и файлов позволяют выполнять фильтрацию. В качестве фильтра в эти методы передается 
шаблон, который может содержать два плейсхолдера: * или символ-звездочка (соответствует любому количеству 
символов) и ? или вопросительный знак (соответствует одному символу)

Например, найдем все папки, которые начинаются на "books":

*/

// класс Directory
string[] dirs2 = Directory.GetDirectories(dirName, "books*.");

// класс Directory
string[] files = Directory.GetFiles(dirName, "*.exe");


#endregion


Console.ReadLine();