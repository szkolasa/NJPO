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
using NJPO.Collections.Domain;

namespace NJPO.Collections
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public Person NewContact { get; set; }

        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void defaultButton_Click(object sender, RoutedEventArgs e)
        {
            NewContact = new Person() { Name = nameBox.Text, Surname = surnameBox.Text, Phone = phoneBox.Text };
            DialogResult = true;
        }
    }
}
