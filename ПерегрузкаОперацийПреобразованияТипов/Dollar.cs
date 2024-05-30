namespace ПерегрузкаОперацийПреобразованияТипов;

public class Dollar
{
    public decimal Sum {get;set;}
    public static explicit operator Dollar (Euro euro)
    {
        return new Dollar { Sum = (euro.Sum * 1.14m) };
    }
    public static implicit operator Euro (Dollar dollar)
    {
        return new Euro { Sum = dollar.Sum / 1.14m };
    }
}
