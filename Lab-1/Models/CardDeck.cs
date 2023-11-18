using Lab_1.Exceptions;

namespace Lab_1.Models;

public class CardDeck
{
    public List<Card> Cards { get; private set; }

    public CardDeck()
    {
        Cards = Enum.GetValues<PowerOfCard>()
            .SelectMany(power => Enum.GetValues<Suits>()
                .Select(suit => new Card(power, suit))).ToList();
    }

    public Card GetCard()
    {
        if (Cards.Count < 1)
        {
            throw new OutOfCardsExceptions("This deck is empty");
        }

        var card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }

    public List<Card> GetCards(int count)
    {
        if (count < 1)
        {
            throw new ArgumentException($"{nameof(count)} must be positive and non zero");
        }

        if (Cards.Count < count)
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

    public void ShuffleCards()
    {
        var half = Cards.Count / 2;
        var shuffledDeck = new List<Card>(Cards);
        for (int i = 0; i < half; i++)
        {
            shuffledDeck[i * 2] = Cards[i + half];
            shuffledDeck[i * 2 + 1] = Cards[i];
        }

        Cards = shuffledDeck;
    }
}