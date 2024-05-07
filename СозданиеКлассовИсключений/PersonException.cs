using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СозданиеКлассовИсключений
{
    /*
     * Однако необязательно наследовать свой класс исключений именно от типа Exception, 
     * можно взять какой-нибудь другой производный тип. Например, в данном случае мы
     * можем взять тип ArgumentException, который представляет исключение, генерируемое в
     * результате передачи аргументу метода некорректного значения
     */
    //internal class PersonException : Exception
    internal class PersonException : ArgumentException
    {
        public int Value { get; }
        /*
         * По сути класс кроме пустого конструктора ничего не имеет, и то в конструкторе 
         * мы просто обращаемся к конструктору базового класса Exception, 
         * передавая в него строку message. Но теперь мы можем изменить класс Person,
         * чтобы он выбрасывал исключение именно этого типа и соответственно в основной
         * программе обрабатывать это исключение:
         */
        public PersonException(string message,int value) : base(message) { Value = value; }
    }
}
