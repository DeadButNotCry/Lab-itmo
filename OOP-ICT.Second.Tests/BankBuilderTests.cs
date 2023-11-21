using OOP_ICT.Second.Models;

namespace OOP_ICT.Second.Tests;

public class BankBuilderTests
{
    
    [Fact]
    public void BuildBalance_PlayerBankBuilder_ShouldHaveBalanceInRange()
    {
        // Arrange
        var min_balance = 100;
        var max_balance = 1000;
        var builder = new PlayerBankBuilder(min_balance, max_balance);
        builder.BuildBalance();

        // Act
        var balance = builder.GetBank().Balance;

        // Assert
        Assert.InRange(balance, min_balance, max_balance);
    }

    [Fact]
    public void ResetInstance_PlayerBankBuilder_ShouldResetBankInstance()
    {
        // Arrange
        var min_balance = 100;
        var max_balance = 1000;
        var builder = new PlayerBankBuilder(min_balance, max_balance);
        builder.BuildBalance();

        // Act
        builder.ResetInstance();
        var bank = builder.GetBank();

        // Assert
        Assert.Equal(0, bank.Balance);
    }

    // CasinoBankBuilder tests
    
    [Fact]
    public void BuildBalance_CasinoBankBuilder_ShouldHaveCorrectBalance()
    {
        // Arrange
        decimal startCasinoBalance = 10000;
        var builder = new CasinoBankBuilder(startCasinoBalance);
        builder.BuildBalance();

        // Act
        var balance = builder.GetBank().Balance;

        // Assert
        Assert.Equal(startCasinoBalance, balance);
    }

    [Fact]
    public void ResetInstance_CasinoBankBuilder_ShouldResetBankInstance()
    {
        // Arrange
        decimal startCasinoBalance = 10000;
        var builder = new CasinoBankBuilder(startCasinoBalance);
        builder.BuildBalance();

        // Act
        builder.ResetInstance();
        var bank = builder.GetBank();

        // Assert
        Assert.Equal(0, bank.Balance);
    }
}

