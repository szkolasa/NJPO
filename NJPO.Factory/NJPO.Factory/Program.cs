using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Factory.Abstract;
using NJPO.Factory.Domain;
using System.IO;
using System.Diagnostics;

namespace NJPO.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var pages = new List<WebPage>();
            var factory = new SimpleFactory();
            var rand = new Random();
            var inputString = string.Empty;
            var fileNumber = 1;
            int option;

            Console.Title = "Generator HTML";

            do
            {
                Console.Clear();
                Console.WriteLine("********** Generator HTML **********");
                Console.WriteLine($"Wygenerowanych stron: {pages.Count}");
                Console.WriteLine("\n1)Wygeneruj kolejną stronę\n2)Koniec");
                Console.Write("\nWybierz opcję: ");
                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out option))
                {
                    if (option == 1)
                    {
                        pages.Add(factory.CreateWebPage((WebPageType)rand.Next(4)));
                    }
                }
            } while (option != 2);

            foreach (var page in pages)
            {
                using (StreamWriter sw = new StreamWriter($"Plik{fileNumber++}.html"))
                {
                    sw.Write(page.GeneratePage());
                }
            }

            Console.WriteLine("Naciśnij enter aby wyświetlić wygenerowane pliki...");
            Console.ReadLine();
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
