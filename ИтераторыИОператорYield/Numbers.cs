using System;

namespace ИтераторыИОператорYield;

public class Numbers
{
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return i * i;
        }
    }
}
