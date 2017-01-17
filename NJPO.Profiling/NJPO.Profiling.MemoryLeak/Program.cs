using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NJPO.Profiling.MemoryLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie uchwytów do wszystkich plików txt w systemie bez zwalniania zasobów
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    GetFiles(drive.RootDirectory.FullName);
                }
            }

            Console.WriteLine($"Zajęta pamięć: {GC.GetTotalMemory(true)}");
            Console.ReadLine();
        }

        public static void GetFiles(string path)
        {
            var currentDir = new DirectoryInfo(path);

            try
            {
                foreach (var dir in currentDir.GetDirectories())
                {
                    GetFiles(dir.FullName);
                }

                foreach (var file in currentDir.GetFiles())
                {
                    if (file.Extension == "txt")
                    {
                        var reader = new StreamReader(file.FullName);

                        //using (var reader = new StreamReader(file.FullName))
                        //{
                        //      Zastosowanie tego bloku gwarantuje zwolnienie zasobu po zakończeniu
                        //}
                    }
                }
            }
            catch
            {

            }
        }
    }
}
