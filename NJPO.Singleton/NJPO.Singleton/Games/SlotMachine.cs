using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Singleton.Abstract;
using NJPO.Singleton.Domain;

namespace NJPO.Singleton.Games
{
    public class SlotMachine : IGame
    {
        public string Name { get { return "Jednoręki bandyta"; } }

        public void Play(Casino casino)
        {
            var bets = new[] { 1, 5, 10, 25, 50, 100 };
            var random = new Random();

            var numbers = new int[3, 3];

            string betString;
            int bet;
            
            do
            {
                Console.Clear();
                Console.WriteLine("********** Jednoręki bandyta **********\n");
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

                            Console.WriteLine("\nTwoje liczby\n");

                            for (int i = 0; i < numbers.GetLength(0); i++)
                            {
                                for (int j = 0; j < numbers.GetLength(1); j++)
                                {
                                    numbers[i, j] = random.Next(10);
                                    Console.Write($"{numbers[i,j]} ");
                                }

                                Console.WriteLine();
                            }

                            var result = CheckNumbers(numbers);

                            if (result)
                            {
                                Console.WriteLine("\nWygrałeś!\n");
                                casino.AddMoney(bets[bet - 1] * 2);
                            }
                            else
                            {
                                Console.WriteLine("\nPrzegrałeś!\n");
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
                else
                {
                    Console.WriteLine("Nie rozumiem polecenia!");
                }

                Console.WriteLine("Naciśnij enter aby kontynuować...");
                Console.ReadLine();
            } while (bet != 9);
        }

        public bool CheckNumbers(int[,] numbers)
        {
            var win = false;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (numbers[i,0] == numbers[i,1] && numbers[i,1] == numbers[i,2])
                {
                    return true;
                }
            }

            if ((numbers[0,0] == numbers[1,1] && numbers[1,1] == numbers[2,2]) || (numbers[2,0] == numbers[1,1] && numbers[1,1] == numbers[0,2]))
            {
                return true;
            }

            return win;
        }
    }
}
