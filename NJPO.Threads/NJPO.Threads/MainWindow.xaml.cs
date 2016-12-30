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
        private DateTime iterativeTime, recursiveTime;

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

                Task.Run(() =>
                    {
                        var start = DateTime.Now;

                        BigInteger? result = null;

                        for (int i = 0; i < 100000; i++)
                        {
                            result = IterationFactorial(factorial, token.Token);

                            if (result == null)
                            {
                                break;
                            }
                        }

                        var end = DateTime.Now;
                        var difference = end.Subtract(start);

                        if (result != null)
                        {
                            iterative.Dispatcher.InvokeAsync(() => iterative.Content = String.Format("{0:E}", result));
                            timeIterative.Dispatcher.InvokeAsync(() => timeIterative.Content = $"{difference.Minutes}:{difference.Seconds}:{difference.Milliseconds}");
                        }
                        else
                        {
                            iterative.Dispatcher.InvokeAsync(() => iterative.Content = string.Empty);
                            timeIterative.Dispatcher.InvokeAsync(() => timeIterative.Content = string.Empty);
                        }

                        return result;
                    }, token.Token);

                Task.Run(() => 
                    {
                        var start = DateTime.Now;

                        BigInteger? result = null;

                        for (int i = 0; i < 100000; i++)
                        {
                            result = RecursiveFactorial(factorial, token.Token);
                            
                            if (result == null)
                            {
                                break;
                            }
                        }

                        var end = DateTime.Now;
                        var difference = end.Subtract(start);

                        if (result != null)
                        {
                            recursive.Dispatcher.InvokeAsync(() => recursive.Content = String.Format("{0:E}", result));
                            timeRecursive.Dispatcher.InvokeAsync(() => timeRecursive.Content = $"{difference.Minutes}:{difference.Seconds}:{difference.Milliseconds}");
                        }
                        else
                        {
                            recursive.Dispatcher.InvokeAsync(() => recursive.Content = string.Empty);
                            timeRecursive.Dispatcher.InvokeAsync(() => timeRecursive.Content = string.Empty);
                            StopButton.Dispatcher.InvokeAsync(() => StopButton.IsEnabled = false);
                            StartButton.Dispatcher.InvokeAsync(() => StartButton.IsEnabled = true);
                        }

                        return result;
                    })
                    .ContinueWith((t) =>
                    {
                        StopButton.Dispatcher.InvokeAsync(() => StopButton.IsEnabled = false);
                        StartButton.Dispatcher.InvokeAsync(() => StartButton.IsEnabled = true);
                    }, token.Token);

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
                    token.ThrowIfCancellationRequested();
                    result *= i;
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
            try
            {
                token.ThrowIfCancellationRequested();
                return number == 0 ? 1 : number * RecursiveFactorial(--number, token);
            }
            catch
            {
                return null;
            }
        }
    }
}
