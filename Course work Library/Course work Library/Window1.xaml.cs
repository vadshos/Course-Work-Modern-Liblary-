using Course_work_Library.CategoriesModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\categoryList.json";
        private BindingList<CategoriesBooks> _categoriesList;
        public Window1()
        {
            InitializeComponent();
        }
        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _categoriesList = FileIOService.LoadDataCategories(PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            categList.ItemsSource = _categoriesList;
        }

        private void categList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elem = (ListBox)sender;
            var item = (CategoriesBooks)elem.SelectedItem;
            Window window = new WindowsListBooks(item.NameCategory);
            this.Close();
            window.Show();
        }

        private void PackIconBoxIcons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window window = new MainWindow();
            this.Close();
            window.Show();
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
