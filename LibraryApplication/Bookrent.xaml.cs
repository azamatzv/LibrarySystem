using System;
using System.Collections.Generic;
using System.IO;
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


namespace LibraryApplication
{
    /// <summary>
    /// Interaction logic for Bookrent.xaml
    /// </summary>
    public partial class Bookrent : Window
    {
        List<Book> books;
        private const string Path2 = @"C:\Users\azama\OneDrive\Desktop\LibrarySystem\LibraryApplication\Bookrentfile.txt";
        public Bookrent()
        {
            InitializeComponent();
            dateform.Text = DateTime.Now.ToString();

            

        }

        private void TakeButton(object sender, RoutedEventArgs e)
        {
            if (fullname.Text is "" || password.Text is "" || dateofbirth.Text is "" || dateform.Text is "")
            {
                MessageBox.Show("Not all datas were not filled", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Successfully done", "Task ", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            Writebookrenttofile(fullname.Text, password.Text, dateofbirth.Text, dateform.Text);
        }

        public void Writebookrenttofile(string fullname, string password, string birthday, string dateform)
        {
            using(StreamWriter sw = new StreamWriter(Path2, true))
            {
                sw.WriteLine($"fullname: {fullname}, password: {password}, birthday: {birthday}, dateform: {dateform}");
            }
        }
    }
}
