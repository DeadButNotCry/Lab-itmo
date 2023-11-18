namespace Lab1_Tests;

public class CroupierTests
{
    [Fact]
    public void Croupier_ShufflesDeckWhenCreated()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var croupier = new Croupier(cardDeck);
        var defaultDeck = new CardDeck();

        // Assert
        Assert.NotEqual(defaultDeck.Cards, croupier.CardDeck.Cards);
    }

    [Fact]
    public void Croupier_TakeNewCardDeck_TakesDeckAndShuffles()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var croupier = new Croupier(cardDeck);
        var originalDeck = croupier.CardDeck;

        // Act
        originalDeck.GetCard();
        var deck = new CardDeck();
        croupier.SetNewCardDeck(deck);
        var newDeckShuffledDeck = croupier.CardDeck.Cards;

        // Assert
        Assert.NotEqual(originalDeck.Cards, newDeckShuffledDeck);
    }

    [Fact]
    public void Croupier_TakeNewCardDeck_SetsShuffledDeck()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var croupier = new Croupier(cardDeck);
        var defaultCardDeck = new CardDeck();
        // Act
        var newCardDeck = new CardDeck();
        croupier.SetNewCardDeck(newCardDeck);
        var shuffledDeck = croupier.CardDeck.Cards;

        // Assert
        Assert.NotEqual(shuffledDeck, defaultCardDeck.Cards);
    }
}