using System.Windows;

namespace LibraryApplication.View;

public partial class LogInWindow : Window
{
    public LogInWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text;
        string password = PasswordBox.Password;

        if (IsValidCredentials(username, password))
        {
            MessageBox.Show("Login successful!");
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }

    private bool IsValidCredentials(string username, string password)
    {
        return username == "admin" && password == "password";
    }

    private void ShowPasswordButton_Click(object sender, RoutedEventArgs e)
    {
        if (PasswordBox.Visibility == Visibility.Visible)
        {
            PasswordBox.Visibility = Visibility.Collapsed;
            PasswordTextBox.Visibility = Visibility.Visible;
            PasswordTextBox.Text = PasswordBox.Password;
        }
        else
        {
            PasswordBox.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Collapsed;
            PasswordBox.Password = PasswordTextBox.Text;
        }
    }
}