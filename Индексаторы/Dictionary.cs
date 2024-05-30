namespace Индексаторы;

public class Dictionary
{
    Word[] words;
    public Dictionary()
    {
        words = new Word[]
        {
            new Word("Red", "Красный"),
            new Word("Blue", "Синий"),
            new Word("Green", "Зеленый")
        };
    }
    public string this[string source]
    {
        get 
        {
            Word? word = null;
            if (source is not null)
                foreach (Word w in words)
                {
                    if (w.Source == source) 
                    {
                        word = w;
                        break;
                    }
                }  
            else
                {
                    throw new Exception();
                }

#pragma warning disable CS8603 // Possible null reference return.
            return word?.Target;
#pragma warning restore CS8603 // Possible null reference return.

        }
        set
        {
            foreach (Word w in words)
            {
                if (w.Source == source) 
                {
                    w.Target = value;  
                    break;
                }
            }
        }
    }
}
