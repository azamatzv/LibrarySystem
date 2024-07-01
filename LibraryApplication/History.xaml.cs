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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        private string historyFilePath = @"C:\Users\azama\OneDrive\Desktop\LibrarySystem\LibraryApplication\Bookrentfile.txt";
        public History()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                if (File.Exists(historyFilePath))
                {
                    string historyContent = File.ReadAllText(historyFilePath);
                    txtDisplay.Text = historyContent;
                }
                else
                {
                    MessageBox.Show("History file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history: {ex.Message}");
            }
        }
    }
}
