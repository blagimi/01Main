using System;

namespace ИтераторыИОператорYield;

public static class Int32Extension
{
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        int k = (number > 0)? number: 0;
        for (int i = number - k; i <= k; i++) yield return i;
    }
}
