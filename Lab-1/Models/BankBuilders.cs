namespace Lab_1.Models;

public interface IBankBuilder
{
    public void BuildBalance();
    public Bank GetBank();

    public void ResetInstance();
}

public class PlayerBankBuilder : IBankBuilder
{
    private const long MIN_INIT_BALANCE = 10000;
    private const long MAX_INIT_BALANCE = 100000;

    private Bank currentInstanceOfBank;

    public PlayerBankBuilder()
    {
        this.currentInstanceOfBank = new Bank();
    }

    public void BuildBalance()
    {
        var rnd = new Random();
        currentInstanceOfBank.AddMoney(rnd.NextInt64(MIN_INIT_BALANCE, MAX_INIT_BALANCE));
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