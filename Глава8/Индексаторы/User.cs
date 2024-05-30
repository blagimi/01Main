using System.ComponentModel.DataAnnotations;

namespace Индексаторы;

public class User
{
    public string name = "";
    public string email = "";
    public string phone = "";
    public string this [string propname]
    {
        get 
        {
            switch (propname)
            {
                case "name": return name;
                case "email": return email;
                case "phone": return phone;
                default: throw new Exception ("Unknown property name");
            }     
        }
        set
        {
            switch (propname)
            {
                case "name": name = value; break;
                case "email": email = value; break;
                case "phone": phone = value; break;
            }
        }
    }
}
