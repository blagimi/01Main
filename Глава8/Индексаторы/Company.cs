namespace Индексаторы;

public class Company
{
    Person[] personal;
    public Company (Person[] people) => personal = people;
    // Индексатор
    public Person this[int index]
    {
        get => personal[index];
        set => personal[index] = value;
    }
}
