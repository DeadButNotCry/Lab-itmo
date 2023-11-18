using Lab_1.Models;

namespace Lab1_Tests;

public class BlackJackCasinoTests
{
    [Fact]
    public void CheckForBlackJack_ShouldReturnTrue_WhenPlayerHasBlackJack()
    {
        // Arrange
        var casino = new BlackJackCasino();
        casino.CreateCasinoPlayer();
        casino.Players[0].Cards.Add(new Card(PowerOfCard.Ace, Suits.Hearts));
        casino.Players[0].Cards.Add(new Card(PowerOfCard.Ten, Suits.Diamonds));

        // Act
        var result = casino.CheckForBlackJack(casino.Players[0]);
        //
        // // Assert
        Assert.True(result);
    }

    [Fact]
    public void CheckForBlackJack_ShouldReturnFalse_WhenPlayerDoesNotHaveBlackJack()
    {
        // Arrange
        var casino = new BlackJackCasino();
        casino.CreateCasinoPlayer();
        casino.Players[0].Cards.Add(new Card(PowerOfCard.Ace, Suits.Hearts));
        casino.Players[0].Cards.Add(new Card(PowerOfCard.Nine, Suits.Diamonds));
        var init_balance = casino.Players[0].Bank.Balance;
        // Act
        var result = casino.CheckForBlackJack(casino.Players[0]);
        var result2 = casino.Players[0].Bank.Balance > init_balance;
        // Assert
        Assert.False(result);
    }
}