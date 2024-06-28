using LibraryApplication.Account;
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

namespace LibraryApplication
{
    /// <summary>
    /// Логика взаимодействия для ChangeUser.xaml
    /// </summary>
    public partial class ChangeUser : Window
    {
        public ChangeUser()
        {
            InitializeComponent();
        }


        private void Log_Out(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
            
        }
        private void History_Clicked(object sender, RoutedEventArgs e)
        {
            History history = new History();
            history.Show();
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }
    }
}
