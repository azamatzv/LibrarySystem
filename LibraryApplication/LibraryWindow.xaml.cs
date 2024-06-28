using LibraryApplication.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        private readonly HttpClient _httpClient;
        private const string url = @"https://freetestapi.com/api/v1/books?search=";
        List <Book> books;

        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public LibraryWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            var storedbooks = BookData.Readfromfile();
            if (storedbooks.Count == 0)
            {
                books = Fillingwithdatas();
                BookData.Writetofile(books);
            }
            else
            {
                books = BookData.Readfromfile();

            }

            Librarydatagrid.ItemsSource = books;
        }



        public List<Book> Fillingwithdatas()
        {
            var storedjsondata = _httpClient.GetStringAsync(url).Result;
            var dstoredjsondata = JsonSerializer.Deserialize<List<Book>>(storedjsondata, jsonSerializerOptions);

            return dstoredjsondata;
        }

        private void SearchButton(object sender, RoutedEventArgs e)
        {
            var searchtext = searchtextbox.Text;

            var searchedbooks = books.Where(book =>
            book.Id.ToString().Contains(searchtext) ||
            book.Title.Contains(searchtext) ||
            book.Description.Contains(searchtext) ||
            book.Author.Contains(searchtext) ||
            book.CoverImage.Contains(searchtext) ||
            book.Genre.Contains(searchtext) ||
            book.PublicationYear.ToString().Contains(searchtext)

            );

            Librarydatagrid.ItemsSource = searchedbooks;
        }

        private void BookrentButton(object sender, RoutedEventArgs e)
        {
            Book selectedbook = Librarydatagrid.SelectedItem as Book;


            if (selectedbook is not null)
            {
                Bookrent bookrent = new Bookrent();
                bookrent.Show();
            }
            else
            {
                MessageBox.Show("Book was not selected" , "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            
        }
    }
}
