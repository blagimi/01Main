using System;

namespace ИтераторыИОператорYield;

public class Company
{
    Person[] personnel;
    public Company(Person[] personnel) => this.personnel = personnel;
    public int Length => personnel.Length;
    public IEnumerator<Person> GetEnumerator()
    {
        for (int i = 0; i < personnel.Length; i++)
        {
            yield return personnel[i];
        }
    }
}
