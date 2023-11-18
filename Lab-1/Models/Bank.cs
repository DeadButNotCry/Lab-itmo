namespace Lab_1.Models;

public class Bank
{
    public decimal Balance { get; private set; }


    public void AddMoney(decimal amount)
    {
        if (amount < 1)
        {
            throw new ArgumentException($"{nameof(amount)} must be positive and non zero");
        }

        Balance += amount;
    }

    public void TakeMoney(decimal amount)
    {
        if (amount > Balance)
        {
            throw new ArgumentException("Not enough money for transfer");
        }

        Balance -= amount;
    }
}
