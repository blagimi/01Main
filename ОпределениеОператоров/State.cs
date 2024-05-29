namespace ОпределениеОператоров;

public class State 
{
    /// <summary>
    /// Население
    /// </summary>
    public decimal Population {get;set;}
    /// <summary>
    /// Территория
    /// </summary>
    public decimal Area {get;set;}
    public State () {}
    public State (decimal population, decimal area) 
    {
        Population = population;
        Area = area;
    }

    public static State operator + (State state, State state2)
    {
        return new State
        {
            Population = state.Population + state2.Population, 
            Area = state.Area + state2.Area
        };
    }
    public static bool operator < (State state, State state2)
    {
        return state.Area <  state2.Area;
    }
    public static bool operator > (State state, State state2)
    {
        return state.Area > state2.Area;
    }
}
