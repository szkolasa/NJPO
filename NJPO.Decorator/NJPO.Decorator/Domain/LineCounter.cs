using System;

namespace NJPO.Decorator.Domain
{
    public class LineCounter
    {
        public LineCounter()
        {
            ConsoleKeyInfo key;
            string text = string.Empty;
            int lines = 1;

            do
            {
                Console.Clear();
                Console.WriteLine("********** Zliczanie wierszy **********");
                Console.WriteLine("\nWprowadź tekst (Escape kończy działanie programu)\n");
                Console.Write(text);

                key = Console.ReadKey();

                if (key.Key != ConsoleKey.Escape)
                {
                    text += key.KeyChar;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    lines++;
                    text += "\n";
                }
                
            } while (key.Key != ConsoleKey.Escape);

            Console.WriteLine($"\n\nLiczba wierszy: {lines}");
        }
    }
}
