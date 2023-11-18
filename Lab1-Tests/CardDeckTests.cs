using Lab_1.Exceptions;
using Lab_1.Models;

namespace Lab1_Tests;

public class CardDeckTests
{
    [Fact]
    public void CardDeck_CountOfCardsInDeck_ReturnsCorrectCount()
    {
        // Arrange
        var cardDeck = new CardDeck();

        // Act
        var count = cardDeck.Cards.Count;

        // Assert
        Assert.Equal(52, count);
    }

    [Fact]
    public void CardDeck_GetCard_ReturnsTopCard()
    {
        // Arrange
        var cardDeck = new CardDeck();

        // Act
        var card = cardDeck.GetCard();

        // Assert
        Assert.NotNull(card);
    }

    [Fact]
    public void CardDeck_GetCards_ReturnsCorrectNumberOfCards()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var count = 5;

        // Act
        var cards = cardDeck.GetCards(count);

        // Assert
        Assert.Equal(count, cards.Count);
    }

    [Fact]
    public void CardDeck_GetCards_ThrowsArgumentExceptionForZeroCount()
    {
        // Arrange
        var cardDeck = new CardDeck();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => cardDeck.GetCards(0));
    }

    [Fact]
    public void CardDeck_GetCards_ThrowsOutOfCardsExceptionWhenNotEnoughCardsInDeck()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var count = 53;

        // Act & Assert
        Assert.Throws<OutOfCardsExceptions>(() => cardDeck.GetCards(count));
    }

    [Fact]
    public void CardDeck_GetCards_RemovesCardsFromDeck()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var count = 5;

        // Act
        var cards = cardDeck.GetCards(count);
        var remainingCount = cardDeck.Cards.Count;

        // Assert
        Assert.Equal(52 - count, remainingCount);
    }

    [Fact]
    public void CardDeck_ShuffleCards_ShufflesCard()
    {
        // Arrange
        var cardDeck = new CardDeck();
        var shuffledCardDeck = new CardDeck();

        // Act
        shuffledCardDeck.ShuffleCards();

        // Assert
        Assert.NotEqual(cardDeck.Cards, shuffledCardDeck.Cards);
    }
}