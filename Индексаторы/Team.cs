namespace Индексаторы;

public class Team
{
    Player[] players = new Player[11];
    public Team () {}
    public Team(Player[] player) => players = player;
    public Player this[int index]
    {
        get 
        {
            if(index >= 0 && index <= players.Length)
                return players[index];
            else
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
        } 
        set 
        {
            if (index >= 0 && index <= players.Length)
                players[index] = value;     
        } 
    }
}
