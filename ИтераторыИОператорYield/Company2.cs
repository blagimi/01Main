using System;

namespace ИтераторыИОператорYield;

public class Company2
{
    Person[] personnel;
    public Company2(Person[] personnel) => this.personnel = personnel;
    public int Length => personnel.Length;
    public IEnumerable<Person> GetPersonnel(int max)
    {
        for (int i = 0; i < max; i++)
        {
            if (i == personnel.Length)
            {
                yield break;
            }
            else
            {
                yield return personnel[i];
            }
        }
    }
}
