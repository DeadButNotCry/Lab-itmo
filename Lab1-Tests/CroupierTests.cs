using Lab_1.Models;

namespace Lab1_Tests;

public class CroupierTests
{
    [Fact]
    public void Croupier_ShufflesDeckWhenCreated()
    {
        // Arrange
        var croupier = new Croupier();
        var defaultDeck = new CardDeck();

        // Assert
        Assert.NotEqual(defaultDeck.Cards, croupier.CardDeck.Cards);
    }

    [Fact]
    public void Croupier_TakeNewCardDeck_CreatesNewDeckAndShuffles()
    {
        // Arrange
        var croupier = new Croupier();
        var originalDeck = croupier.CardDeck;

        // Act
        originalDeck.GetCard();
        croupier.TakeNewCardDeck();
        var newDeck = croupier.CardDeck.Cards;

        // Assert
        Assert.NotEqual(originalDeck.Cards, newDeck);
    }

    [Fact]
    public void Croupier_TakeNewCardDeck_SetsShuffledDeck()
    {
        // Arrange
        var croupier = new Croupier();
        var defaultCardDeck = new CardDeck();
        // Act
        croupier.TakeNewCardDeck();
        var shuffledDeck = croupier.CardDeck.Cards;

        // Assert
        Assert.NotEqual(shuffledDeck, defaultCardDeck.Cards);
    }
}