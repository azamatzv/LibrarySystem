using System.Windows;
using System.Windows.Navigation;

namespace LibraryApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Test(object sender, RoutedEventArgs e, NavigationService navigationService)
    {
        ChangeUser changeUser = new ChangeUser();
        changeUser.Show();
        Close();
    }
}