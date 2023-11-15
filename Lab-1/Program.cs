// See https://aka.ms/new-console-template for more information

using Lab_1.Models;

Console.WriteLine("Hello, World!");
var dealer = new Croupier();
foreach (var card in dealer.CardDeck.Cards)
{
    Console.WriteLine(card);
}
