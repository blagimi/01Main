using System;

namespace ИнтерфейсыIEnumerableИIEnumerator;

public class WeekEnumeratorS : IEnumerator<string>
{
    string[] days;
    int position = -1;
    public WeekEnumeratorS(string[] days) => this.days = days;
    public string Current
    {
        get
        {
            if (position == -1 || position >= days.Length)
                throw new ArgumentException();
            return days[position];
        }
    }

    object System.Collections.IEnumerator.Current => Current;
    public bool MoveNext()
    {
        if (position < days.Length - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }
    public void Reset() => position = -1;
    public void Dispose() { }
}
class WeekS
{
    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
    public IEnumerator<string> GetEnumerator() => new WeekEnumeratorS(days);
}