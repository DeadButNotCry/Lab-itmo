namespace OOP_ICT.Second.Models;

public class Croupier : ICroupier
{
    public CardDeck CardDeck { get; private set; }

    public Croupier(CardDeck cardDeck)
    {
        cardDeck.ShuffleCards();
        CardDeck = cardDeck;
    }


    public void SetNewCardDeck(CardDeck cardDeck)
    {
        CardDeck = cardDeck;
        CardDeck.ShuffleCards();
    }
}