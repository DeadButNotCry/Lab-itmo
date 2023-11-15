using Lab_1.Exceptions;

namespace Lab_1.Models;

public class Croupier : ICroupier
{
    public CardDeck CardDeck { get; private set; }

    public Croupier()
    {
        CardDeck = new CardDeck();
        ShuffleCards();
    }


    private void ShuffleCards()
    {
        var half = CardDeck.CountOfCardsInDeck() / 2;
        var shuffledDeck = new List<Card>(CardDeck.Cards);
        for (int i = 0; i < half; i++)
        {
            shuffledDeck[i * 2] = CardDeck.Cards[i + half];
            shuffledDeck[i * 2 + 1] = CardDeck.Cards[i];
        }

        CardDeck.Cards = shuffledDeck;
    }


    public void TakeNewCardDeck()
    {
        CardDeck = new CardDeck();
        ShuffleCards();
    }
}