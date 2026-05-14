#region Чтение и запись текстовых файлов. StreamReader и StreamWriter

/*
Для работы непосредственно с текстовыми файлами в пространстве System.IO определены 
специальные классы: StreamReader и StreamWriter.
*/

#endregion

#region Запись в файл и StreamWriter

/*
Для записи в текстовый файл используется класс StreamWriter. Некоторые из его конструкторов, 
которые могут применяться для создания объекта StreamWriter:

StreamWriter(string path): через параметр path передается путь к файлу, который будет связан с 
потоком

StreamWriter(string path, bool append): параметр append указывает, надо ли добавлять в конец 
файла данные или же перезаписывать файл. Если равно true, то новые данные добавляются в конец 
файла. Если равно false, то файл перезаписываетсяя заново

StreamWriter(string path, bool append, System.Text.Encoding encoding): параметр encoding 
указывает на кодировку, которая будет применяться при записи

Свою функциональность StreamWriter реализует через следующие методы:

int Close(): закрывает записываемый файл и освобождает все ресурсы

void Flush(): записывает в файл оставшиеся в буфере данные и очищает буфер.

Task FlushAsync(): асинхронная версия метода Flush

void Write(string value): записывает в файл данные простейших типов, как int, double, char, 
string и т.д. Соответственно имеет ряд перегруженных версий для записи данных элементарных 
типов, например, Write(char value), Write(int value), Write(double value) и т.д.

Task WriteAsync(string value): асинхронная версия метода Write. Обратите внимание, что 
асинхронные версии есть не для всех перегрузок метода Write.

void WriteLine(string value): также записывает данные, только после записи добавляет в файл 
символ окончания строки

Task WriteLineAsync(string value): асинхронная версия метода WriteLine

Рассмотрим запись в файл на примере:
*/

static async void WStream()
{
    string path = "note1.txt";
    string text = "Hello World\nHello ";
    
    // полная перезапись файла 
    using (StreamWriter writer = new StreamWriter(path, false))
    {
        await writer.WriteLineAsync(text);
    }
    // добавление в файл
    using (StreamWriter writer = new StreamWriter(path, true))
    {
        await writer.WriteLineAsync("Addition");
        await writer.WriteAsync("4,5");
    }
}

/*
В данном случае два раза создаем объект StreamWriter. В первом случае если файл существует, 
то он будет перезаписан. Если не существует, он будет создан. И в нее будет записан текст из 
переменной text. Во втором случае файл открывается для дозаписи, и будут записаны атомарные 
данные - строка и число.

По завершении в папке программы мы сможем найти файл note.txt, который будет иметь следующие 
строки:

Hello World
Hello
Addition
4,5
В пример выше будет использоваться кодировка по умолчанию. но также можно задать ее явным образом:


using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.Default))
{
    // операции с writer
}
*/

#endregion


Console.ReadLine();