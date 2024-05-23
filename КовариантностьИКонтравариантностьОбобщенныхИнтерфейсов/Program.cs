using КовариантностьИКонтравариантностьОбобщенныхИнтерфейсов;
/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Ковариативность и контрвариатность обобщенных интерфейсов.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Понятия ковариативности и контрвариативности связаны с возможностью использовать
 * в приложении вместо некоторого типа другой тип, который находится ниже или выше в
 * иерархии наследования.
 * Имеется три возможных варианта поведения:
 * - Ковариативность позволяет использовать более конкретный тип, чем заданный изначально
 * - Контрвариативность позволяет использовать более универсальный тип, чем заданный
 * изначально
 * Инвариативность позволяет использовать только заданный тип.
 * Можно создавать ковариативные и контрвариатные обобщенные интерфейсы. Эта
 * функциональность повышает гибкость при использовании обобщенных интерфейсов в 
 * программе. По умолчанию все обобщенные интерфейсы являются инвариантными.
 * Здесь определен класс сообщения Message, который получает через конструктор текст
 * и сохраняет его в свойство Text. А класс EmailMessage представляет условное email
 * сообщение и просто вызывает конструктор базового класса, передавая ему текст
 * сообщения.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Ковариативные интерфейсы.
 * Обобщенные интерфейсы могут быть ковариантными, если к универсальному параметру
 * применяется ключевое слово out. Такой параметр должен представлять тип объекта,
 * который возвращается из метода.
 */

/*
 * Здесь обобщенный интерфейс IMessenger представляет интерфейс мессенджера и 
 * определяет метод WriteMessage() для создания сообщения. При этом на момент определения
 * интерфейса мы не знаем, объект какого типа будет возвращаеться в этом методе. 
 * Ключевое слово out в определении интерфейса указывает, что данный интерфейс будет
 * ковариативным. Класс EmailMessenger который представляет условную программу для
 * оправки email-сообщений, реализует это интерфейс и возвращает из метода WriteMessage()
 * объект EmailMessage.
 *                                  | Message,EmailMessage,EmailMessenger,IMessenger
 */

IMessenger<Message> outlook = new EmailMessenger();
Message message = outlook.WriteMessage("Hello world");
Console.WriteLine(message.Text);        //  Email: Hello World

IMessenger<EmailMessage> emailClient = new EmailMessenger();
IMessenger<Message> messenger = emailClient;
Message emailMessage = messenger.WriteMessage("Hi");
Console.WriteLine(emailMessage.Text);   //  Email: Hi

/*
 * Т.е можно присвоить более общему типу IMessenger<Message> объект более конкретного
 * типа EmailMessenger или IMessenger<EmailMessage>. Если бы не использовалось out
 * interface IMessenger<T>
 * тогда была бы ошибка 
 * IMessenger<Message> outlook = new EmailMessenger();  // ! Ошибка
 * IMessenger<EmailMessage> emailClient = new EmailMessenger();
 * IMessenger<Message> messenger = emailClient;  // ! Ошибка
 * Поскольку в этом случае невозможно было бы привести объект IMessenger<EmailMessage>
 * к типу IMessenger<Message>
 * При создании ковариантного интерфейса надо учитывать, что универсальный параметр может 
 * использоваться только в качестве типа значения, возвращаемого методами интерфейса. Но
 * не может использоваться в качестве типа аргументов метода или ограничения методов 
 * интерфейса.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/* 
 * Контравариантные интерфейсы.
 * Для создания контрвариативного интерфейса надо использовать ключевое слово in. 
 * Например возьмем классы Message и EmailMessage и определим следующие типы.
 */

/*
 * Здесь интерфейс IMessenger2 представляет интерфейс мессенджера и определяет метод 
 * SendMessage() для отправки условного сообщения. Ключевое слово in в определении
 * интерфейса указывает, что этот интерфейс контрвариативный.
 * Класс SimpleMessanger представляет уловную программу отправки сообщений и реализует
 * этот интерфейс. Причем в качестве типа используемого этот класс использует тип Message.
 * То есть SimpleMessanger фактически представляет тип IMessenger<Message>
 *                                  | Message,EmailMessage,SimpleMessenger,IMessenger2
 */
                                    
IMessenger2<EmailMessage> outlook2 = new SimpleMessenger();
                                        //  Отправляется сообщение: Hi
outlook2.SendMessage(new EmailMessage("Hi"));   
                                        
IMessenger2<Message> telegram = new SimpleMessenger();
IMessenger2<EmailMessage> emailClient2 = telegram;
                                        //  Отправляется сообщение: Hello
emailClient2.SendMessage(new EmailMessage("Hello"));    

/*
 * Так как интерфейс IMessenger использует универсальный параметр с ключевым словом in,
 * то он является контрвариативным поэтому в коде мы можем переменной типа IMessenger
 * <EmailMessage> передать объект IMessenger<Message> или SimpleMessenger.
 * Если бы ключевое слово in не использовалось бы, то этого бы не получилось. Т.е
 * объект интерфейса с более универсальным типом приводится к объекту интерфейса с
 * более конкретным типом. При создании контрвариативного интерфейса надо учитывать,
 * что универсальный параметр конрвариативного типа может применяться только к аргумента
 * метода, но не может применяться к возвращаемому результату метода.
 */

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/*
 * Совмещение ковариантности и контравариантности.
 * Можно так же совмещать ковариативность и контрвариативность в одном интерфейсе.
 * Фактически здесь объединены два предыдущих примера. Благодаря ковариативности/
 * контрвариативности объект класса SimpleMessenger3 может представлять типы
 * IMessenger<EmailMessage,Message>, IMessenger<Message,EmailMessage>,
 * IMessenger<Message,Message> и IMessenger<EmailMessage, EmailMessage>
 *                                  | Message,EmailMessage,SimpleMessenger2,IMessenger3
 */
                                        
IMessenger3<EmailMessage, Message> messenger3 = new SimpleMessenger2();
Message message3 = messenger3.WriteMessage("Hello World");
                                        //  Email: Hello World
Console.WriteLine(message3.Text);
                                        //  Отправляется сообщение: Test
messenger3.SendMessage(new EmailMessage("Test"));   

IMessenger3<EmailMessage, EmailMessage> outlook3 = new SimpleMessenger2();
EmailMessage emailMessage3 = outlook3.WriteMessage("Message from Outlook");
                                        //  Отправляется сообщение: Email: Message from Outlook
outlook3.SendMessage(emailMessage3);   

IMessenger3<Message, Message> telegram3 = new SimpleMessenger2();
Message simpleMessage = telegram3.WriteMessage("Message from Telegram");
                                        //  Отправляется сообщение: Email: Message from Telegram
telegram3.SendMessage(simpleMessage);  
