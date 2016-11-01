using System;
using System.IO;
using System.Windows.Forms;

namespace NJPO.Decorator.Domain
{
    public class WordCounter
    {
        public WordCounter()
        {
            Console.Clear();
            Console.WriteLine("********** Zliczanie słów **********");
            Console.WriteLine("\nNaciśnij enter aby wybrać plik...");
            Console.ReadLine();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Pliki tekstowe (*.txt)|*.txt";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dlg.FileName))
                {
                    var fileContent = sr.ReadToEnd();

                    Console.WriteLine("Zawartość pliku:\n");
                    Console.WriteLine(fileContent);

                    fileContent = fileContent.Replace("\n", " ").Replace("\t", " ");
                    var length = fileContent.Split(' ').Length;

                    Console.WriteLine($"\nLiczba słów w pliku: {length}");
                }
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku!");
            }
        }
    }
}
