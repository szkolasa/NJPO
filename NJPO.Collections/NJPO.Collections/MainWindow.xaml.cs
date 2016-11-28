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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using NJPO.Collections.Domain;
using System.Collections.ObjectModel;

namespace NJPO.Collections
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> phoneBook;
        int loop = 99999;

        public MainWindow()
        {
            InitializeComponent();
            phoneBook = new ObservableCollection<Person>();
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki|*.*";

            if (openDialog.ShowDialog() == true)
            {
                using (var sr = new StreamReader(openDialog.FileName))
                {
                    contentTextBox.Text = sr.ReadToEnd();
                }
            }
        }

        private void countFrequency_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FrequencyWindow(contentTextBox.Text);
            dlg.ShowDialog();
        }

        private void addContact_Click(object sender, RoutedEventArgs e)
        {
            var contactWindow = new NewContactWindow();

            if (contactWindow.ShowDialog() == true)
            {
                var person = contactWindow.NewContact;
                phoneBook.Add(person);

                phoneBookDataGrid.ItemsSource = phoneBook.OrderBy(x => x.Surname);
            }
        }

        private void insert1_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < 5000; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.Insert(0, new Person());
            }

            end = DateTime.Now;

            List1.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                linked.AddFirst(new Person());
            }

            end = DateTime.Now;

            LinkedList1.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void insert2_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < 5000; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < 9999; i++)
            {
                list.Insert((list.Count / 2), new Person());
            }

            end = DateTime.Now;

            List2.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";
            
            start = DateTime.Now;

            for (int i = 0; i < 9999; i++)
            {
                var middle = linked.Find(linked.ElementAt((linked.Count / 2) + 1));
                linked.AddBefore(middle, new Person());
            }

            end = DateTime.Now;

            LinkedList2.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void insert3_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < 5000; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
            }

            end = DateTime.Now;

            List3.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                linked.AddLast(new Person());
            }

            end = DateTime.Now;

            LinkedList3.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void delete1_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.RemoveAt(0);
            }

            end = DateTime.Now;

            List4.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                linked.RemoveFirst();
            }

            end = DateTime.Now;

            LinkedList4.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void delete2_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < 1234; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < 1234; i++)
            {
                list.RemoveAt(list.Count / 2);
            }

            end = DateTime.Now;

            List5.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < 1234; i++)
            {
                var middle = linked.Find(linked.ElementAt((linked.Count / 2)));
                linked.Remove(middle);
            }

            end = DateTime.Now;

            LinkedList5.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void delete3_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.RemoveAt(list.Count - 1);
            }

            end = DateTime.Now;

            List6.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                linked.RemoveLast();
            }

            end = DateTime.Now;

            LinkedList6.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void return1_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.ElementAt(0);
            }

            end = DateTime.Now;

            List7.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                var first = linked.First;
            }

            end = DateTime.Now;

            LinkedList7.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void return2_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < 1234; i++)
            {
                list.ElementAt(list.Count / 2);
            }

            end = DateTime.Now;

            List8.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < 1234; i++)
            {
                linked.ElementAt(linked.Count / 2);
            }

            end = DateTime.Now;

            LinkedList8.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }

        private void return3_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>();
            var linked = new LinkedList<Person>();
            DateTime start, end;

            Cursor = Cursors.Wait;

            for (int i = 0; i < loop; i++)
            {
                list.Add(new Person());
                linked.AddFirst(new Person());
            }

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                list.ElementAt(list.Count - 1);
            }

            end = DateTime.Now;

            List9.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            start = DateTime.Now;

            for (int i = 0; i < loop; i++)
            {
                var last = linked.Last;
            }

            end = DateTime.Now;

            LinkedList9.Content = $"{end.Subtract(start).Seconds}.{end.Subtract(start).Milliseconds}s";

            Cursor = Cursors.Arrow;
        }
    }
}
