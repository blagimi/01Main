namespace ОпределениеОператоров;

public class Bread
{
    /// <summary>
    /// Масса
    /// </summary>
    public int Weight {get;set;}

    public static Sandwich operator + (Bread bread1, Butter butter1)
    {
        return new Sandwich {Weight = bread1.Weight + butter1.Weight};
    }
}
