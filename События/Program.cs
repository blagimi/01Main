using События;
/*
 * События. 
 * События сигнализируют системе о том, что произошло определенное действие. И если надо отстледить
 * эти действия, то применяются события.
 */

/*
 * В конструкторе устанавливаем начальную сумму, которая храниться в свойстве Sum.
 * С помощью метода Put можно добавлять средства на счёт, а с помощью метода Take, снять 
 * деньги со счёта.
 */
/*
 * Обработчики события.
 * С событием может быть связан один или несколько обработчиков. Обработчики это именно то что
 * выполняется при вызове события. В качестве обработчиков могут выступать методы. Каждый обработчик
 * событий по списку параметров и возвращаемому типу должен соответствовать делегату, который
 * представляет событие. Для добавления обработчика используется операция +=
 * Event += обработчик события;
 * В качестве обработчиков могут использоваться не только обычные методы, но так же делегаты,
 * анонимные методы и лямбда-выражения.
 */
Account testAccount = new(100);
testAccount.NotifyEvent += DisplayMessage;  // Добавление обработчика для события
testAccount.NotifyEvent += DisplayRedMessage;   //  Добавление еще одного обработчика
testAccount.Put(20);
Account.CheckBalance(testAccount);      //  120
testAccount.NotifyEvent -= DisplayRedMessage;   // Удаление обработчика
testAccount.Take(70);
Account.CheckBalance(testAccount);      //  50
testAccount.Take(180);                  //  Недостаточно средств на счёте
Account.CheckBalance(testAccount);      //  50
Console.WriteLine("-------------");

Account testAccountDelegate = new(100);
//  Установка делегата, который указывает на метод DisplayMessage
testAccountDelegate.NotifyEvent += new AccountHandler(DisplayMessage);
//  Установка метода в качестве обработчика
testAccountDelegate.NotifyEvent += DisplayMessage;
testAccountDelegate.Put(30);    // Разницы между ними нет.

Account testAccountAnonimMethod = new(100);
// Установка анонимного метода в качестве обработчика
testAccountAnonimMethod.NotifyEvent += delegate (string mes)
{
    Console.WriteLine(mes);
};
testAccountAnonimMethod.Put(20);

Account testAccountLambda = new(100);
// Установка лямбда-выражения в качестве обработчика события
testAccountLambda.NotifyEvent += message => Console.WriteLine(message);
testAccountLambda.Put(40);

/*
 * Управление обработчиками.
 * С помощью специальных акссесоров add/remove можно управлять добавлением и удалением обработчиков.
 * Такая функциональность редко требуется, но её можно использовать.
 */
Console.WriteLine("-------------");
Account2 testAccount2 = new(100);
testAccount2.Notify += DisplayMessage;  // DisplayMessage добавлен
testAccount2.Put(20);
testAccount2.Notify -= DisplayMessage;  // DisplayMessage удален
testAccount2.Put(20);

Console.WriteLine("-------------");
/*
 * Передача данных события.
 * Нередко при возникновении события обработчику события требуется передать некоторую информацию
 * о событии. По сравнению с предыдущей версией в Account3 изменилось количество параметров у
 * делегата и соответственно количество параметров при вызове события. Теперь делегат AccountHandler
 * в качестве первого параметра принимает объект, который вызвал событие, то есть текущий объект Account3.
 * А в качестве второго параметра принимает объект AccountEventArgs, который хранит информацию о событии,
 * получаемую через конструктор.
 */
Account3 testAccountEventArgs = new(100);
testAccountEventArgs.Notify += NewDisplayMessage;
testAccountEventArgs.Put(20);
testAccountEventArgs.Take(70);
testAccountEventArgs.Take(150);

static void DisplayMessage(string message) => Console.WriteLine(message);   // Обработчик события
static void DisplayRedMessage(string message)   //  Обработчик события 2
{
    Console.ForegroundColor=ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}
/*
 * По сравнению с предыдущим вариантом тут изменяется количество параметров и их использование в 
 * обработчике NewDisplayMessage. Благодаря первому параметру в методе можно получить информацию
 * об отправителе события - счёте, с которым производится операция. А через второй параметр можно 
 * получить информацию о состоянии операции.
 */
static void NewDisplayMessage(Account3 sender, AccountEventArgs newEvent)
{
    Console.WriteLine($"Сумма транзакции: {newEvent.Sum}");
    Console.WriteLine(newEvent.Message);
    Console.WriteLine($"Текущая сумма на счёте: {sender.Sum}");
}