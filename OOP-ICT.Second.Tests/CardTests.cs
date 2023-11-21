using OOP_ICT.Second.Models;
namespace OOP_ICT.Second.Tests;

public class CardTests
{
    [Fact]
    public void Card_CompareTo_ReturnsCorrectComparisonValue()
    {
        // Arrange
        var card1 = new Card(PowerOfCard.Ace, Suits.Spades);
        var card2 = new Card(PowerOfCard.Jack, Suits.Hearts);
        var card3 = new Card(PowerOfCard.Two, Suits.Clubs);
        var card4 = new Card(PowerOfCard.Jack, Suits.Diamonds);
        // Act
        var result1 = card1.CompareTo(card2);
        var result2 = card2.CompareTo(card3);
        var result3 = card3.CompareTo(card1);
        var result4 = card4.CompareTo(card2);
        // Assert
        Assert.True(result1 > 0);
        Assert.True(result2 > 0);
        Assert.True(result3 < 0);
        Assert.True(result4 == 0);
    }

    [Fact]
    public void Card_CompareTo_ThrowsArgumentNullExceptionWhenObjectIsNull()
    {
        // Arrange
        var card = new Card(PowerOfCard.Ace, Suits.Spades);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => card.CompareTo(null));
    }

    [Fact]
    public void Card_CompareTo_ThrowsArgumentExceptionWhenObjectIsNotCard()
    {
        // Arrange
        var card = new Card(PowerOfCard.Ace, Suits.Spades);
        var notCard = "string";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => card.CompareTo(notCard));
    }
}