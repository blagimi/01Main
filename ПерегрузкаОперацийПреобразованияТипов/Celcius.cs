namespace ПерегрузкаОперацийПреобразованияТипов;

public class Celcius
{
    public double Gradus {get;set;}

    public static implicit operator Fahrenheit(Celcius celcius)
    {
        return new Fahrenheit { Gradus = 9.0 / 5 * celcius.Gradus + 32 };
    }
    public static implicit operator Celcius (Fahrenheit fahrenheit)
    {
        return new Celcius { Gradus = 5.0 / 9 * (fahrenheit.Gradus - 32) };
    }
    
   
}
