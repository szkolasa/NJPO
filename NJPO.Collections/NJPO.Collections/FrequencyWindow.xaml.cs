using System; 
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NJPO.Collections
{
    public partial class FrequencyWindow : Window
    {
        public FrequencyWindow(string text)
        {
            InitializeComponent();

            var chars = text.Replace("\n", "")
                .Replace("\t", "")
                .Replace(" ", "")
                .Replace("\r", "")
                .ToList();

            var hashChars = new HashSet<char>();

            foreach (var c in chars)
            {
                hashChars.Add(c);
            }

            foreach (var c in hashChars)
            {
                freqBox.Text += $"Znak:\t{c}\tWystąpień:\t{text.Where(x => x == c).Count()}\n";
            }
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
