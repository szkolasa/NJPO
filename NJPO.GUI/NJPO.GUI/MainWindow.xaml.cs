using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace NJPO.GUI
{
    public enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Operation operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            helloLabel.Content = $"Witaj, {nameTextBox.Text}!";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            
            switch (radioButton.Content.ToString())
            {
                case "Suma":
                    operation = Operation.Addition;
                    break;
                case "Różnica":
                    operation = Operation.Subtraction;
                    break;
                case "Iloczyn":
                    operation = Operation.Multiplication;
                    break;
                case "Iloraz":
                    operation = Operation.Division;
                    break;
                default:
                    break;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var num1 = num1Box.Text;
            var num2 = num2Box.Text;

            double n1, n2, res = 0;

            if (double.TryParse(num1, out n1))
            {
                if (double.TryParse(num2, out n2))
                {
                    switch (operation)
                    {
                        case Operation.Addition:
                            res = n1 + n2;
                            break;
                        case Operation.Subtraction:
                            res = n1 - n2;
                            break;
                        case Operation.Multiplication:
                            res = n1 * n2;
                            break;
                        case Operation.Division:
                            res = n1 / n2;
                            break;
                        default:
                            break;
                    }

                    resultBox.Text = res.ToString();
                }
                else
                {
                    resultBox.Text = "Wpisz poprawną liczbę";
                }
            }
            else
            {
                resultBox.Text = "Wpisz poprawną liczbę";
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            var rand = new Random();
            bool canMove;

            do
            {
                var num = rand.Next(4);

                if (num == 0)
                {
                    if ((button.Margin.Left - 50) >= 0)
                    {
                        button.Margin = new Thickness(button.Margin.Left - 50, button.Margin.Top, button.Margin.Right, button.Margin.Bottom);
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
                else if (num == 1)
                {
                    if ((button.Margin.Right + 50) <= ex3.ActualWidth)
                    {
                        button.Margin = new Thickness(button.Margin.Left + 50, button.Margin.Top, button.Margin.Right, button.Margin.Bottom);
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
                else if (num == 2)
                {
                    if ((button.Margin.Top - 50) >= 0)
                    {
                        button.Margin = new Thickness(button.Margin.Left, button.Margin.Top - 50, button.Margin.Right, button.Margin.Bottom);
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
                else
                {
                    if ((button.Margin.Top + 50) <= ex3.ActualHeight)
                    {
                        button.Margin = new Thickness(button.Margin.Left, button.Margin.Top + 50, button.Margin.Right, button.Margin.Bottom);
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
            } while (!canMove);
        }

        private void veryfyButton_Click(object sender, RoutedEventArgs e)
        {
            var text = peselBox.Text;
            var nums = new List<int>();

            foreach (var num in text)
            {
                int number;

                if (int.TryParse(num.ToString(), out number))
                {
                    nums.Add(number);
                }
                else
                {
                    veryfyResultLabel.Content = "Nieproprawne dane wejściowe!";
                    return;
                }
            }

            if (Veryfy(nums.ToArray()))
            {
                using (var sw = new StreamWriter("pesel.txt", true))
                {
                    sw.WriteLine(text);
                }

                veryfyResultLabel.Content = "PESEL jest poprawny!";
            }
            else
            {
                veryfyResultLabel.Content = "PESEL nie jest poprawny!";
            }
        }

        bool Veryfy(int[] digits)
        {
            int sum = 0;
            bool alt = false;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int temp = digits[i];
                if (alt)
                {
                    temp *= 2;
                    if (temp > 9)
                    {
                        temp -= 9;
                    }
                }
                sum += temp;
                alt = !alt;
            }

            return sum % 10 == 0;
        }

        private void openFolderButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
