namespace Lab_1.Models;

public class BlackJackCasino
{
    private const decimal START_CASINO_BALANCE = 10_000_000;
    private readonly CasinoBankBuilder _casinoBankBuilder;
    private readonly PlayerBankBuilder _playerBankBuilder;
    private readonly Bank _casinoBank;
    private readonly Croupier _croupier;
    private readonly List<Player> _players = new();

    public BlackJackCasino()
    {
        _casinoBankBuilder = new CasinoBankBuilder(START_CASINO_BALANCE);

        // Player start balance is random now;
        _playerBankBuilder = new PlayerBankBuilder();

        _casinoBankBuilder.BuildBalance();
        _casinoBank = _casinoBankBuilder.GetBank();

        _croupier = new Croupier();
    }

    public void AddPlayerBalance(Player player, decimal amount)
    {
        _casinoBank.TakeMoney(amount);
        player.Bank.AddMoney(amount);
    }

    public void TakeMoneyFromPlayer(Player player, decimal amount)
    {
        player.Bank.TakeMoney(amount);
        _casinoBank.AddMoney(amount);
    }


    public bool CheckForBlackJack(Player player)
    {
        var sumOfThePlayerHand = 0;
        foreach (var card in player.Cards)
        {
            if (card.Power == PowerOfCard.Ace)
            {
                sumOfThePlayerHand += 11;
            }
            else if ((int)card.Power < 10)
            {
                sumOfThePlayerHand += (int)card.Power;
            }
            else
            {
                sumOfThePlayerHand += 10;
            }
        }

        var sumWithAceEqualOne = sumOfThePlayerHand - 10;
        return sumOfThePlayerHand == 21 || sumWithAceEqualOne == 21;
    }
}