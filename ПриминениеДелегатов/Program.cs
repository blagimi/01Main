using ПриминениеДелегатов;

Account account = new Account(200);
// Добавляем в делегат ссылку на методы
account.RegisterHandler(PrintSimpleMessage);
account.RegisterHandler(PrintColorMessage);
// Два раза подряд пытаемся снять деньги
account.Take(100);
account.Take(150);

// Удаляем делегат
account.UnregisterHandler(PrintColorMessage);
// снова пытаемся снять деньги
account.Take(50);

void PrintSimpleMessage(string message) => Console.WriteLine(message);
void PrintColorMessage(string message)
{
    // Устанавливаем красный цвет символов
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    // Сбрасываем настройки цвета
    Console.ResetColor();
}