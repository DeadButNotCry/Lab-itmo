namespace Lab_1.Models;

public class Player
{
    public Player(Bank bank)
    {
        Bank = bank;
    }

    public List<Card> Cards { get; } = new();
    public Bank Bank { get;}
}