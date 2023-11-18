namespace Lab_1.Models;

public enum PowerOfCard
{
    Ace,
    King,
    Queen,
    Jack,
    Ten,
    Nine,
    Eight,
    Seven,
    Six,
    Five,
    Four,
    Three,
    Two
}

public enum Suits
{
    Hearts,
    Clubs,
    Spades,
    Diamonds
}

public class Card : IComparable
{
    public PowerOfCard Power { get; }
    public Suits Suit { get; }

    public Card(PowerOfCard power, Suits suit)
    {
        Power = power;
        Suit = suit;
    }

    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException();
        }

        if (obj.GetType() != GetType())
        {
            throw new ArgumentException("Object is not a Card");
        }

        var otherCard = obj as Card;
        // We multiply result of comparing cuz in enum ace has index 1, but it's the most powerful 
        return -1 * Power.CompareTo(otherCard.Power);
    }

    public override string ToString()
    {
        return $"{Power} -  {Suit}";
    }
}