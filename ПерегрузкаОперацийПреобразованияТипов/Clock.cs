namespace ПерегрузкаОперацийПреобразованияТипов;

public class Clock
{
    public int Hours {get;set;}
    public static explicit operator int(Clock clock1)
    {
        return clock1.Hours;
    }
    public static implicit operator Clock(int x)
    {
        return new Clock{Hours = x % 24};
    }
}
