namespace OOP_ICT.Second.Models;

public enum PlayerState
{
    InGame,
    BlackJack,
    Win,
    Lose,
    WaitGameEnding
}

public class Player
{
    public Player(Bank bank)
    {
        Bank = bank;
    }

    public List<Card> Cards { get; } = new();
    public Bank Bank { get; }
    public PlayerState State { get; set; }
    public decimal Bet { get; set; }
}