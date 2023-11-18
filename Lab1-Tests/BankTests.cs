using Lab_1.Models;

namespace Lab1_Tests;

public class BankTests
{
    [Fact]
    public void AddMoney_WithPositiveAmount_ShouldIncreaseBalance()
    {
        // Arrange
        var bank = new Bank();
        decimal initialBalance = bank.Balance;
        decimal amount = 100;

        // Act
        bank.AddMoney(amount);

        // Assert
        Assert.Equal(initialBalance + amount, bank.Balance);
    }

    [Fact]
    public void AddMoney_WithZeroAmount_ShouldThrowArgumentException()
    {
        // Arrange
        var bank = new Bank();
        decimal amount = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bank.AddMoney(amount));
    }

    [Fact]
    public void AddMoney_WithNegativeAmount_ShouldThrowArgumentException()
    {
        // Arrange
        var bank = new Bank();
        decimal amount = -100;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bank.AddMoney(amount));
    }

    [Fact]
    public void TakeMoney_WithAmountLessThanBalance_ShouldDecreaseBalance()
    {
        // Arrange
        var bank = new Bank();
        decimal initialBalance = 500;
        decimal amount = 200;
        bank.AddMoney(initialBalance);

        // Act
        bank.TakeMoney(amount);

        // Assert
        Assert.Equal(initialBalance - amount, bank.Balance);
    }

    [Fact]
    public void TakeMoney_WithAmountGreaterThanBalance_ShouldThrowArgumentException()
    {
        // Arrange
        var bank = new Bank();
        decimal initialBalance = 500;
        decimal amount = 800;
        bank.AddMoney(initialBalance);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => bank.TakeMoney(amount));
    }
}