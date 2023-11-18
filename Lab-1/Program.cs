// See https://aka.ms/new-console-template for more information

using Lab_1.Models;

var deck = new CardDeck();
var dealer = new Croupier(deck);

foreach (var card in dealer.CardDeck.Cards)
{
    Console.WriteLine(card);
}