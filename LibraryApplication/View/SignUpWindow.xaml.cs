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

namespace LibraryApplication.View
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUpClicked(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string phoneNumber = PhoneNumberTextBox.Text;
            DateTime? dateOfBirth = DateOfBirthPicker.SelectedDate;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber) || !dateOfBirth.HasValue)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            SaveToFile(fullName, username, password, phoneNumber, dateOfBirth.Value);

            MessageBox.Show("Sign up successful!");
            ClearFields();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ClearFields()
        {
            FullNameTextBox.Text = string.Empty;
            UsernameTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
            PhoneNumberTextBox.Text = string.Empty;
            DateOfBirthPicker.SelectedDate = null;
        }
        private void SaveToFile(string fullName, string username, string password, string phoneNumber, DateTime dateOfBirth)
        {
            string filePath = @"C:\Users\azama\OneDrive\Desktop\LibraryApp\LibrarySystem\LibraryApplication\View\data.txt";
            string userData = $"Full Name: {fullName}, " +
                              $"Username: {username}, " +
                              $"Password: {password}, " +
                              $"Phone Number: {phoneNumber}, " +
                              $"Date of Birth: {dateOfBirth.ToShortDateString()}";

            try
            {
                using(StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userData);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }
    }
}