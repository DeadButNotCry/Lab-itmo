namespace OOP_ICT.Second.Models;

public interface IBankBuilder
{
    public void BuildBalance();
    public Bank GetBank();

    public void ResetInstance();
}

public class PlayerBankBuilder : IBankBuilder
{
    private long minInitBalance;
    private long maxInitBalance;

    private Bank currentInstanceOfBank;


    public PlayerBankBuilder(long minInitBalance, long maxInitBalance)
    {
        currentInstanceOfBank = new Bank();
        this.minInitBalance = minInitBalance;
        this.maxInitBalance = maxInitBalance;
    }

    public void BuildBalance()
    {
        var rnd = new Random();
        currentInstanceOfBank.AddMoney(rnd.NextInt64(minInitBalance, maxInitBalance));
    }

    public Bank GetBank()
    {
        return currentInstanceOfBank;
    }

    public void ResetInstance()
    {
        currentInstanceOfBank = new Bank();
    }
}

public class CasinoBankBuilder
{
    private readonly decimal _startCasinoBalance;

    private Bank currentInstanceOfBank;

    public CasinoBankBuilder(decimal startCasinoBalance)
    {
        _startCasinoBalance = startCasinoBalance;
        this.currentInstanceOfBank = new Bank();
    }

    public void BuildBalance()
    {
        var rnd = new Random();
        currentInstanceOfBank.AddMoney(_startCasinoBalance);
    }

    public Bank GetBank()
    {
        return currentInstanceOfBank;
    }

    public void ResetInstance()
    {
        currentInstanceOfBank = new Bank();
    }
}