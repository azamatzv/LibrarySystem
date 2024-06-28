using LibraryApplication.View;
using System.Windows;

namespace LibraryApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LogInButtonClicked(object sender, RoutedEventArgs e)
    {
        LogInWindow logInWindow = new LogInWindow();
        logInWindow.Show();
    }

    private void SignUpButtonClicked(object sender, RoutedEventArgs e)
    {
            LibraryWindow libraryWindow = new LibraryWindow();
            libraryWindow.Show();
        SignUpWindow signUpWindow = new SignUpWindow();
        signUpWindow.Show();
    }
}