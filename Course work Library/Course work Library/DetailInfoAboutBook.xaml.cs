using Course_work_Library.BookModel;
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


namespace Course_work_Library
{
    /// <summary>
    /// Interaction logic for DetailInfoAboutBook.xaml
    /// </summary>
    public partial class DetailInfoAboutBook : Window
    {
        private Book book { get; set; }
        public DetailInfoAboutBook()
        {
            InitializeComponent();
        }
        public DetailInfoAboutBook(Book selectedBook)
        {
            book = selectedBook;
            InitializeComponent();
            Image_Loaded();
            Autor.Text = $"Author : {book.Author}";
            Title.Text = $"Title : {book.Title}";
            YearP.Text = $"Year of publishing : {book.YearOfPublication}";

        }
        private void PackIconBoxIconsExit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.Close();

        }
        private void Image_Loaded()
        {
            
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(book.imgPath);
            bi3.EndInit();
            ImageViewer1.Stretch = Stretch.Fill;
            ImageViewer1.Source = bi3;
          
            
        }

        private void Autor_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new PDF_View(book.PATH_pdf);
            window.Show();
        }

        private void PackIconBoxIcons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
