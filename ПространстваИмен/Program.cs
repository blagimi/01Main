/* Пространства имен позволяют организовать код программы в логические блоки, 
 * поволяют объединить и отделить от остального кода некоторую функциональность, 
 * которая связана некоторой общей идеей или которая выполняет определенную задачу.
 */

using Base.PersonTypes; // подключение пространства имен Base.PersonTypes для класса Person

Base.OrganisationTypes.Company microsoft = new("Microsoft");
Person tom = new("Tom", microsoft);
tom.Print();     // Имя: Tom   Название компании: Microsoft

namespace Base
{
    namespace PersonTypes
    {
        class Person
        {
            readonly string name;
            readonly OrganisationTypes.Company company;
            public Person(string name, OrganisationTypes.Company company)
            {
                this.name = name;
                this.company = company;
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {name} ");
                company.Print();
            }
        }
    }
    namespace OrganisationTypes
    {
        class Company
        {
            readonly string title;
            public Company(string title) => this.title = title;
            public void Print() => Console.WriteLine($"Название компании: {title}");
        }
    }
}