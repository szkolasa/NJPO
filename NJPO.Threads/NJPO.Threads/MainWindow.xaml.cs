using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Numerics;

namespace NJPO.Threads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int file = 1;
        private CancellationTokenSource token;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zipBomb_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => CreateBinaryFile());
                Thread.Sleep(200);
            }

            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        public async Task CreateBinaryFile()
        {
            Random rand = new Random();
            var size = rand.Next(1000, 1000000);

            var data = new byte[size];

            using (var bw = new BinaryWriter(File.OpenWrite($"file{file++}.bin")))
            {
                bw.Write(data);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            BigInteger factorial = 0;

            if (BigInteger.TryParse(number.Text, out factorial))
            {
                token = new CancellationTokenSource();

                Task.Run(() => IterationFactorial(factorial, token.Token), token.Token)
                    .ContinueWith((t) =>
                    {
                        if (t.Result != null)
                        {
                            iterative.Dispatcher.InvokeAsync(() => iterative.Content = t.Result);
                        }
                        else
                        {
                            iterative.Dispatcher.InvokeAsync(() => iterative.Content = string.Empty);
                        }
                    });

                Task.Run(() => RecursiveFactorial(factorial, token.Token), token.Token)
                    .ContinueWith((t) =>
                    {
                        if (t.Result != null)
                        {
                            recursive.Dispatcher.InvokeAsync(() => recursive.Content = t.Result);
                        }
                        else
                        {
                            recursive.Dispatcher.InvokeAsync(() => recursive.Content = string.Empty);
                        }

                        StartButton.Dispatcher.InvokeAsync(() => StartButton.IsEnabled = true);
                        StopButton.Dispatcher.InvokeAsync(() => StopButton.IsEnabled = false);
                    });

                StopButton.IsEnabled = true;
                StartButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Niepoprawne dane wejściowe");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            token.Cancel();
        }

        private BigInteger? IterationFactorial(BigInteger number, CancellationToken token)
        {
            try
            {
                BigInteger result = 1;

                for (BigInteger i = 1; i <= number; i++)
                {
                    result *= i;
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(300);
                }

                return result;

            }
            catch
            {
                return null;
            }
        }

        private BigInteger? RecursiveFactorial(BigInteger number, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            try
            {
                Thread.Sleep(300);
                return number == 0 ? 1 : number * RecursiveFactorial(--number, token);
            }
            catch
            {
                return null;
            }
        }
    }
}
