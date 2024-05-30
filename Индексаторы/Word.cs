
namespace Индексаторы;

public class Word
{
    public string Source {get;}
    public string Target {get;set;}
    public Word (string source, string target)
    {
        Source = source;
        Target = target;
    }
}
