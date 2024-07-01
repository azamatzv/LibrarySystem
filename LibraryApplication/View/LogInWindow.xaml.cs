using System.IO;
using System.Windows;

namespace LibraryApplication.View;

public partial class LogInWindow : Window
{
    public LogInWindow()
    {
        InitializeComponent();
    }

    private void LogInButton_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text;
        string password = PasswordBox.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            return;
        }

        if (ValidateCredentials(username, password))
        {   
            LibraryWindow libraryWindow = new LibraryWindow();
            libraryWindow.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateCredentials(string username, string password)
    {
        string directoryPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "data");
        string filePath = System.IO.Path.Combine(directoryPath, @"C:\Users\azama\OneDrive\Desktop\LibrarySystem\LibraryApplication\View\data.txt");

        if (!File.Exists(filePath))
        {
            return false;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            if (parts.Length >= 5)
            {
                string savedUsername = parts[1].Split(':')[1].Trim();
                string savedPassword = parts[2].Split(':')[1].Trim();

                if (savedUsername == username && savedPassword == password)
                {
                    return true;
                }
            }
        }

        return false;
    }

        private void ShowButtonPasswordClicked(object sender, RoutedEventArgs e)
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
