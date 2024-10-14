using System;

namespace ИнтерфейсыIEnumerableИIEnumerator;

public class Week: IEnumerable
{
    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };
    public IEnumerator GetEnumerator() => (IEnumerator)days.GetEnumerator();
}
