/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Ковариативность и контрвариативность делегатов.
 * Ковариативность делегата предполагает,  что возвращаемым типом будет производный тип.
 * Контрвариативность делегата предполагает, что типом параметра может быть более универсальный тип.
 */
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
MessageBuilder messageBuilder = writeEmailMessage;
Message message = messageBuilder("Hello");
message.Print();
EmailMessage writeEmailMessage(string text) => new EmailMessage(text);
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Контрвариативность.
 * Позволяет присваивать делегату метод, тип параметра которого является более универсальным по отношению
 * к типу параметра делегата. Делегат в качестве параметра принимает объект EmailMessage, ему можно присвоить
 * метод, у которого параметр представляет базовый тип Message. В делегат при его вызове все равно можно
 * передать только объекты типа EmailMessage, а любой объект типа EmailMessage является типа Mesage который
 * используется в методе.
 */
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
EmailReceiver emailBox = ReceiveMessage;    //  Контрвариативность
emailBox(new EmailMessage("Welcome"));      // Email: Welcome
void ReceiveMessage(Message message) => message.Print();
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* Ковариативность и контрвариативность в обобщенных делегатах.
 * Использование ковариативный обобщенный делегат.
 */
// Возвращение EmailMessage - конкретный тип
MessageBuilder2<EmailMessage> EmailMessageWriter = (string text) => new EmailMessage(text);
// Возвращение обобщенного типа Message
MessageBuilder2<Message> messagebuilder = EmailMessageWriter;   // Ковариантивность
Message message2 = messageBuilder("Hello Tom");  // Вызов делегата
message2.Print();   // Email: Hello Tom
/*
 * Благодаря использованию out можно присвоить делегату типа MessageBuilder2<Message> (более общий тип)
 * делегат MessageBuilder<EmailMessage> (более конкретный тип).
 */

/*
 * Контрвариативность.
 * Использования контрвариативного обобщенного делегата.
 * Использование ключевого слова in позволяет присвоить делегату с производным типом 
 * (MessageReceiver<EmailMessage>) делегат с базовым типом (MessageReceiver<Message>)
 * Как и в случае с обобщенными интерфейсами параметр ковариантного типа применяется только к
 * типу значения, которые возвращается делегатом. А параметр контравариантного типа применяется
 * только к параметрам делегата. 
 */
 
/* То есть, если грубо обобщить, ковариантность - это от более производного к более общему типу 
 * (EmailMessage -> Message), а контрвариантность - от более общего к более производному типу
 * (Message -> EmailMessage).
 */

// Принимает объект общего типа
MessageReceiver<Message> messageReceiver = (Message message) => message.Print();
// Принимает объект более конкретного типа
MessageReceiver<EmailMessage> emailMessageReceiver = messageReceiver;   // Контрвариативность
messageReceiver(new Message("Hello world"));        //  Message: Hello world!
messageReceiver(new EmailMessage("Hello world"));   //  Email: Hello world!

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Совмещение ковариативности и контрвариативности.
 * Делегат может одновременно использовать оба оператора: in и out.
 * Здесь делегат MessageConverter представляет действие которое конвертирует объект типа М в тип Е.
 * Переменная converter которая представляет тип MessageConverter<SmsMessage, Message> то есть конвертер
 * из типа SmsMessage в любой тип Message, преобразует смс в любой другой тип сообщения.
 * Этой переменной можно передать действие - toEmailConverter, которое из сообщений любого типа 
 * создает объект Email-сообщения. Здесь применяется контравариантность: для параметра вместо 
 * производного типа SmsMessage применяется базовый тип Message. И также есть ковариантность: 
 * вместо возвращаемого типа Message используется производный тип EmailMessage.
 */
MessageConverter<Message, EmailMessage> toEmailConverter = (Message message) => new EmailMessage(message.Text);
MessageConverter<SmsMessage, Message> converter = toEmailConverter;
Message message3 = converter(new SmsMessage("Hello work"));
message3.Print();       //  Email: Hello work
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
internal class Message(string text)
{
    public string Text { get; } = text;
    public virtual void Print() => Console.WriteLine($"Message: {Text}");
}
class EmailMessage(string text) : Message(text)
{
    public override void Print()
    {
        Console.WriteLine($"Email: {Text}");
    }
}
class SmsMessage(string text): Message(text)
{
    public override void Print()
    {
        Console.WriteLine($"Sms: {Text}");
    }
}
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
/*
 * Ковариативность позволяет передать делегату метод, возвращаемый тип которого является производным.
 * Т.е если возвращаемый тип делегата Message, то метод может иметь в качестве возвращаемого типа класс
 * EmailMessage.
 */
/*
 * Делегат MessageBuilder возвращает объект Message. Благодаря ковариативности данный делегет может
 * указывать на метод, который возвращает объект производного типа, например writeEmailMessage.
 */
delegate T MessageBuilder2<out T>(string text);
delegate Message MessageBuilder(string text);
delegate void EmailReceiver(EmailMessage message);
delegate void MessageReceiver<in T>(T message);
delegate E MessageConverter<in M, out E>(M message);