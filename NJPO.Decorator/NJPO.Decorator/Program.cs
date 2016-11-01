using System;
using System.Text;
using System.Threading;
using NJPO.Decorator.Domain;

namespace NJPO.Decorator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string optionString;
            int option;

            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Dekorator";

            do
            {
                Console.Clear();
                Console.WriteLine("********** Dekorator **********\n");
                Console.WriteLine("1) Zliczanie wierszy\n2) Zliczanie słów\n3) Symulator zachowań drogowych\n9) Wyjście\n");

                Console.Write("Wybierz opcję: ");
                optionString = Console.ReadLine();

                if (int.TryParse(optionString, out option))
                {
                    switch (option)
                    {
                        case 1:
                            new LineCounter();
                            break;
                        case 2:
                            new WordCounter();
                            break;
                        case 3:
                            new RoadSimulator();
                            break;
                        case 9:
                            Console.WriteLine("Do widzenia!");
                            Thread.Sleep(1500);
                            break;
                        default:
                            Console.WriteLine("Nie rozumiem polecenia!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nie rozumiem polecenia!");
                }

                if (option != 9)
                {
                    Console.WriteLine("Naciśnij enter aby kontynuować...");
                    Console.ReadLine(); 
                }
            } while (option != 9);
        }
    }
}
