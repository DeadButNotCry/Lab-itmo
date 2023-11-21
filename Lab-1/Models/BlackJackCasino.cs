namespace Lab_1.Models;

public class BlackJackCasino
{
    private const decimal START_CASINO_BALANCE = 10_000_000;
    private const long MIN_PLAYER_BALANCE = 10_000;
    private const long MAX_PLAYER_BALANCE = 1_000_000;
    private readonly CasinoBankBuilder _casinoBankBuilder;
    private readonly PlayerBankBuilder _playerBankBuilder;
    private readonly Bank _casinoBank;
    private readonly Croupier _croupier;
    public List<Player> Players { get; } = new();

    public BlackJackCasino()
    {
        _casinoBankBuilder = new CasinoBankBuilder(START_CASINO_BALANCE);

        // Player start balance is random now;
        _playerBankBuilder = new PlayerBankBuilder(MIN_PLAYER_BALANCE, MAX_PLAYER_BALANCE);

        _casinoBankBuilder.BuildBalance();
        _casinoBank = _casinoBankBuilder.GetBank();
        var deck = new CardDeck();
        _croupier = new Croupier(deck);
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
        if (player.Cards.Count != 2)
        {
            return false;
        }

        var powerSum = 0;
        foreach (var card in player.Cards)
        {
            switch (card.Power)
            {
                case PowerOfCard.Ace:
                    powerSum += 11;
                    break;
                case PowerOfCard.King:
                case PowerOfCard.Queen:
                case PowerOfCard.Jack:
                case PowerOfCard.Ten:
                    powerSum += 10;
                    break;
                default:
                    // We add the 1,cuz enum starts with 1.
                    powerSum += (int)card.Power + 1;
                    break;
            }
        }

        if (powerSum != 21)
        {
            return false;
        }

        var playerBet = player.Bet;

        AddPlayerBalance(player, Decimal.Multiply(playerBet, 1.5m));
        player.State = PlayerState.BlackJack;

        return true;
    }

    // public void 

    public void CreateCasinoPlayer()
    {
        _playerBankBuilder.BuildBalance();
        var bank = _playerBankBuilder.GetBank();
        _playerBankBuilder.ResetInstance();
        var player = new Player(bank);
        Players.Add(player);
    }
}