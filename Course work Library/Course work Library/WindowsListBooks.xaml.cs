using Course_work_Library.BookModel;
using Course_work_Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Course_work_Library
{
    /// <summary>
    /// Interaction logic for WindowsListBooks.xaml
    /// </summary>
    public partial class WindowsListBooks : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\";
        BindingList<Book> books;
        BindingList<Book> fullListBooks;

        public WindowsListBooks()
        {
            InitializeComponent();
        }
        public WindowsListBooks(string path)
        {
            PATH = $"{path+".JSON"}";
            fullListBooks = FileIOService.LoadDataCategoriesBooks(PATH);
            InitializeComponent();
            
        }

        private void listBooks_Loaded(object sender, RoutedEventArgs e)
        {
           
            if(books == null)
            {
                bookList.ItemsSource = fullListBooks;
            }
            else
            {

            bookList.ItemsSource = books;
            }
           
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if(String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                bookList.ItemsSource = fullListBooks;

                return;
            }
            
                
            var b = from temp in fullListBooks where (temp.Title.ToLower().Contains((sender as TextBox).Text.ToLower() ?? "null") || temp.Author.ToLower().Contains((sender as TextBox).Text.ToLower() ?? "null"))&& temp != null  select temp;
            if (books != null)
            {
                books.Clear();
            }
            else
            {
               books = new BindingList<Book>();
            }
            foreach (var item in b)
            {
               books.Add(item);
            }
              bookList.ItemsSource = books;
        }

        private void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Window window = new DetailInfoAboutBook(((sender as ListBox).SelectedItem as Book));
            window.Show();
        }

        private void PackIconBoxIcons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window window = new Window1();
            window.Show();
            this.Close();
        }
        private void PackIconBoxIconsExit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
