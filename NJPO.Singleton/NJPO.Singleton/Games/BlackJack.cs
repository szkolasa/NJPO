using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Singleton.Abstract;
using NJPO.Singleton.Domain;

namespace NJPO.Singleton.Games
{
    public class BlackJack : IGame
    {
        public string Name { get { return "BlackJack"; } }

        public void Play(Casino casino)
        {
            var deck = CreateDeck().Result;

            // To show card colors in console
            Console.OutputEncoding = Encoding.UTF8;

            var bets = new[] { 1, 5, 10, 25, 50, 100 };
            string betString, playerOptionString;
            int bet, deckPosition, playerOption;

            List<Card> playerCards, casinoCards;
            bool playerContinue;

            do
            {
                Console.Clear();
                Console.WriteLine("********** Blackjack **********\n");
                Console.WriteLine("Stan konta: {0:c}\n", casino.Money);

                for (int i = 0; i < bets.Length; i++)
                {
                    Console.WriteLine("{0}) {1:c}", i + 1, bets[i]);
                }
                Console.WriteLine("9) Powrót\n");

                Console.Write("Wybierz opcję: ");

                betString = Console.ReadLine();

                if (int.TryParse(betString, out bet))
                {
                    if (bet != 9)
                    {
                        try
                        {
                            casino.TakeMoney(bets[bet - 1]);
                            deck.Shuffle();
                            deckPosition = 0;
                            playerCards = new List<Card>();
                            casinoCards = new List<Card>();

                            playerCards.Add(deck[deckPosition++]);
                            casinoCards.Add(deck[deckPosition++]);
                            playerCards.Add(deck[deckPosition++]);

                            if (playerCards.Sum(x => x.Value) == 21)
                            {
                                Console.WriteLine("Blackjack!");
                                Console.Write("Twoje karty: ");
                                PrintCards(playerCards);

                                casino.AddMoney(3 * bets[bet - 1]);
                                break;
                            }
                            else
                            {
                                casinoCards.Add(deck[deckPosition++]);

                                if (casinoCards.Sum(x => x.Value) > 10)
                                {
                                    var higherCard = casinoCards.OrderBy(x => x.Value).First();
                                    Console.WriteLine($"Karta krupiera: {higherCard.Color}{higherCard.Symbol}");
                                }
                                else
                                {
                                    var lowerCard = casinoCards.OrderByDescending(x => x.Value).First();
                                    Console.WriteLine($"Karta krupiera: {lowerCard.Color}{lowerCard.Symbol}\n");
                                }

                                Console.Write("Twoje karty: ");
                                PrintCards(playerCards);
                                Console.WriteLine($"\nWartość: {playerCards.Sum(x => x.Value)}");

                                playerContinue = true;

                                do
                                {
                                    Console.WriteLine("\nWybierz opcję:\n1) Dobierz\n2) Pas");
                                    Console.Write("Twoja decyzja: ");
                                    playerOptionString = Console.ReadLine();

                                    if (int.TryParse(playerOptionString, out playerOption))
                                    {
                                        if (playerOption == 1)
                                        {
                                            playerCards.Add(deck[deckPosition++]);
                                            Console.Write("Twoje karty: ");
                                            PrintCards(playerCards);
                                            Console.WriteLine($"\nWartość: {playerCards.Sum(x => x.Value)}");

                                            if (playerCards.Sum(x => x.Value) > 21)
                                            {
                                                Console.WriteLine("Przegrałeś! Za dużo!");
                                                playerContinue = false;
                                            }
                                        }
                                        else if (playerOption == 2)
                                        {
                                            Console.Write("Twoje karty: ");
                                            PrintCards(playerCards);
                                            Console.WriteLine($"\nWartość: {playerCards.Sum(x => x.Value)}");

                                            playerContinue = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nie rozumiem polecenia!");
                                        }
                                    }
                                } while (playerContinue);

                                if (playerCards.Sum(x => x.Value) > 21)
                                {
                                    
                                }
                                else
                                {
                                    while (casinoCards.Sum(x => x.Value) < 16)
                                    {
                                        casinoCards.Add(deck[deckPosition++]);
                                        Console.Write("Karty krupiera: ");
                                        PrintCards(casinoCards);
                                        Console.WriteLine($"\nWartość kart krupiera: {casinoCards.Sum(x => x.Value)}");
                                    }

                                    if (casinoCards.Sum(x => x.Value) > 21)
                                    {
                                        Console.WriteLine($"Wygrałeś!\nWartość Twoich kart: {playerCards.Sum(x => x.Value)}\nWartość kart krupiera: {casinoCards.Sum(x => x.Value)}");
                                        casino.AddMoney(2 * bets[bet - 1]);
                                    } else if (casinoCards.Sum(x => x.Value) > playerCards.Sum(x => x.Value))
                                    {
                                        Console.WriteLine($"\nPrzegrałeś!\nWartość Twoich kart: {playerCards.Sum(x => x.Value)}\nWartość kart krupiera: {casinoCards.Sum(x => x.Value)}");
                                    }
                                    else if (casinoCards.Sum(x => x.Value) < playerCards.Sum(x => x.Value))
                                    {
                                        Console.WriteLine($"\nWygrałeś!\nWartość Twoich kart: {playerCards.Sum(x => x.Value)}\nWartość kart krupiera: {casinoCards.Sum(x => x.Value)}");
                                        casino.AddMoney(2 * bets[bet - 1]);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nRemis!\nWartość Twoich kart: {playerCards.Sum(x => x.Value)}\nWartość kart krupiera: {casinoCards.Sum(x => x.Value)}");
                                        casino.AddMoney(bets[bet - 1]);
                                    }
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Nie rozumiem polecenia!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                Console.WriteLine("Naciśnij enter aby kontynuować...");
                Console.ReadLine();
            } while (bet != 9);
        }

        private void PrintCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.Write($"{card.Color}{card.Symbol}");
            }
        }

        private async Task<List<Card>> CreateDeck()
        {
            var deck = new List<Card>();
            var colors = new List<char>(new[] 
            {
                '\u2660',
                '\u2665',
                '\u2666',
                '\u2663'
            });
            var symbols = new List<string>(new[] 
            {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "J",
                "Q",
                "K",
                "A"
            });

            for (int i = 0; i < colors.Count; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    var card = new Card();

                    card.Color = colors[i];
                    card.Symbol = symbols[j];

                    switch (card.Symbol)
                    {
                        case "1":
                            card.Value = 1;
                            break;
                        case "2":
                            card.Value = 2;
                            break;
                        case "3":
                            card.Value = 3;
                            break;
                        case "4":
                            card.Value = 4;
                            break;
                        case "5":
                            card.Value = 5;
                            break;
                        case "6":
                            card.Value = 6;
                            break;
                        case "7":
                            card.Value = 7;
                            break;
                        case "8":
                            card.Value = 8;
                            break;
                        case "9":
                            card.Value = 9;
                            break;
                        case "10":
                        case "J":
                        case "Q":
                        case "K":
                            card.Value = 10;
                            break;
                        case "A":
                            card.Value = 11;
                            break;
                    }

                    deck.Add(card);
                }
            }

            return deck;
        }
    }
}
