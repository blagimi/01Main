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


Console.ReadLine();