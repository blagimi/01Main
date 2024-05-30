namespace Индексаторы;

public class Company
{
    Person[] personal;
    public Company (Person[] people) => personal = people;
    // Индексатор
    public Person this[int index]
    {
        get 
        {
            // Если индекс есть в массиве
            if (index >= 0 && index < personal.Length)
                return personal[index];     //  Возвращаем объект Person по индексу
            else
                throw new ArgumentOutOfRangeException ("Запрашиваемого индекса нет в массиве");
        } 
        set 
        {
            // Ели индекс есть в массиве
            if (index >= 0 && index < personal.Length)
                personal[index] = value;    //  Переустановка значения по индексу
            else
                throw new Exception ("Невозможно установить значение для индекса, нет индекса");
        } 
    }
    public Person this[string name]
    {
        get 
        {
            foreach (var person in personal)
            {
                if (person.Name == name) return person;
            }
            throw new Exception ("Unknown name");
        }
    }
}
