using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NJPO.Singleton.Abstract;
using NJPO.Singleton.Domain;
using NJPO.Singleton.Games;

namespace NJPO.Singleton
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Symulator kasyna";

            var casino = Casino.Instance;
            var games = new List<IGame>(new IGame[]
            {
                new SlotMachine(),
                new BlackJack()
            });

            string gameInput;
            int menuOption;

            do
            {
                Console.WriteLine("********** Symulator kasyna **********\n");
                Console.WriteLine("Stan konta: {0:c}\n", casino.Money);
                
                for (int i = 0; i < games.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {games[i].Name}");
                }
                Console.WriteLine("9) Wyjście\n");

                Console.Write("Wybierz opcję: ");

                gameInput = Console.ReadLine();

                if (int.TryParse(gameInput, out menuOption))
                {
                    var game = games.Where((g, i) => i == (menuOption - 1)).FirstOrDefault();

                    if (game != null)
                    {
                        game.Play(casino);
                    }
                }
                else
                {
                    Console.WriteLine("Nie rozumiem polecenia!");
                }

                Console.Clear();
            } while (menuOption != 9);

            Console.WriteLine("Do widzenia!");
            Thread.Sleep(1500);
        }
    }
}
