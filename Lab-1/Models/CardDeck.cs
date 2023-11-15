using Lab_1.Exceptions;

namespace Lab_1.Models;

public class CardDeck
{
    public List<Card> Cards { get; set; } = new();

    public CardDeck()
    {
        foreach (var power in Enum.GetValues<PowerOfCard>())
        {
            foreach (var suit in Enum.GetValues<Suits>())
            {
                Cards.Add(new Card(power, suit));
            }
        }
    }

    public Card GetCard()
    {
        
        if (CountOfCardsInDeck() < 1)
        {
            throw new OutOfCardsExceptions("This deck is empty");
        }

        var card = Cards[0];
        Cards.Remove(card);
        return card;
    }

    public List<Card> GetCards(int count)
    {
        if (count < 1)
        {
            throw new ArgumentException($"{nameof(count)} must be positive and non zero");
        }

        if (CountOfCardsInDeck() < count)
        {
            throw new OutOfCardsExceptions("There are not enough cards in the deck");
        }

        var result = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Cards[i]);
        }

        Cards.RemoveRange(0, count);
        return result;
    }


    public int CountOfCardsInDeck() => Cards.Count;
}